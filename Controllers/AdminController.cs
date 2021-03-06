﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using Newtonsoft.Json;

namespace MountainTourismBookingSystem.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
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
            if (_signInManager.IsSignedIn(User) == true)
            {
                ChaletModel data = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();
                _dbContext.Chalet.Remove(data);
                _dbContext.SaveChanges();

                return RedirectToAction("Management", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
                    Name = model.Name
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AssignRole()
        {
            ViewBag.Name = new SelectList(_dbContext.Roles.ToList(), "Name", "Name");
            ViewBag.UserName = new SelectList(_dbContext.Users.ToList(), "UserName", "UserName");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AssignRole(ApplicationUser user, RoleModel model)
        {

            var vUser = _dbContext.Users.Where(x => x.UserName == user.UserName).FirstOrDefault();

            if (vUser != null)
            {
                IdentityResult result = await _userManager.AddToRoleAsync(vUser, model.Name);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
                
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ReservationCalendar()
        {
            if (_signInManager.IsSignedIn(User) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ReservationManagement()
        {
            if (_signInManager.IsSignedIn(User) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult GetReservations()
        {
            if (_signInManager.IsSignedIn(User) == true)
            {

                var reservations = (from r in _dbContext.Reservation
                                    join c in _dbContext.Chalet on r.chalet_id equals c.chalet_id
                                    select new
                                    {
                                        reservation_id = r.reservation_id,
                                        dt = r.dt,
                                        chalet_name = c.name,
                                        dt_from = r.dt_from,
                                        dt_to = r.dt_to,
                                        status = r.status,
                                        amount = r.amount,
                                        currency = r.currency,
                                        people_count = r.people_count,
                                        color = r.color,
                                        is_full_day = r.is_full_day
                                    }).ToList();

                if (reservations == null)
                {
                    return View("Index", "Home");
                }

                return Json(reservations);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteReservation(long id)
        {
            if (_signInManager.IsSignedIn(User) == true)
            {
                ReservationModel reservation = _dbContext.Reservation.Where(x => x.reservation_id == id).FirstOrDefault();

                _dbContext.Remove(reservation);
                _dbContext.SaveChanges();

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public JsonResult GetAllReservations()
        {
            var data = (from re in _dbContext.Reservation
                        join c in _dbContext.Chalet on re.chalet_id equals c.chalet_id
                        join t in _dbContext.ChaletType on c.chalet_type equals t.code
                        join r in _dbContext.Region on c.region_type equals r.code
                        join m in _dbContext.Mountain on c.mountain_type equals m.code
                        join u in _dbContext.Users on re.user_id.ToString() equals u.Id
                        select new
                        {
                            c_user_id = re.user_id,
                            c_user_name = u.FirstName + " " + u.LastName,
                            c_name = c.name,
                            c_chalet_type = t.description,
                            c_region_type = r.description,
                            c_mountain_type = m.description,
                            c_date_from = re.dt_from,
                            c_date_to = re.dt_to,
                            c_status = re.status,
                            c_amount = re.amount,
                            c_currency = re.currency,
                            c_id = re.reservation_id
                        }).ToList();

            return Json(data);
        }
    }
}