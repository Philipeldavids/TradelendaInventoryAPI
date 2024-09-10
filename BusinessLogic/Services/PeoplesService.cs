using Azure.Core;
using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using Infracstructure.DTOs.UserManagementDTOs;
using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PeoplesService: IPeopleService
    {
        private readonly IPeoplesRepository _peoplesRepository;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public PeoplesService(IPeoplesRepository peoplesRepository, INotificationService notificationService)
        {
            _peoplesRepository = peoplesRepository;
            _notificationService = notificationService;
        }

        public static string GenerateDefaultPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            return password.ToString();

        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            var FirstName = customer.FullName.Split("").Contains(" ") ? customer.FullName.Split(" ")[0] : customer.FullName;
            var LastName = customer.FullName.Split(" ").Contains(" ") ? customer.FullName.Split(" ")[1] : "";
            User user = new User();
            user.UserProfil.FirstName = FirstName;
            user.UserProfil.LastName = LastName;
            user.Email = customer.Email;
            user.UserName = customer.Email;
            user.IsActive = false;
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.Role = Roles.ShopOwner;
            user.UserProfil.UserId = user.UserId;
            user.PasswordHash = GenerateDefaultPassword(12);
            user.UserProfil.PhoneNumber = customer.PhoneNumber;
            user.UserProfil.Address = customer.ShippingAddress;


            var reg = await _userService.RegisterCustomerUserAsync(user);
            if(reg.Success != true)
            {
                return false;
            }
            await _notificationService.SendNotificationAsync(
                   user,
                   user.Email,
                   "New User Created",
                   user => $"New User Created for: {user.Email} with role {user.Role.ToString()} You can log in with the password: {user.PasswordHash}. Please remember to change your password."
                   );
            var result = await _peoplesRepository.AddCustomer(customer);
            if (result.Success != true)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AddSupplier(Supplier supplier)
        {
            User user = new User();
            var FirstName = supplier.Name.Split("").Contains(" ") ? supplier.Name.Split(" ")[0] : supplier.Name;
            var LastName = supplier.Name.Split(" ").Contains(" ") ? supplier.Name.Split(" ")[1] : "";
            user.UserProfil.FirstName = FirstName;
            user.UserProfil.LastName = LastName;
            user.Email = supplier.Email;
            user.Role = Roles.ShopOwner;
            user.PasswordHash = GenerateDefaultPassword(12);
            user.UserProfil.PhoneNumber = supplier.PhoneNumber;
            user.UserProfil.Address = supplier.Country;
            var reg = await _userService.RegisterCustomerUserAsync(user);
            if (reg.Success != true)
            {
                return false;
            }
            await _notificationService.SendNotificationAsync(
                   user,
                   user.Email,
                   "New User Created",
                   user => $"New User Created for: {user.Email} with role {user.Role.ToString()} You can log in with the password: {user.PasswordHash}. Please remember to change your password."
                   );
            var result = await _peoplesRepository.AddSupplier(supplier);
            if (result.Success != true)
            {
                return false;
            }
            return true;
        }
    }
}
