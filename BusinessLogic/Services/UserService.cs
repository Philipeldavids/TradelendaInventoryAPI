using BusinessLogic.Interfaces;
using DataLayer;
using DataLayer.Helper;
using DataLayer.Interfaces;
using DataLayer.Services;
using Infracstructure.DTOs.UserManagementDTOs;
using Infracstructure.Models.UserManagement;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, PasswordHasher passwordHasher, TokenService tokenService, ApplicationDbContext context, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _context = context;
            _configuration = configuration;
        }

        public async Task<(bool Success, User User, IEnumerable<string> Errors)> RegisterUserAsync(CreateUserRequestDTO request)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                RefreshToken = _tokenService.GenerateRefreshToken()
            };
          
                  
            user.PasswordHash = Encrypt(request.Password);              
            
            var result = await _userRepository.AddUserAsync(user);
            if (!result)
            {
                return (false, null, new[] { "User registration failed" });
            }
            // user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            return (true, user, null);
        }

        public async Task<(bool Success, string Token, string RefreshToken, IEnumerable<string> Errors)> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUserNameAsync(username);
            
            if (user == null || Dencrypt(user.PasswordHash) != password)
            {
                return (false, null, null, new[] { "Invalid username or password" });
            }

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Save refresh token to user or database

            return (true, token, refreshToken, null);
        }

        //public async Task<(bool Success, string Token, string RefreshToken, IEnumerable<string> Errors)> RefreshTokenAsync(string token, string refreshToken)
        //{
        //    // Validate the refresh token and regenerate JWT
        //    // Implement your logic here

        //    return (true, newJwtToken, newRefreshToken, null);
        //}



        public async Task<(bool Success, string Token, string RefreshToken, IEnumerable<string> Errors)> RefreshTokenAsync(string token, string refreshToken)
        {
            // Validate the JWT token
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            if (principal == null)
            {
                return (false, null, null, new[] { "Invalid JWT token." });
            }

            // Get the user from the principal
            var username = principal.Identity.Name;
            var user = await _userRepository.GetUserByUserNameAsync(username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return (false, null, null, new[] { "Invalid or expired refresh token." });
            }

            // Generate a new JWT and Refresh Token
            var newJwtToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            // Update the user's refresh token and expiry time in the database
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(int.Parse(_configuration["Jwt:RefreshTokenLifetimeDays"]));

            var updateResult = await _userRepository.UpdateUserAsync(user);
            if (!updateResult)
            {
                return (false, null, null, new[] { "Failed to update the refresh token." });
            }

            // Return the new tokens
            return (true, newJwtToken, newRefreshToken, null);
        }




        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> UpdateUserAsync(string id, UpdateUserRequestDTO request)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return (false, new[] { "User not found" });
            }

            // Update user properties here
            user.UserName = request.Username;
            user.PasswordHash = Encrypt(request.Password);
            user.Email = request.Email; 

            var result = await _userRepository.UpdateUserAsync(user);
            return result ? (true, null) : (false, new[] { "Update failed" });
        }

        public async Task<(bool Success, IEnumerable<string> Errors)> DeleteUserAsync(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return (false, new[] { "User not found" });
            }

            var result = await _userRepository.DeleteUserAsync(user);
            return result ? (true, null) : (false, new[] { "Delete failed" });
        }

        //========================Two way encryption=============================
        public static string Encrypt(string datastring)
        {
            string encryptData = string.Empty;
            byte[] encode = new byte[datastring.Length];
            encode = Encoding.UTF8.GetBytes(datastring);
            encryptData = Convert.ToBase64String(encode);
            return encryptData;
        }

        public static string Dencrypt(string encryptDatastring)
        {
            string DataDencrypt = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder decoder = encodepwd.GetDecoder();
            byte[] todec_byte = Convert.FromBase64String(encryptDatastring);
            int charcount = decoder.GetCharCount(todec_byte, 0, todec_byte.Length);
            char[] decoded_char = new char[charcount];
            decoder.GetChars(todec_byte, 0, todec_byte.Length, decoded_char, 0);
            DataDencrypt = new string(decoded_char);
            return DataDencrypt;
        }
    }
}
