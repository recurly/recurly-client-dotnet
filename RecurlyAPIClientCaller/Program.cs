using Recurly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurlyAPIClientCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Usage usageRecord = new Usage("38e5273512fc3b75d5a25c41d19b7f42", "TransactionAmountAddOn");

            usageRecord.Amount = 1000;
            usageRecord.MerchantTag = "OrderID: 111-222-333-444";
            DateTime dateTime = DateTime.UtcNow;
            usageRecord.RecordingTimestamp = dateTime;
            usageRecord.UsageTimestamp = dateTime.AddSeconds(-10);

            usageRecord.Create();
            */

            BillingInfo billingInfo = BillingInfo.Get("537945-1");
        }
    }
}
