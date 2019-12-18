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
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(Guid id)
        {
            var model = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

            if (model == null) {
                return View("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult GetReservations(Guid unique_id)
        {
            ViewData["Message"] = "Информация.";

            var reservations = (from r in _dbContext.Reservation
                                join c in _dbContext.Chalet on  r.chalet_id equals c.chalet_id
                                where c.unique_id == unique_id
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

            if (reservations == null) {
                return View("Index", "Home");
            }

            return Json(reservations);
        }
    }
}