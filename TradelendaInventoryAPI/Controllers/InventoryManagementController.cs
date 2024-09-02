using BusinessLogic.Services;
using DataLayer.Interfaces;
using Infracstructure.Models;
using Infracstructure.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {
        private readonly IInventoryManagementService _inventoryManagementService;
        private readonly IInventoryManagementRepository _inventoryManagementRepository;
        public InventoryManagementController(IInventoryManagementService inventoryManagementService, IInventoryManagementRepository inventoryManagementRepository)
        {
            _inventoryManagementService = inventoryManagementService;
            _inventoryManagementRepository = inventoryManagementRepository;
        }

        [HttpPost("AddCategory")]

        public ActionResult AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var res = _inventoryManagementRepository.AddCategory(categoryDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditCategory")]
        
        public ActionResult EditCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var res = _inventoryManagementRepository.EditCategory(categoryDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory")]

        public ActionResult DeleteCategory(string id)
        {
            try
            {
                var res = _inventoryManagementRepository.DeleteCategory(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Getcategeory")]

        public ActionResult GetCategory()
        {
            try
            {
                var res = _inventoryManagementRepository.GetGategoryList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("GetProducts")]

        public ActionResult GetProducts(int pageSize, int pageNumber)
        {
            try
            {
                var res = _inventoryManagementService.GetProducts(pageSize, pageNumber);
                return Ok(res);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetProductsByID")]
        public ActionResult GetProductsById(string id, int pageSize, int pageNumber)
        {
            try
            {
                var res= _inventoryManagementService.GetProductByID(id, pageSize, pageNumber);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditProduct")]
        public ActionResult EditProduct(Product product, string id) 
        {
            try
            {
                var res = _inventoryManagementService.EditProduct(product, id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(Product product)
        {
            try
            {
                var res = _inventoryManagementService.DeleteProduct(product.ProductId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public ActionResult AddProduct(Product product)
        {
            try
            {
                var res = _inventoryManagementService.AddProducts(product);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
