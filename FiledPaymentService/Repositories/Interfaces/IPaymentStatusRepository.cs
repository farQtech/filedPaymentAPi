using FiledPaymentService.DB;
using System.Collections;

namespace FiledPaymentService.Repositories.Interfaces
{
    public interface IPaymentStatusRepository
    {
        IEnumerable GetPaymentStatus();
        PaymentStatus GetPaymentStatusByID(int paymentId);
        void InsertPaymentStatus(PaymentStatus payment);
        void DeletePaymentStatus(int paymentId);
        void UpdatePaymentStatus(PaymentStatus payment);
        void Save();
    }
}
