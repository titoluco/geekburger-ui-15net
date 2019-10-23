using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace geekburger_ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceController : Controller
    {
        // POST api/face
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}