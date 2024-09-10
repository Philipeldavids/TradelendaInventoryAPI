using DataLayer.Interfaces;
using Infracstructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PeoplesController : ControllerBase
    {

        private readonly IPeoplesRepository _peoplesRepository;
        public PeoplesController(IPeoplesRepository peoplesRepository)
        {
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
        public ActionResult GetWarehouse()
        {
            try
            {
                var res = _peoplesRepository.GetWarehouse();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete]
        public ActionResult DeleteWarehouse(string Id)
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
        
        [HttpPut]
        public ActionResult EditWarehouse(Warehouse warehouse, string Id)
        {
            try
            {
                var res = _peoplesRepository.EditWarehouse(warehouse, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public ActionResult AddWarehouse(Warehouse warehouse)
        {
            try
            {
                var res = _peoplesRepository.AddWarehouse(warehouse);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult GetCustomer()
        {
            try
            {
                var res = _peoplesRepository.GetCustomers();
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
        public ActionResult AddCUstomer(Customer customer)
        {
            try
            {
                var res = _peoplesRepository.AddCustomer(customer);
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
                var res = _peoplesRepository.AddSupplier(supplier);
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
