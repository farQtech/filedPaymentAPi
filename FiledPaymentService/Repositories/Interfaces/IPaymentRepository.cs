using FiledPaymentService.Models;
using System.Collections;

namespace FiledPaymentService.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable GetPayment();
        Payment GetPaymentByID(int paymentId);
        void InsertPayment(Payment payment);
        void DeletePayment(int paymentId);
        void UpdatePayment(Payment payment);
        void Save();
    }
}
