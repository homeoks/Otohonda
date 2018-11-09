using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OtoHonda.Models;

namespace OtoHonda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost]
        public IActionResult About([FromForm] LaiThuModel model)
        {
           
            return View(model);
        }
        public IActionResult Laithu()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpPost]
        public IActionResult Laithu([FromForm] LaiThuModel model)
        {
            var a=new MailGrid();
            a.Main("bitwinreward@gmail.com", "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", model);
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
