using BusinessLogic.Interfaces;
using DataLayer;
using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SettingsService: ISettingsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public SettingsService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

       // public async Task<bool> UpdateUserProfile(UserProfileDTO userProfileDTO)
       //{    
       //     var user = _userService.GetUserByIdAsync()
       //     _context.UserProfiles.Add(userProfile);

       //}
    }
}
