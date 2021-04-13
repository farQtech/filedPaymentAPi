using FiledPaymentService.DB.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiledPaymentService.DB
{
    public class PaymentStatus
    {
        [Key]
        public int Id { get; set; }

        public PaymentStatuses Status { get; set; }

        public int PaymentId { get; set; }


        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
    }
}
