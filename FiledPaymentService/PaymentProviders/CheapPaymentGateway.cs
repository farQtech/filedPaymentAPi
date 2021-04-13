using FiledPaymentService.PaymentProviders.Interfaces;

namespace FiledPaymentService.PaymentProviders
{
    public class CheapPaymentGateway : ICheapPaymentGateway
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
