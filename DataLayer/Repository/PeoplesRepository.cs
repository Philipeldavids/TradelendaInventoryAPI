using DataLayer.Interfaces;
using Infracstructure;
using Infracstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class PeoplesRepository : IPeoplesRepository
    {
        private readonly ApplicationDbContext _context;

        public PeoplesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       public async Task<ServiceResponse<List<Store>>> GetStore()
        {
          var res = _context.Stores.ToList();
            return new ServiceResponse<List<Store>>()
            {
                Data = res,
                Success = true,
                Message = "Stores list Retrieved succesfully"
            };
        }

        public async Task<ServiceResponse<bool>> AddStore(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
            return new ServiceResponse<bool>() {  
                Data = true,
                Success = true,
                Message = "Store Created successfully"     
            };
        }

        public async Task<ServiceResponse<bool>> EditStore(Store store, string Id)
        {
            var stor = _context.Stores.Where(x=>x.StoreId == Id).FirstOrDefault();

            stor.StoreName = store.StoreName;
            stor.UserName = store.UserName;
            stor.PhoneNumber = store.PhoneNumber;
            stor.Email = store.Email;
            stor.Status = store.Status;

            _context.Stores.Update(stor);
            _context.SaveChanges();
            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true,
                Message = "Store Updated successfully"
            };
        }

        public async Task<ServiceResponse<bool>> Delete(string ID)
        {
            var stor = _context.Stores.Where(x => x.StoreId == ID).FirstOrDefault();

            _context.Stores.Remove(stor);
            _context.SaveChanges();

            return new ServiceResponse<bool>
            {
                Data = true, 
                Success = true,
                Message="Store deleted successfully"
            }
        }
    }
}
