using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.UI.Contract;
using apiUser = Fiap.GeekBurguer.Users.Contract;
using apiStoreCatalog = StoreCatalog.Contract;


namespace GeekBurger.UI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class MockController : Controller
    {
        ProductToGet productToGet;

        public MockController()
        {

        }

        [HttpGet("store")]
        public IActionResult GetStore()
        {
            var store = new StoreToGet()
            {
                StoreId = new Guid("FC7DE87A-741F-4558-93C9-3A14CC3B22E8"),
                Ready = true
            };

            return new OkObjectResult(store);
        }

        [HttpPost("user")]
        public IActionResult postUser([FromBody] apiUser.User user)
        {
            return new OkResult();
        }

        [HttpPost("user/FoodRestrictions")]
        public IActionResult postUserFoodRestrictions([FromBody] apiUser.FoodRestrictions foodRestrictionsAdd)
        {
            return new OkResult();
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var product = new List<apiStoreCatalog.Responses.ProductResponse>();
            product.Add(new apiStoreCatalog.Responses.ProductResponse()
            {
                Name = "Darth Bacon",
                Price = "2.5",
                Image = "hamb1.png",
                Items = new List<apiStoreCatalog.Responses.ItemResponse>(),
                ProductId = new Guid(),
                StoreId = new Guid()
            });

            return new OkObjectResult(product);
        }



    }
}