//using BusinessLogic.Interfaces;
//using Infracstructure;
//using Infracstructure.DTOs.UserManagementDTOs;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace TradelendaInventoryAPI.Controllers
//{


//        [ApiController]
//        //[Route("api/[controller]")]
//        [Route("api/user-management/[action]")]
//    public class UserManagementController : ControllerBase
//        {
//            private readonly IUserService _userService;

//            public UserManagementController(IUserService userService)
//            {
//                _userService = userService;
//            }

//            // Get all users
//            [HttpGet]
//            [Authorize]
//            public async Task<IActionResult> GetUsers()
//            {
//                var users = await _userService.GetAllUsersAsync();
//                return Ok(users);
//            }

//            // Get user by ID
//            [HttpGet("{id}")]
//            [Authorize]
//            public async Task<IActionResult> GetUser(string id)
//            {
//                var user = await _userService.GetUserByIdAsync(id);
//                if (user == null)
//                {
//                    return NotFound(new { Message = "User not found" });
//                }
//                return Ok(user);
//            }

//                // Create a new user
//            [HttpPost]
//            //[Authorize/*(Roles = "Admin")*/]
//            public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                var result = await _userService.RegisterUserAsync(request);
//                if (!result.Success)
//                {
//                    return BadRequest(result.Errors);
//                }

//                return CreatedAtAction(nameof(GetUser), new { id = result.User.UserId }, result.User);
//            }

//            // Update user details
//            [HttpPut("{id}")]
//            [Authorize]
//            public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserRequestDTO request)
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                var result = await _userService.UpdateUserAsync(id, request);
//                if (!result.Success)
//                {
//                    return BadRequest(result.Errors);
//                }

//                return Ok(result);
//            }

//            // Delete a user
//            [HttpDelete("{id}")]
//            [Authorize]
//            public async Task<IActionResult> DeleteUser(string id)
//            {
//                var result = await _userService.DeleteUserAsync(id);
//                if (!result.Success)
//                {
//                    return BadRequest(result.Errors);
//                }

//                return NoContent();
//            }

//            // Login method to authenticate user and generate tokens
//            [AllowAnonymous]
//            [HttpPost]
//            public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                var result = await _userService.AuthenticateAsync(request.Username, request.Password);
//                if (!result.Success)
//                {
//                    return Unauthorized(result.Errors);
//                }

//                return Ok(new
//                {

//                    Token = result.Token,
//                    RefreshToken = result.RefreshToken
//                });
//            }

//            // Refresh token
//            [AllowAnonymous]
//            [HttpPost]
//            public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
//            {
//                var result = await _userService.RefreshTokenAsync(request.Token, request.RefreshToken);
//                if (!result.Success)
//                {
//                    return Unauthorized(result.Errors);
//                }

//                return Ok(new
//                {
//                    Token = result.Token,
//                    RefreshToken = result.RefreshToken
//                });
//            }

//    }
//}



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

            request.Role = Infracstructure.Models.Roles.Admin;
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

            if (request.SelectRole.Customer == true) request.CreateUserRequest.Role = Infracstructure.Models.Roles.Customer;

            if (request.SelectRole.ShopOwner == true) request.CreateUserRequest.Role = Infracstructure.Models.Roles.ShopOwner;

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

            return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken });
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

