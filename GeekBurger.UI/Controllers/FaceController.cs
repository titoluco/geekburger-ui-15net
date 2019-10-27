using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekBurger.UI.Contract;
//using GeekBurger.UI.Contract;
using Microsoft.AspNetCore.Mvc;


namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : Controller
    {
        private IMapper _mapper;

        FaceToGet faceToGet;

        public FaceController()
        {
            faceToGet = new FaceToGet() { Processing = true, UserId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955") }; //_mapper.Map<FaceToGet>(face);

        }

        // POST api/face
        [HttpPost()]
        public IActionResult PostFace([FromBody] FaceToUpsert face)
        {
            //var faceToGet = new FaceToGet() { Processing = true, UserId = "2840b416-6bef-48fc-ac64-0db3df117955" }; //_mapper.Map<FaceToGet>(face);

            return CreatedAtRoute("GetFace",
                new { id = faceToGet.UserId },
                faceToGet);
        }
    }
}