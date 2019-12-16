using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }

    public sealed class HomeController : ControllerBase
    {
#if DEBUG
        private const string IndexHtml = "index-dev.html";
#else
        private const string IndexHtml = "index.html";
#endif

        private readonly IWebHostEnvironment _hostingEnvironment;

        private static byte[] GetIndexContent( IWebHostEnvironment hostingEnvironment )
        {
            return System.IO.File.ReadAllBytes( Path.Combine( hostingEnvironment.WebRootPath, IndexHtml ) );
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