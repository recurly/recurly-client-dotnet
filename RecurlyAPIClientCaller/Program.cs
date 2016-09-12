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
            UsageRecord usageRecord = new UsageRecord();

            usageRecord.SubscriptionUuid = "3849d9c3bf6fefdd9ed16d4224b0e8a9";
            usageRecord.AddOnCode = "TransactionAmountAddOn";

            usageRecord.Amount = 1000;
            usageRecord.MerchantTag = "OrderID: 111-222-333-444";
            usageRecord.RecordingTimestamp = DateTime.Now.AddHours(-3);
            usageRecord.UsageTimestamp = DateTime.Now;

            UsageRecord usageRecorded = usageRecord.Log();

        }
    }
}
