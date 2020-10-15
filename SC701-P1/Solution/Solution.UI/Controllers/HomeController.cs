using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solution.UI.Models;

namespace Solution.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        //public IActionResult ExportData() 
        //{
        //    FileStream fs = System.IO.File.Open(@"D:\Sample.xlsx", FileMode.Open);
        //    byte[] bytes;
        //    using (MemoryStream tempMs = new MemoryStream())
        //    {
        //        fs.CopyTo(tempMs);
        //        bytes = tempMs.ToArray();
        //        fs.Close();
        //        fs.Dispose();
        //    }

        //    MemoryStream ms = new MemoryStream();
        //    ms.Write(bytes, 0, bytes.Length);

        //    return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Data.xlsx");
        //}

    }
}
