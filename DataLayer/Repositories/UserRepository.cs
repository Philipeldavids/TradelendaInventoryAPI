//using DataLayer.Interfaces;
//using Infracstructure.Models.UserManagement;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataLayer.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public UserRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<User> GetUserByIdAsync(string userId)
//        {
//            return _context.Users.Find(userId);
//        }

//        public async Task<User> GetUserByUserNameAsync(string username)
//        {
//            return _context.Users.Where(u => u.UserName == username).FirstOrDefault();
//        }

//        public async Task<IEnumerable<User>> GetAllUsersAsync()
//        {
//            return _context.Users.ToList();
//        }

//        public async Task<bool> AddUserAsync(User user)
//        {
//            _context.Users.Add(user);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> UpdateUserAsync(User user)
//        {
//            _context.Users.Update(user);
//            return await _context.SaveChangesAsync() > 0;
//        }

//        public async Task<bool> DeleteUserAsync(User user)
//        {
//            _context.Users.Remove(user);
//            return await _context.SaveChangesAsync() > 0;
//        }
//    }
//}

using DataLayer.Interfaces;
using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return _context.Users.Where(p => p.UserId == userId).FirstOrDefault();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}

