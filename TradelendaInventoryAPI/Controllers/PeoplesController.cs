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
        public async Task<ActionResult> AddWarehouse([FromBody]Warehouse warehouse)
        {
            try
            {
                
                var res = await _peoplesService.AddWarehouse(warehouse);
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
        public async Task<ActionResult> AddCustomer([FromBody]Customer customer)
        {
            try
            {
     
                var res = await _peoplesService.AddCustomer(customer);
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
