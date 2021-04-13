using FiledPaymentService.PaymentProviders.Interfaces;

namespace FiledPaymentService.PaymentProviders
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public ExpensivePaymentGateway()
        {
        }

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
