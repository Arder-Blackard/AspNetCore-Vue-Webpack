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
    public class HomeController : ControllerBase
    {
#if DEBUG
        private const string IndexHtml = "index-dev.html";
#else
        private const string IndexHtml = "index.html";
#endif

        private readonly IHostingEnvironment _hostingEnvironment;

        private static readonly object Lock = new object();
        private static volatile byte[] _indexContent;

        private static byte[] GetIndexContent(IHostingEnvironment hostingEnvironment)
        {
            if (_indexContent == null)
            {
                lock (Lock)
                {
                    if (_indexContent == null)
                    {
                        _indexContent = System.IO.File.ReadAllBytes(Path.Combine(hostingEnvironment.WebRootPath, IndexHtml));
                    }
                }
            }
            return _indexContent;
        }

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return File(GetIndexContent(_hostingEnvironment), MediaTypeNames.Text.Html);
        }

    }
}