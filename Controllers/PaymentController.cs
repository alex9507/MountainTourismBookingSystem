using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using PaypalExpressCheckout.BusinessLogic.Interfaces;
using Stripe;

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

        public PaymentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken, Guid id)
        {
            var vChalet = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

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
                    { "OrderId", "111" },
                    { "Postcode", "LEE111"},
                }
            });

            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Cancel");
            }
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
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