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
    public class FoodRestrictionsController : Controller
    {
        // POST api/foodRestrictions
        /// <summary>
        /// Grava as restrições alimentares.
        /// </summary>
        /// <remarks>
        /// Exemple:
        /// 
        ///     POST api/foodRestrictions
        ///     {
        ///        "Restrictions": ["soy","gluten"],
        ///        "Others": "brocolis",
        ///        "UserId": 1111,
        ///        "RequesterId": 1111 
        ///      }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Uma nova restrição gravada</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public void Post([FromBody] FoodRestrictions value)
        {
        }
    }
}