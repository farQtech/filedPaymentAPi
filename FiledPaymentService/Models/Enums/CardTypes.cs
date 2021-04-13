using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledPaymentService.Models.Enums
{
    public enum CardType
    {
        Unknown = 1,
        Visa = 2,
        MasterCard = 4,
        Amex = 8,
        Diners = 16,
        All = CardType.Visa | CardType.MasterCard,
        AllOrUnknown = CardType.Unknown | CardType.Visa | CardType.MasterCard
    }
}
