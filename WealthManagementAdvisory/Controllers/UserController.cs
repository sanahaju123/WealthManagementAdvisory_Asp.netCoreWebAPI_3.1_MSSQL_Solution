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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/user/create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserProfile([FromBody] User userProfile)
        {
            if (userProfile == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid data!" });
            }

            try
            {
                var createdUserProfile = await _userService.CreateUserProfileAsync(userProfile);

                if (createdUserProfile == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "User profile creation failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "User profile created successfully!" });
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
        [Route("/api/user/{userId}")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            try
            {
                var userProfile = await _userService.GetUserProfileAsync(userId);

                if (userProfile == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "User profile not found." });
                }

                return Ok(userProfile);
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
        [Route("/api/user/all")]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            try
            {
                var allUserProfiles = await _userService.GetAllUserProfileAsync();

                if (allUserProfiles == null || allUserProfiles.Count == 0)
                {
                    return NotFound(new Response { Status = "Error", Message = "No user profiles found." });
                }

                return Ok(allUserProfiles);
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
        [Route("/api/user/update/{userId}")]
        public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] User updatedDetails)
        {
            if (updatedDetails == null)
            {
                return BadRequest(new Response { Status = "Error", Message = "Invalid data!" });
            }

            try
            {
                var updatedUserProfile = await _userService.UpdateUserProfileAsync(userId, updatedDetails);

                if (updatedUserProfile == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "User profile update failed! Please check the details and try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "User profile updated successfully!" });
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

        [HttpDelete]
        [Route("/api/user/delete/{userId}")]
        public async Task<IActionResult> DeleteUserProfile(int userId)
        {
            try
            {
                var deletedUserProfile = await _userService.DeleteUserProfileAsync(userId);

                if (deletedUserProfile == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = "Error",
                        Message = "User profile deletion failed! Please try again."
                    });
                }

                return Ok(new Response { Status = "Success", Message = "User profile deleted successfully!" });
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
    