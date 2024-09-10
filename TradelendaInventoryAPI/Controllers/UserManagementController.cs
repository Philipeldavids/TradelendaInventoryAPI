using BusinessLogic.Interfaces;
using Infracstructure.DTOs.UserManagementDTOs;
using Infracstructure.Models.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]        
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequestDTO request)
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

            return CreatedAtAction(nameof(GetUserById), new { id = result.User.UserId }, result.User);
        }

       

        [HttpPost("RegisterStoreUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterStoreUser([FromBody] RegisterStoreUserRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            var result = await _userService.RegisterUserAsync(request.CreateUserRequest);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetUserById), new { id = result.User.UserId }, result.User);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequestDTO request)
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

            return Ok(new { User= result.user, Token = result.Token, RefreshToken = result.RefreshToken });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            var result = await _userService.RefreshTokenAsync(request.Token, request.RefreshToken);
            if (!result.Success)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.ResetPasswordAsync(model.Email, model.NewPassword);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password reset successfully");
        }

        
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.ForgotPasswordAsync(model.Email);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password reset link sent to email");
        }

        [HttpGet("GetUsers")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPut("UpdateUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequestDTO request)
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

            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }

}

