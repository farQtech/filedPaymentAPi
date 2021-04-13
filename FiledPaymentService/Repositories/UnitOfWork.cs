using FiledPaymentService.Repositories.Interfaces;

namespace FiledPaymentService.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPaymentRepository _payments;
        private IPaymentStatusRepository _paymentStatuses;

        public UnitOfWork(IPaymentRepository payments, IPaymentStatusRepository paymentStatusRepository)
        {
            _payments = payments;
            _paymentStatuses = paymentStatusRepository;
        }

        public IPaymentRepository Payments => _payments;

        public IPaymentStatusRepository PaymentStatuses => _paymentStatuses;

        public void Commit()
        {
            _payments.Save();
        }
    }
}
