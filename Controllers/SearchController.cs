using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;

namespace MountainTourismBookingSystem.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SearchController(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public JsonResult GetChalets()
        {
            var chalets = (from c in _dbContext.Chalet
                           join t in _dbContext.ChaletType on c.chalet_type equals t.code
                           join r in _dbContext.Region on c.region_type equals r.code
                           join m in _dbContext.Mountain on c.mountain_type equals m.code
                           orderby c.name ascending
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
            if (_signInManager.IsSignedIn(User) == true) 
            { 
                var model = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

                if (model == null) {
                    return View("Index", "Home");
                }

                return View(model);
            }
            else {
                return RedirectToAction("Index", "Home");
            }    
        }
    }
}