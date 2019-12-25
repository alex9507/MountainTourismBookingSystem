﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using PaypalExpressCheckout.BusinessLogic.Interfaces;
using Stripe;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace MountainTourismBookingSystem.Controllers
{
    public class PaymentController : Controller
    {
        // private readonly IPaypalServices _PaypalServices;
        // 
        // public PaymentController(IPaypalServices paypalServices)
        // {
        //     _PaypalServices = paypalServices;
        // }

        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PaymentController(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var user = User.Identity.GetUserId();
            return View();
        }

        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken, Guid id, Guid dataGuid)
        {
            var vChalet = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

            if (vChalet == null) {
                return RedirectToAction("Cancel");
            }

            var vHelperData = _dbContext.ReservationDataHelper.Where(x => x.unique_id == dataGuid).LastOrDefault();

            if (vHelperData == null) {
                return RedirectToAction("Cancel");
            }

            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions 
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = (long)vChalet.price * 100,
                Description = vChalet.name + " Reservation",
                Currency = "bgn",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"chalet_id",       vChalet.chalet_id.ToString()},
                    {"dt_from",         vHelperData.dt_from.ToString()},
                    {"dt_to",           vHelperData.dt_to.ToString()},
                    {"is_full_day",     vHelperData.is_full_day.ToString()},
                    {"amount",          vHelperData.amount.ToString()},
                    {"currency",        vHelperData.currency},
                    {"people_count",    vHelperData.people_count.ToString()},
                    {"color",           vHelperData.color} 
                }
            });

            if (charge.Status == "succeeded")
            {
                var vReservation = new ReservationModel() 
                {
                    dt                      = DateTime.Now,
                    chalet_id               = vChalet.chalet_id,
                    dt_from                 = vHelperData.dt_from,
                    dt_to                   = vHelperData.dt_to,
                    is_full_day             = vHelperData.is_full_day,
                    status                  = charge.Status,
                    amount                  = vHelperData.amount,
                    currency                = vHelperData.currency,
                    people_count            = vHelperData.people_count,
                    balance_transaction_id  = charge.BalanceTransactionId,
                    color                   = vHelperData.color
                };

                _dbContext.Reservation.Add(vReservation);
                _dbContext.SaveChanges();

                return RedirectToAction("Success");
            }
            else {
                return RedirectToAction("Cancel");
            }
        }

        public IActionResult Success()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Cancel()
        {
            if (_signInManager.IsSignedIn(User) == true) {
                return View();
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult SaveData(ReservationDataHelperModel data)
        {
            _dbContext.ReservationDataHelper.Add(data);
            _dbContext.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult ChangeData(ReservationModel data)
        {
            if (data.reservation_id > 0)
            {
                var v = _dbContext.Reservation.Where(x => x.reservation_id == data.reservation_id).FirstOrDefault();
                if (v != null)
                {
                    v.dt_from = data.dt_from;
                    v.dt_to = data.dt_to;
                    v.is_full_day = data.is_full_day;
                }
                else {
                    return Json(new { success = false });
                }
            }
            else {
                return Json(new { success = false });
            }

            _dbContext.SaveChanges();

            return Json(new { success = true });
        }


        // [HttpPost]
        // public IActionResult CreatePayment()
        // {
        //     var payment = _PaypalServices.CreatePayment(100, "http://localhost:44385/Payment/ExecutePayment", "http://localhost:44385/Payment/Cancel", "sale");
        // 
        //     return new JsonResult(payment);
        // }
        // 
        // [HttpPost]
        // public IActionResult ExecutePayment(string paymentId, string token, string PayerID)
        // {
        //     var payment = _PaypalServices.ExecutePayment(paymentId, PayerID);
        // 
        //     // Hint: You can save the transaction details to your database using payment/buyer info
        // 
        //     return Ok();
        // }
    }
}