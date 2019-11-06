using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Service;

namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        OrderToGet orderToGet;
        IShowDisplayService _showDisplayService;

        public OrderController(IShowDisplayService showDisplayService)
        {
            orderToGet = new OrderToGet() { OrderId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955"), StoreId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955"), Total = 37.23M }; //_mapper.Map<FaceToGet>(face);
            _showDisplayService = showDisplayService;
        }

        // POST api/order
        [HttpPost()]
        public IActionResult PostOrder([FromBody] OrderToUpsert value)
        {
            _showDisplayService.AddMessageObj<OrderToUpsert>(value);
            _showDisplayService.SendMessagesAsync();

            return CreatedAtRoute("GetFace",
               new { OrderId = orderToGet.OrderId },
               orderToGet);
        }
    }
}