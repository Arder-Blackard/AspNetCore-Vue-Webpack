using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace vue_webpack_4.Controllers
{
    [Route("api")]
    public sealed class ApiController : ControllerBase
    {
        [HttpGet("echo")]
        public async Task<IActionResult> GetEcho([FromQuery]string input)
        {
            return Ok( "echo: " + input );
        }

        [HttpGet("get404")]
        public async Task<IActionResult> Get404([FromQuery]string input)
        {
            return NotFound("Whoops!");
        }
    }

    public sealed class HomeController : ControllerBase
    {
        private const string IndexDevHtml = "index-dev.html";
        private const string IndexHtml = "index.html";

        private readonly IWebHostEnvironment _hostingEnvironment;

        private static byte[] GetIndexContent( IWebHostEnvironment env )
        {
            return System.IO.File.ReadAllBytes( Path.Combine( env.WebRootPath, env.IsDevelopment() ? IndexDevHtml : IndexHtml  ) );
        }

        public HomeController( IWebHostEnvironment hostingEnvironment )
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return File(GetIndexContent(_hostingEnvironment), MediaTypeNames.Text.Html);
        }

        [HttpGet( "hello" )]
        public async Task<IActionResult> GetHelloData()
        {
            return Ok( "Hello123!" );
        }
    }
}