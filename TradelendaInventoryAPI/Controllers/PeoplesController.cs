using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradelendaInventoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {

        public PeoplesController()
        {
            
        }

        [HttpPost]
        public ActionResult AddStores()
        {
            return Ok();
        }
        [HttpGet]
        public ActionResult GetStores()
        {
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteStores()
        {
            return Ok();
        }
        [HttpPut]
        public ActionResult EditStores()
        {

            return Ok();
        }
        [HttpGet]
        public ActionResult GetWarehouse()
        {
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteWarehouse()
        {
            return Ok();
        }
        [HttpPut]
        public ActionResult EditWarehouse()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult AddWarehouse()
        {
            return Ok();
        }
        [HttpGet]
        public ActionResult GetCustomer()
        {
            return Ok();
        }
        [HttpDelete]        
        public ActionResult DeleteCustomer()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult AddCUstomer()
        {
            return Ok();
        }
        [HttpPut]
        public ActionResult EditCustomer()
        {
            return Ok();    
        }
        [HttpGet]
        public ActionResult GetSupplier()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult AddSupplier()
        {
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteSupplier()
        {
            return Ok();
        }
        [HttpPut]
        public ActionResult EditSupplier()
        {
            return Ok();
        }
    }
}
