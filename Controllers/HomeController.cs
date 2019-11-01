using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;

namespace MountainTourismBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

        public IActionResult Information()
        {
            ViewData["Message"] = "Информация.";

            var model = _dbContext.Chalet.FirstOrDefault();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// PAYPAL:
// https://medium.com/@pmareke/using-paypal-sdk-with-net-core-full-explanation-66aab76cef66

// https://codepen.io/ericwinton/pen/jqKyyq

// console.log(v.chalet_id);

// var items = context.MyTable.Where(x => x.Id == id)
//              .Select(x => new
//              {
//                  P1 = table.Prop1,
//                  P2 = table.Prop2
//              });
//
// This will translate into a sql call like:
//
// SELECT p.Prop1, p.Prop2 FROM mytable p WHERE p.Id = id

