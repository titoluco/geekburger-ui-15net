using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Service;
using GeekBurger.UI.Model;

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
            ShowDisplayMessage showDisplayMessage = new ShowDisplayMessage();
            showDisplayMessage.Properties = new Dictionary<String, Object>();
            showDisplayMessage.Properties.Add("ServicoEnvio", "GeekBurger.UI");

            showDisplayMessage.Label = "NewOrder";
            showDisplayMessage.Body = value;
            _showDisplayService.AddMessage(showDisplayMessage);
            _showDisplayService.SendMessagesAsync();


            return CreatedAtRoute("GetFace",
               new { OrderId = orderToGet.OrderId },
               orderToGet);
        }
    }
}