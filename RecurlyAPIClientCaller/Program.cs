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
            Usage usageRecord = new Usage("38b61e18e80c29d561d7004f85a22810", "TransactionAmountAddOn");

            usageRecord.Amount = 1000;
            usageRecord.MerchantTag = "OrderID: 111-222-333-444";
            usageRecord.RecordingTimestamp = DateTime.UtcNow;
            usageRecord.UsageTimestamp = DateTime.UtcNow.AddSeconds(-10);

            usageRecord.Create();
        }
    }
}
