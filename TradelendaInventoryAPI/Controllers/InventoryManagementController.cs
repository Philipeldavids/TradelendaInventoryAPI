using BusinessLogic.Services;
using DataLayer.Interfaces;
using Infracstructure.Models;
using Infracstructure.Models.DTO;
using Infracstructure.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("AddBRAND")]

        public async Task<IActionResult> AddBrand([FromBody]BrandDTO brand)
        {
            try
            {
                var result = await _inventoryManagementRepository.AddBrand(brand);
                return Ok(result);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand()
        {
            try
            {
                var result = await _inventoryManagementRepository.GetBrand();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteBrand/{Id}")]
        public async Task<IActionResult> DeleteBrand(string Id)
        {
            try
            {
                var result = await _inventoryManagementRepository.DeleteBrand(Id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditBrand")]
        public async Task<IActionResult> EditBrand(string Id, Brand brand)
        {
            try
            {
                var res =await  _inventoryManagementRepository.EditBrand(Id, brand);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCategory")]

        public async Task<ActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var res = await _inventoryManagementRepository.AddCategory(categoryDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditCategory")]
        
        public async Task<ActionResult> EditCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var res = await _inventoryManagementRepository.EditCategory(categoryDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GEtCategoryByID/{Id}")]

        public async Task<ActionResult> GetCategoryById(string Id)
        {
            try
            {
                var res = await _inventoryManagementRepository.GetCategoryById(Id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]

        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var res = await _inventoryManagementRepository.DeleteCategory(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Getcategeory")]

        public async Task<ActionResult> GetCategory()
        {
            try
            {
                var res = await _inventoryManagementRepository.GetGategoryList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("GetProducts")]

        public async Task<ActionResult> GetProducts(int pageSize, int pageNumber)
        {
            try
            {
                var res = await _inventoryManagementService.GetProducts(pageSize, pageNumber);
                return Ok(res);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetProductsByID")]
        public async Task<ActionResult> GetProductsById(string id, int pageSize, int pageNumber)
        {
            try
            {
                var res= await _inventoryManagementService.GetProductByID(id, pageSize, pageNumber);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("EditProduct")]
        public async Task<ActionResult> EditProduct(Product product, string id) 
        {
            try
            {
                var res = await _inventoryManagementService.EditProduct(product, id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteProduct/{Id}")]
        public async Task<ActionResult> DeleteProduct(string Id)
        {
            try
            {
                var res = await _inventoryManagementService.DeleteProduct(Id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody]ProductModel product)
        {
            try
            {
                
                var res = await _inventoryManagementService.AddProducts(product);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetLowStockProduct")]

        public async Task<ActionResult> GetLowStockProduct() 
        {
            try
            {
                var products = await _inventoryManagementRepository.GetLOwStockProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNoStockProducts")]

        public async Task<ActionResult> GetNoStockProducts()
        {
            try
            {
                var products = await _inventoryManagementRepository.GetNoStockProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GEtREcentProducts")]
        public async Task<ActionResult> GEtREcentProducts()
        {
            try
            {
                var products = await _inventoryManagementRepository.GetRecentProducts();
                return Ok(products);
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetExpiredProduct")]
        public async Task<ActionResult> GetExpiredProduct()
        {
            try
            {
                var products = await _inventoryManagementRepository.GetExpiredProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
