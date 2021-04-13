namespace FiledPaymentService.PaymentProviders.Interfaces
{
    public interface IPremiumPaymentGateway
    {
        public bool IsGatewayAvaibale();
        public bool MakePayment(double amount);
    }
}
