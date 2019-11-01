using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using Newtonsoft.Json;

namespace MountainTourismBookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Търсене";

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
                               name = c.name,
                               picture = c.picture,
                               chalet_type = t.description,
                               region_type = r.description,
                               mountain_type = m.description,
                               beds = c.beds
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
                               name = c.name,
                               picture = c.picture,
                               chalet_type = t.description,
                               region_type = r.description,
                               mountain_type = m.description,
                               beds = c.beds
                           }).ToList();

            return Json(chalets);
        }
    }
}