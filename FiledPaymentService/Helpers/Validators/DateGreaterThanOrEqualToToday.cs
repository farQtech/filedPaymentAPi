using System;
using System.ComponentModel.DataAnnotations;

namespace FiledPaymentService.Helpers.Validators
{
    public class DateGreaterThanOrEqualToToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name) => "Date value should not be a past date";

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            if (DateTime.Compare(dateValue.Date, DateTime.Now.Date) < 0)
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            return ValidationResult.Success;
        }
    }
}
