using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WealthManagementAdvisory.BusinessLayer.Interfaces;
using WealthManagementAdvisory.Entities;

namespace WealthManagementAdvisory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisoryController : ControllerBase
    {
        private readonly IAdvisoryService _advisoryService;
        public AdvisoryController(IAdvisoryService advisoryService)
        {
            _advisoryService = advisoryService;
        }

        [HttpGet]
        [Route("/api/advisory/recommendations/{userId}")]
        public async Task<IActionResult> GetInvestmentRecommendations(int userId)
        {
            try
            {
                var advisory = await _advisoryService.GetInvestmentRecommendationsAsync(userId);

                if (advisory == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "No investment recommendations found for this user." });
                }

                return Ok(advisory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = $"An error occurred: {ex.Message}"
                });
            }
        }

        [HttpPost]
        [Route("/api/advisory/schedule")]
        [AllowAnonymous]
        public async Task<IActionResult> ScheduleAdvisorySession([FromBody] Advisory sessionRequest)
        {
            if (sessionRequest == null || sessionRequest.UserId <= 0 || sessionRequest.AdvisoryDate == default)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid session request data!" });
            }

            try
            {
                var advisorySession = await _advisoryService.ScheduleAdvisorySessionAsync(sessionRequest.UserId, sessionRequest.AdvisoryDate, sessionRequest.SessionType);

                if (advisorySession == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "Scheduling advisory session failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "Advisory session scheduled successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = $"An error occurred: {ex.Message}"
                });
            }
        }

        [HttpGet]
        [Route("/api/advisory/details/{advisoryId}")]
        public async Task<IActionResult> GetAdvisoryDetails(int advisoryId)
        {
            try
            {
                var advisoryDetails = await _advisoryService.GetAdvisoryDetailsAsync(advisoryId);

                if (advisoryDetails == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "Advisory details not found." });
                }

                return Ok(advisoryDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "Error",
                    Message = $"An error occurred: {ex.Message}"
                });
            }
        }
    }
}
    