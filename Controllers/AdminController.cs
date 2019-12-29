using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using Newtonsoft.Json;

namespace MountainTourismBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
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

        public IActionResult Management()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var data = (from c in _dbContext.Chalet
                           join t in _dbContext.ChaletType on c.chalet_type equals t.code
                           join r in _dbContext.Region on c.region_type equals r.code
                           join m in _dbContext.Mountain on c.mountain_type equals m.code
                           select new
                           {
                               c_name = c.name,
                               c_chalet_type = t.description,
                               c_region_type = r.description,
                               c_mountain_type = m.description,
                               c_beds = c.beds,
                               c_id = c.unique_id
                           }).ToList();

            return Json(data);
        }

        [HttpPost]
        public JsonResult GetChaletInfoById(Guid id)
        {
            var data = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

            return Json(data);
        }

        [HttpPost]
        public JsonResult SaveEditChaletData(ChaletModel data)
        {
            if (data.unique_id != Guid.Empty)
            {
                var vData = _dbContext.Chalet.Where(x => x.unique_id == data.unique_id).FirstOrDefault();
                if (vData != null)
                {
                    vData.unique_id =               data.unique_id;
                    vData.dt =                      DateTime.Now;
                    vData.information =             data.information;
                    vData.picture =                 data.picture;
                    vData.location_info =           data.location_info;
                    vData.location_coordinates =    data.location_coordinates;
                    vData.location_map =            data.location_map;
                    vData.altitude =                data.altitude;
                    vData.starting_point =          data.starting_point;
                    vData.owner =                   data.owner;
                    vData.gsm =                     data.gsm;
                    vData.contacts =                data.contacts;
                    vData.routes =                  data.routes;
                    vData.beds =                    data.beds;
                    vData.price =                   data.price;
                    vData.chalet_type =             data.chalet_type;
                    vData.region_type =             data.region_type;
                    vData.mountain_type =           data.mountain_type;
                }
            }
            else
            {
                data.dt = DateTime.Now;
                data.unique_id = Guid.NewGuid();
                _dbContext.Chalet.Add(data);
            }

            _dbContext.SaveChanges();

            return Json(data);
        }

        public IActionResult Delete(Guid id)
        {
            ChaletModel data = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();
            _dbContext.Chalet.Remove(data);
            _dbContext.SaveChanges();

            return Json(data);
        }

        [HttpGet]
        public IActionResult RoleManagement()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                var roles = _dbContext.Roles.ToList();
                return View(roles);
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.role_name
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}