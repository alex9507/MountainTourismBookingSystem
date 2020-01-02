using PayPal.Api;

namespace MountainTourismBookingSystem.PayPal.Interfaces
{
    public interface IPaypalServices
    {
        Payment CreatePayment(decimal amount, string returnUrl, string cancelUrl, string intent);

        Payment ExecutePayment(string paymentId, string payerId);
    }
}