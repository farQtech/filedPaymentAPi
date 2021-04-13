using FiledPaymentService.PaymentProviders.Interfaces;
using FiledPaymentService.Services.Commands.Interfaces;

namespace FiledPaymentService.Services.Commands
{
    public class Invoker : IInvoker
    {
        ICommand cmd = null;
        private ICheapPaymentGateway _cheapGateway;
        private IExpensivePaymentGateway _expensiveGateWay;
        private IPremiumPaymentGateway _premiumGateway;

        public Invoker(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentGateway premiumPaymentGateway)
        {
            _expensiveGateWay = expensivePaymentGateway;
            _cheapGateway = cheapPaymentGateway;
            _premiumGateway = premiumPaymentGateway;
        }

        public ICommand GetCommand(double amount)
        {
            if (amount < 20) return new CheapPaymentGatewayCommand(amount, _cheapGateway);
            if (amount < 500) return new ExpensivePaymentGatewayCommand(amount, _expensiveGateWay, _cheapGateway);
            return new PremiumPaymentGatewayCommand(amount, _premiumGateway);
        }
    }
}
