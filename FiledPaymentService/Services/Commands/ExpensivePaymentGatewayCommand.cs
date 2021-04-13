using FiledPaymentService.PaymentProviders.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;

namespace FiledPaymentService.Services.Commands
{
    public class ExpensivePaymentGatewayCommand : ICommand
    {
        private double _amount = default(double);
        private IExpensivePaymentGateway _expensiveGateWay;
        private ICheapPaymentGateway _cheapGateWay;

        public ExpensivePaymentGatewayCommand(double amount, IExpensivePaymentGateway expensivePaymentGateway, ICheapPaymentGateway cheapPaymentGateway)
        {
            _expensiveGateWay = expensivePaymentGateway;
            _cheapGateWay = cheapPaymentGateway;
            _amount = amount;
        }

        public bool Execute()
        {
            // In real implementation make request to expensivePaymentGateway
            if (_expensiveGateWay.IsGatewayAvaibale())
                return _expensiveGateWay.MakePayment(_amount);
            if (_cheapGateWay.IsGatewayAvaibale())
                return _cheapGateWay.MakePayment(_amount);
            return false;
        }
    }
}
