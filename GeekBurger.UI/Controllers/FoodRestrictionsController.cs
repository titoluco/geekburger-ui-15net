using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.UI.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodRestrictionsController : Controller
    {
        FoodRestrictionsToGet foodRestrictions;

        public FoodRestrictionsController()
        {
            foodRestrictions = new FoodRestrictionsToGet() { Processing = true, UserId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955") }; //_mapper.Map<FaceToGet>(face);

        }

        //api/FoodRestrictions
        [HttpPost()]
        public IActionResult PostFoodRestrictions([FromBody] FoodRestrictionsToUpsert foodRestrictionsAdd)
        {
            return CreatedAtRoute("FoodRestrictions",
               new { id = foodRestrictions.UserId },
               foodRestrictions);
        }
    }
}