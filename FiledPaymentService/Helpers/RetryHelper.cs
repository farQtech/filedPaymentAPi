using System;

namespace FiledPaymentService.Helpers
{
    public class RetryHelper
    {
        public bool TryNTimes(Action action, int tries = 3)
        {
            while (true)
            {
                try
                {
                    action();
                    break;
                }
                catch
                {
                    if (--tries == 0)
                        throw;
                }
            }
            return tries == 0 ? false : true;
        }
    }
}
