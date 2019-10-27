using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        ProductToGet productToGet;

        public ProductsController()
        {
            productToGet = new ProductToGet()
            {
                StoreId = new Guid(""),
                ProductId = new Guid(""),
                Name = "Nome",
                Image = "Image",
                Items = new List<ItemToGet>() { new ItemToGet() { ItemId = new Guid(""), Name = "Name" } },
                Price = 15.3M
            };
        }

        [HttpGet("{StoreName}")]
        public IActionResult GetProduct(string StoreName)
        {
            return CreatedAtRoute("GetFace",
               new { StoreId = productToGet.StoreId },
               productToGet);
        }
    }
}