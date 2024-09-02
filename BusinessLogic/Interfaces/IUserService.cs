using Infracstructure.DTOs.UserManagementDTOs;
using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<(bool Success, User User, IEnumerable<string> Errors)> RegisterUserAsync(CreateUserRequestDTO request);
        Task<(bool Success, string Token, string RefreshToken, IEnumerable<string> Errors)> AuthenticateAsync(string username, string password);
        Task<(bool Success, string Token, string RefreshToken, IEnumerable<string> Errors)> RefreshTokenAsync(string token, string refreshToken);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<(bool Success, IEnumerable<string> Errors)> UpdateUserAsync(string id, UpdateUserRequestDTO request);
        Task<(bool Success, IEnumerable<string> Errors)> DeleteUserAsync(string id);
    }
}
