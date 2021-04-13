using FiledPaymentService.PaymentProviders.Interfaces;

namespace FiledPaymentService.PaymentProviders
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        public bool IsGatewayAvaibale()
        {
            return true;
        }

        public bool MakePayment(double amount)
        {
            return true;
        }
    }
}
