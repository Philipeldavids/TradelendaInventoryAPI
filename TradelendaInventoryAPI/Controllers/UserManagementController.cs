using BusinessLogic.Interfaces;
using Infracstructure.DTOs.UserManagementDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
   
        [Authorize]
        [ApiController]
        //[Route("api/[controller]")]
        [Route("api/user-management/[action]")]
    public class UserManagementController : ControllerBase
        {
            private readonly IUserService _userService;

            public UserManagementController(IUserService userService)
            {
                _userService = userService;
            }

            // Get all users
            [HttpGet]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> GetUsers()
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }

            // Get user by ID
            [HttpGet("{id}")]
            [Authorize(Roles = "Admin,Manager")]
            public async Task<IActionResult> GetUser(Guid id)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new { Message = "User not found" });
                }
                return Ok(user);
            }

            // Create a new user
            [HttpPost]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _userService.RegisterUserAsync(request);
                if (!result.Success)
                {
                    return BadRequest(result.Errors);
                }

                return CreatedAtAction(nameof(GetUser), new { id = result.User.UserId }, result.User);
            }

            // Update user details
            [HttpPut("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequestDTO request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _userService.UpdateUserAsync(id, request);
                if (!result.Success)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result);
            }

            // Delete a user
            [HttpDelete("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteUser(Guid id)
            {
                var result = await _userService.DeleteUserAsync(id);
                if (!result.Success)
                {
                    return BadRequest(result.Errors);
                }

                return NoContent();
            }

            // Login method to authenticate user and generate tokens
            [AllowAnonymous]
            [HttpPost]
            public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _userService.AuthenticateAsync(request.Username, request.Password);
                if (!result.Success)
                {
                    return Unauthorized(result.Errors);
                }

                return Ok(new
                {
                    Token = result.Token,
                    RefreshToken = result.RefreshToken
                });
            }

            // Refresh token
            [AllowAnonymous]
            [HttpPost]
            public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
            {
                var result = await _userService.RefreshTokenAsync(request.Token, request.RefreshToken);
                if (!result.Success)
                {
                    return Unauthorized(result.Errors);
                }

                return Ok(new
                {
                    Token = result.Token,
                    RefreshToken = result.RefreshToken
                });
            }
        
    }
}
