namespace FiledPaymentService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IPaymentRepository Payments { get; }
        public IPaymentStatusRepository PaymentStatuses { get; }
        public void Commit();

    }
}
