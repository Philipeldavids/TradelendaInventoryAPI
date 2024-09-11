using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Repository;
using Infracstructure.DTOs;
using Infracstructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class PeoplesController : ControllerBase
    {
        private readonly IPeoplesRepository _peoplesRepository;

        private readonly IPeopleService _peoplesService;
        public PeoplesController(IPeopleService peoplesService, IPeoplesRepository peoplesRepository)
        {
            _peoplesService = peoplesService;
            _peoplesRepository = peoplesRepository;
        }

        
        [HttpPost]
        public ActionResult AddStores(Store store)
        {
            try
            {
                var res = _peoplesRepository.AddStore(store);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
            
        }
        [HttpGet]
        public ActionResult GetStores()
        {
            try
            {
                var res = _peoplesRepository.GetStore();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public ActionResult DeleteStores(string Id)
        {
            try
            {
                var res = _peoplesRepository.DeleteStores(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public ActionResult EditStores(Store store, string Id)
        {
            try
            {
                var res = _peoplesRepository.EditStore(store, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        public async Task<ActionResult> GetWarehouse()
        {
            try
            {
                var res = await _peoplesRepository.GetWarehouse();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteWarehouse(string Id)
        {
            try
            {
                var res = await _peoplesRepository.DeleteWarehouse(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        
        [HttpPut]
        public async Task<ActionResult> EditWarehouse(Warehouse warehouse, string Id)
        {
            try
            {
                var res = await _peoplesRepository.EditWarehouse(warehouse, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public async Task<ActionResult> AddWarehouse([FromBody]CreateWarehouseDTO warehouse)
        {
            try
            {
                Warehouse warehouse1 = new Warehouse();

                warehouse1.ContactPhone = warehouse.WorkPhone;
                warehouse1.Supplier.ContactPerson = warehouse.ContactPerson;
                warehouse1.Supplier.Country = warehouse.Address1 + " | " +warehouse.Address2 + " " + warehouse.City + ", "+ warehouse.State + ", " + warehouse.ZipCode+" "+ warehouse.Country;
                warehouse1.WarehouseName = warehouse.WarehouseName;
                warehouse1.Supplier.PhoneNumber = warehouse.PhoneNumber;
                warehouse1.Supplier.Email = warehouse.Email;

                var res = await _peoplesRepository.AddWarehouse(warehouse1);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
       
        public async Task<ActionResult> GetCustomer()
        {
            try
            {
                var res = await _peoplesRepository.GetCustomers();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]        
        public ActionResult DeleteCustomer(string Id)
        {
            try
            {
                var res = _peoplesRepository.DeleteWarehouse(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody]CustomerRegisterDTO customer)
        {
            try
            {
                Customer customr = new Customer();
                customr.Email = customer.Email;
                customr.PhoneNumber = customer.PhoneNumber;
                customr.FullName = customer.Name;
                customr.ShippingAddress = customer.Address + ", " +customer.City+ ", " + customer.Country;
                customr.Description = customer.Description;
                

                var res = await _peoplesService.AddCustomer(customr);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public ActionResult EditCustomer(Customer customer, string Id)
        {
            try
            {
                var res = _peoplesRepository.EditCustomer(customer, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult GetSupplier()
        {
            try
            {
                var res = _peoplesRepository.GetSupplier();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            try
            {
                var res = _peoplesService.AddSupplier(supplier);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public ActionResult DeleteSupplier(string Id)
        {
            try
            {
                var res = _peoplesRepository.DeleteSupplier(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public ActionResult EditSupplier(Supplier supplier, string Id)
        {
            try
            {
                var res = _peoplesRepository.EditSupplier(supplier, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
