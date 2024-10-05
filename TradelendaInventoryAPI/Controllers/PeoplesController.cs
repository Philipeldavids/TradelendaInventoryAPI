using BusinessLogic.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Repository;
using Infracstructure.DTOs;
using Infracstructure.Models;
using Infracstructure.Models.DTO;
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
        public async Task<ActionResult> AddStore([FromBody] StoreModel store)
        {
            try
            {
                var res = await _peoplesService.AddStore(store);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpGet]
        public async Task<ActionResult> GetStore()
        {
            try
            {
                var res = await _peoplesRepository.GetStore();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteStore(string Id)
        {
            try
            {
                var res = await _peoplesRepository.DeleteStores(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public async Task<ActionResult> EditStores(Store store, string Id)
        {
            try
            {
                var res = await _peoplesRepository.EditStore(store, Id);
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
        public async Task<ActionResult> AddWarehouse([FromBody] WarehouseModel warehouse)
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
        [HttpDelete("{Id}")]        
        public async Task<ActionResult> DeleteCustomer(string Id)
        {
            try
            {
                var res =await  _peoplesRepository.DeleteCustomer(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody]CustomerModel customer)
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
        public async Task<ActionResult> EditCustomer(Customer customer, string Id)
        {
            try
            {
                var res = await _peoplesRepository.EditCustomer(customer, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet]
        public async Task<ActionResult> GetSupplier()
        {
            try
            {
                var res = await _peoplesRepository.GetSupplier();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public async Task<ActionResult> AddSupplier([FromBody]SupplierModel supplier)
        {
            try
            {
                var res = await _peoplesService.AddSupplier(supplier);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteSupplier(string Id)
        {
            try
            {
                var res =await _peoplesRepository.DeleteSupplier(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut]
        public async Task<ActionResult> EditSupplier(Supplier supplier, string Id)
        {
            try
            {
                var res = await _peoplesRepository.EditSupplier(supplier, Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
