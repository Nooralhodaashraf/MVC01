using Microsoft.AspNetCore.Mvc;
using MVC01.Models;

namespace MVC01.Controllers
{
    [Route("prod")]
    public class productController : Controller
    {

        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getProducts()
        {
            var products = new List<product>();
            return View(products);
        }
        #endregion


        #region routing 
        //BaseURL/prod/json 
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("hello Json Action");
        }
        #endregion

        #region ModelBuinding

        public IActionResult search(productFilter filter)
        {
            return View();
        }

        public IActionResult GetById(int Id, [FromQuery(Name ="Id2")] int OtherId)
        {
            return Json("");
        }
        #endregion
    }
}
