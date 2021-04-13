namespace FiledPaymentService.PaymentProviders.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        public bool IsGatewayAvaibale();
        public bool MakePayment(double amount);
    }
}
