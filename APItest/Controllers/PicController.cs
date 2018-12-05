using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private IHostingEnvironment _env;

        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("/{id}")]
        public IActionResult GetImage(int id)
        {
            var webRoot = _env.WebRootPath;
            var imgPath = Path.Combine(webRoot + "//Pics/shoes-" + id + ".png");
            if(System.IO.File.Exists(imgPath))
            {
                var buffer = System.IO.File.ReadAllBytes(imgPath);
                return File(buffer, "image/png");
            }

            return BadRequest("No image here homie");

        }
    }
}