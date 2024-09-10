using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using Infracstructure.Models;
using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PeoplesService
    {
        private readonly IPeoplesRepository _peoplesRepository;
       private readonly INotificationService _notificationService;
        public PeoplesService(IPeoplesRepository peoplesRepository, INotificationService notificationService)
        {
            _peoplesRepository = peoplesRepository;
            _notificationService = notificationService;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            User user = new User();
            var FirstName = customer.FullName.Split(' ')[1];
            var LastName = customer.FullName.Split(' ')[0];
            user.UserProfile.FirstName = FirstName;
            user.UserProfile.LastName = LastName;
            user.Email = customer.Email;
            user.UserProfile.PhoneNumber = customer.PhoneNumber;
            user.UserProfile.Address = customer.ShippingAddress;

            var result = await _peoplesRepository.AddCustomer(customer);
            if (result.Success == true)
            {
                //_notificationService.SendNotificationAsync(
                //    user, user.Email, "New User Created", )

            }
            return true;
        }
    }
}
