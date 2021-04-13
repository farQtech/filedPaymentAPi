namespace FiledPaymentService.PaymentProviders.Interfaces
{
    public interface ICheapPaymentGateway
    {
        public bool IsGatewayAvaibale();
        public bool MakePayment(double amount);
    }
}
