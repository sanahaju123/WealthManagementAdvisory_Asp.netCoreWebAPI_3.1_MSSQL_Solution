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
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        [Route("/api/investment/add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddInvestment([FromBody] Investment addInvestmentRequest)
        {
            if (addInvestmentRequest == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid investment data!" });
            }

            try
            {
                var addedInvestment = await _investmentService.AddInvestmentAsync(addInvestmentRequest);

                if (addedInvestment == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "Investment addition failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "Investment added successfully!" });
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
        [Route("/api/investment/{userId}")]
        public async Task<IActionResult> GetInvestments(int userId)
        {
            try
            {
                var investments = await _investmentService.GetInvestmentsAsync(userId);

                if (investments == null || investments.Count == 0)
                {
                    return NotFound(new Response { Status = "Error", Message = "No investments found for this user." });
                }

                return Ok(investments);
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
