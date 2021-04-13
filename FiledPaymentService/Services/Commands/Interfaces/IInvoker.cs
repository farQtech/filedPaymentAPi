namespace FiledPaymentService.Services.Commands.Interfaces
{
    public interface IInvoker
    {
        public ICommand GetCommand(double amount);
    }
}
