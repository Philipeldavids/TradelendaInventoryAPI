﻿using Azure.Core;
using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Infracstructure.DTOs.UserManagementDTOs;
using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
using Microsoft.AspNet.Identity;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Helper;
using Infracstructure.Models.DTO;

namespace BusinessLogic.Services
{
    public class PeoplesService: IPeopleService
    {
        private readonly IPeoplesRepository _peoplesRepository;
        private readonly INotificationService _notificationService;
        private readonly DataLayer.Helper.PasswordHasher _passwordHasher;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public PeoplesService(IPeoplesRepository peoplesRepository, DataLayer.Helper.PasswordHasher passwordHasher,IUserRepository userRepository,INotificationService notificationService, ITokenService tokenService, IUserService userService)
        {
            _peoplesRepository = peoplesRepository;
            _notificationService = notificationService;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _userService = userService;
            _userRepository = userRepository;
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
            var password = GenerateDefaultPassword(12);
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
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            user.UserProfil.PhoneNumber = customer.PhoneNumber;
            user.UserProfil.Address = customer.ShippingAddress;
            user.Description = customer.Description;

            var reg = await _userRepository.AddUserAsync(user);
            //var reg = await _userService.RegisterCustomerUserAsync(user);
            if(reg != true)
            {
                return false;
            }
            await _peoplesRepository.AddCustomer(customer);

            await _notificationService.SendNotificationAsync(
                   user,
                   user.Email,
                   "New User Created",
                   user => $"New User Created for: {user.Email} with role {user.Role.ToString()} You can log in with the password: {password}. Please remember to change your password."
                   );
            
            
            return true;
        }

        public async Task<bool> AddSupplier(Supplier supplier)
        {
            var password = GenerateDefaultPassword(12);
            User user = new User();
            var FirstName = supplier.Name.Split("").Contains(" ") ? supplier.Name.Split(" ")[0] : supplier.Name;
            var LastName = supplier.Name.Split(" ").Contains(" ") ? supplier.Name.Split(" ")[1] : "";
            user.UserProfil.FirstName = FirstName;
            user.UserProfil.LastName = LastName;
            user.UserProfil.UserId = user.UserId;
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.Email = supplier.Email;
            user.UserName = supplier.Email;
            user.Role = Roles.ShopOwner;
            user.PasswordHash = _passwordHasher.HashPassword(user,password); 
            user.UserProfil.PhoneNumber = supplier.PhoneNumber;
            user.UserProfil.Address = supplier.Address +" "+ supplier.City+", "+supplier.Country;
            user.Description = supplier.Description;

            var reg = await _userRepository.AddUserAsync(user);

            if (reg != true)
            { 
                return false;
            }
           var resut = await _peoplesRepository.AddSupplier(supplier);
            if(resut.Success != true)
            {
                return false;
            }

            await _notificationService.SendNotificationAsync(
                   user,
                   user.Email,
                   "New User Created",
                   user => $"New User Created for: {user.Email} with role {user.Role.ToString()} You can log in with the password: {password}. Please remember to change your password."
                   );
           
          
            return true;
        }

        public async Task<bool> AddWarehouse(WarehouseModel warehouse)
        {
            var result = await _peoplesRepository.AddWarehouse(warehouse);
            
                if (result.Data == false)
                {
                    return false;
                }


                await _notificationService.SendNotificationAsync(
                warehouse,
                        warehouse.Email,
                        "New Warehouse Created",
                        warehouse => $"New Warehouse Created for: {warehouse.Email} with role WarehouseID: {warehouse.WarehouseID} and Warehouse Name: {warehouse.WarehouseName}"
                        );


                return true;

        }

        public async Task<bool> AddStore(Store store)
        {
            
            var result = await _peoplesRepository.AddStore(store);
            if(result == null)
            {
                return false;
            }

            await _notificationService.SendNotificationAsync(
               store,
                       store.Email,
                       "New Warehouse Created",
                       store => $"New Warehouse Created for: {store.Email} with role StoreID: {store.StoreId} and Store Name: {store.StoreName}"
                       );


            return true;
        }
        
    }
}