using FiledPaymentService.Helpers;
using FiledPaymentService.PaymentProviders.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;

namespace FiledPaymentService.Services.Commands
{
    public class PremiumPaymentGatewayCommand : ICommand
    {
        private double _amount = default(double);
        private IPremiumPaymentGateway _gateway;
        public PremiumPaymentGatewayCommand(double amount, IPremiumPaymentGateway premiumPaymentGateway)
        {
            _amount = amount;
            _gateway = premiumPaymentGateway;
        }
        public bool Execute()
        {
            if (_gateway.IsGatewayAvaibale())
                return new RetryHelper().TryNTimes(() => _gateway.MakePayment(_amount), 3);
            return false;
        }
    }
}
