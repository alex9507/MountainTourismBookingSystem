using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaypalExpressCheckout.BusinessLogic.Interfaces;

namespace MountainTourismBookingSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaypalServices _PaypalServices;

        public PaymentController(IPaypalServices paypalServices)
        {
            _PaypalServices = paypalServices;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePayment()
        {
            var payment = _PaypalServices.CreatePayment(100, "http://localhost:44385/Payment/ExecutePayment", "http://localhost:44385/Payment/Cancel", "sale");

            return new JsonResult(payment);
        }

        [HttpPost]
        public IActionResult ExecutePayment(string paymentId, string token, string PayerID)
        {
            var payment = _PaypalServices.ExecutePayment(paymentId, PayerID);

            // Hint: You can save the transaction details to your database using payment/buyer info

            return Ok();
        }
    }
}