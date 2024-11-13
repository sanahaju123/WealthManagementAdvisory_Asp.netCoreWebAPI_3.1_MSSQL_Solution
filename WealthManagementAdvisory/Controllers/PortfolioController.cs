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
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpPost]
        [Route("/api/portfolio/add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPortfolio([FromBody] Portfolio portfolio)
        {
            if (portfolio == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid portfolio data!" });
            }

            try
            {
                var addedPortfolio = await _portfolioService.AddPortfolioAsync(portfolio);

                if (addedPortfolio == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "Portfolio addition failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "Portfolio added successfully!" });
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
        [Route("/api/portfolio/view/{userId}")]
        public async Task<IActionResult> ViewPortfolio(int userId)
        {
            try
            {
                var portfolio = await _portfolioService.ViewPortfolioAsync(userId);

                if (portfolio == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "Portfolio not found for this user." });
                }

                return Ok(portfolio);
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

        [HttpPut]
        [Route("/api/portfolio/rebalance/{userId}")]
        public async Task<IActionResult> RebalancePortfolio(int userId, [FromBody] Portfolio targetAllocation)
        {
            if (targetAllocation == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid target allocation data!" });
            }

            try
            {
                var rebalancedPortfolio = await _portfolioService.RebalancePortfolioAsync(userId, targetAllocation);

                if (rebalancedPortfolio == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "Portfolio rebalance failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "Portfolio rebalanced successfully!" });
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
    