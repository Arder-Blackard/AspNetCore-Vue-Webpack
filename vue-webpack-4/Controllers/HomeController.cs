using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    }

    public sealed class HomeController : ControllerBase
    {
        private const string IndexDevHtml = "index-dev.html";
        private const string IndexHtml = "index.html";

        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController( IWebHostEnvironment hostingEnvironment )
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return File( _hostingEnvironment.IsDevelopment() ? IndexDevHtml : IndexHtml, MediaTypeNames.Text.Html);
        }

        [HttpGet( "hello" )]
        public async Task<IActionResult> GetHelloData()
        {
            return Ok( "Hello123!" );
        }
    }
}