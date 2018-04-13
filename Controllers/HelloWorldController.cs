using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome(string name, int numtimes = 1)
        {
            ViewData["message"] = "Hello " + name;
            ViewData["NumTimes"] = numtimes;
            return View();
        }

        public string Double(int num = 1)
        {
            int db = num * 2;
            return HtmlEncoder.Default.Encode($"{db}");
        }
    }
}
