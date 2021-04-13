using FiledPaymentService.PaymentProviders.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;

namespace FiledPaymentService.Services.Commands
{
    public class CheapPaymentGatewayCommand : ICommand
    {
        private double _amount = default(double);
        private ICheapPaymentGateway _gateway;


        public CheapPaymentGatewayCommand(double amount, ICheapPaymentGateway gateway)
        {
            _amount = amount;
            _gateway = gateway;
        }

        public bool Execute()
        {
            if (_gateway.IsGatewayAvaibale())
                return _gateway.MakePayment(_amount);
            return false;
        }
    }
}
