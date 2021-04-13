using System;
using System.ComponentModel.DataAnnotations;

namespace FiledPaymentService.DB
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(3)]
        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
