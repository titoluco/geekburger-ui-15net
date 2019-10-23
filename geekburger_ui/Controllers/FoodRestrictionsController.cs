using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geekburger_ui.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace geekburger_ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodRestrictionsController : ControllerBase
    {
        public FoodRestrictionsController()
        {
        }

        [HttpPost]
        public void Post(FoodRestrictions foodRestrictions)
        {
            //return null; // CreatedAtAction("GetReceita", new { id = foodRestrictions }, foodRestrictions);
        }
    }
}