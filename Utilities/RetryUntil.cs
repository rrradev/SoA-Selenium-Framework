using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Utilities
{
    public static class Retry
    {
        public static void Until(Action action, int retryNumber = 3, int waitInMilliseconds = 500)
        {
            while (retryNumber != 0)
            {
                try
                {
                    action.Invoke();
                }
                catch (RetryException)
                {
                    retryNumber--;
                    Thread.Sleep(waitInMilliseconds);

                    continue;
                }

                break;
            }
        }
    }
}
