using FiledPaymentService.Helpers.Validators;
using FiledPaymentService.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FiledPaymentService.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "CreditCardNumber is required")]
        [CreditCardValidator(AcceptedCardTypes = CardType.Visa | CardType.MasterCard)]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "CardHolder is required")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "ExpirationDate is required")]
        [DateGreaterThanOrEqualToToday]
        public DateTime ExpirationDate { get; set; }

        [StringLength(3)]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
    }
}
