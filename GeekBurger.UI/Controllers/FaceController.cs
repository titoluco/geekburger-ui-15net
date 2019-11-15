using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Service;
//using GeekBurger.UI.Mock;
using helper = GeekBurger.UI.Helper;
using GeekBurger.UI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeekBurger.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : Controller
    {
        private IMapper _mapper;
        private IMetodosApi _metodosApi;

        FaceToGet faceToGet;

        public FaceController(IMetodosApi metodosApi, IMapper mapper)
        {
            faceToGet = new FaceToGet() { Processing = true, UserId = new Guid("2840b416-6bef-48fc-ac64-0db3df117955") }; //_mapper.Map<FaceToGet>(face);
            _mapper = mapper;
            _metodosApi = metodosApi;
        }

        // POST api/face
        [HttpPost()]
        public async Task<IActionResult> PostFaceAsync([FromBody] FaceToUpsert face)
        {
            //await _userConnector.GetUserFromFace(requestiD);
            //TODO call async post to api/user and return 
            
           // await _metodosApi.PostToApi("http://localhost:50135/Mock/api/user", JsonConvert.SerializeObject(face));
           
            await _metodosApi.EnvioPost("http://geekburgeruser.azurewebsites.net/api/user", JsonConvert.SerializeObject(face));
        
            return Ok(new FoodRestrictionsResponse { RequesterId = face.RequesterId });
        }

        //[HttpPost("teste")]
        //public async Task<IActionResult> PostTesteFaceAsync([FromBody] FaceToUpsert faceToAdd)
        //{
        //    if (faceToAdd == null)
        //        return BadRequest();
        //    var face = _mapper.Map<FaceModel>(faceToAdd);
        //    if (face.RequesterId == Guid.Empty)
        //        return new helper.UnprocessableEntityResult(ModelState);
        //    _faceRepository.Add(face);
        //    _faceRepository.Save();
        //    var productToGet = _mapper.Map<ProductToGet>(face);
        //    return CreatedAtRoute("GetProduct",
        //    new { id = productToGet.ProductId },
        //    productToGet);

        //}
    }
}