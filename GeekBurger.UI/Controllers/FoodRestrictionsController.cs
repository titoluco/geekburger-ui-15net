﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.UI.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using GeekBurger.UI.Contract;
using Newtonsoft.Json;
using GeekBurger.UI.Service;

namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodRestrictionsController : Controller
    {
        private FoodRestrictionsToGet foodRestrictions;
        private IMetodosApi _metodosApi;

        public FoodRestrictionsController(IMetodosApi metodosApi)
        {
            foodRestrictions = new FoodRestrictionsToGet() { Processing = true, UserId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955") }; //_mapper.Map<FaceToGet>(face);
            _metodosApi = metodosApi;
        }

        //api/FoodRestrictions
        [HttpPost()]
        public async Task<IActionResult> PostFoodRestrictions([FromBody] FoodRestrictionsToUpsert foodRestrictionsAdd)
        {

            //await _metodosApi.EnvioPost("http://localhost:50135/Mock/api/FoodRestrictions", JsonConvert.SerializeObject(foodRestrictionsAdd));
            await _metodosApi.EnvioPost("http://geekburgeruser.azurewebsites.net/api/FoodRestrictions", JsonConvert.SerializeObject(foodRestrictionsAdd));

            return CreatedAtRoute("FoodRestrictions",
               new { id = foodRestrictions.UserId },
               foodRestrictions);
            //TODO post to food restrictions 
        }
    }
}