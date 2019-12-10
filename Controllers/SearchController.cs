using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using Newtonsoft.Json;
using Stripe;

namespace MountainTourismBookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private int amount = 100;
        private readonly ApplicationDbContext _dbContext;

        public SearchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Търсене";
            ViewBag.PaymentAmount = amount;
            return View();
        }

        [HttpGet]
        public JsonResult GetChalets()
        {
            var chalets = (from c in _dbContext.Chalet
                           join t in _dbContext.ChaletType on c.chalet_type equals t.code
                           join r in _dbContext.Region on c.region_type equals r.code
                           join m in _dbContext.Mountain on c.mountain_type equals m.code
                           select new
                           {
                               chalet_id = c.unique_id,
                               name = c.name,
                               picture = c.picture,
                               chalet_type = t.description,
                               region_type = r.description,
                               mountain_type = m.description,
                               beds = c.beds,
                               price = c.price
                           }).ToList();

            return Json(chalets);
        }

        [HttpGet]
        public JsonResult GetTypes()
        {
            var chalet_types = _dbContext.ChaletType.Select(x => new
            {
                x.code,
                x.description
            }).ToList();

            return Json(chalet_types);
        }

        [HttpGet]
        public JsonResult GetRegions()
        {
            var chalet_types = _dbContext.Region.Select(x => new
            {
                x.code,
                x.description
            }).ToList();

            return Json(chalet_types);
        }

        [HttpGet]
        public JsonResult GetMountains()
        {
            var chalet_types = _dbContext.Mountain.Select(x => new
            {
                x.code,
                x.description
            }).ToList();

            return Json(chalet_types);
        }

        [HttpGet]
        public JsonResult Chalets(string strName, string strType, string strRegion, string strMountain)
        {
            var chalets = (from c in _dbContext.Chalet
                           join t in _dbContext.ChaletType on c.chalet_type equals t.code
                           join r in _dbContext.Region on c.region_type equals r.code
                           join m in _dbContext.Mountain on c.mountain_type equals m.code
                           where (!(string.IsNullOrEmpty(strName)) ? c.name == strName : 1 == 1)
                           && (!(string.IsNullOrEmpty(strType)) ? t.code == strType : 1 == 1)
                           && (!(string.IsNullOrEmpty(strRegion)) ? r.code == strRegion : 1 == 1)
                           && (!(string.IsNullOrEmpty(strMountain)) ? m.code == strMountain : 1 == 1)
                           select new
                           {
                               chalet_id = c.unique_id,
                               name = c.name,
                               picture = c.picture,
                               chalet_type = t.description,
                               region_type = r.description,
                               mountain_type = m.description,
                               beds = c.beds,
                               price = c.price
                           }).ToList();

            return Json(chalets);
        }

        public IActionResult Information(Guid id)
        {
            ViewData["Message"] = "Информация.";

            var model = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

            if (model == null)
            {
                return View("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("Product", "RubberDuck");
            Metadata.Add("Quantity", "10");
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = "EUR",
                Description = "Buying 10 rubber ducks",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
                Metadata = Metadata
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            return View();
        }
    }
}