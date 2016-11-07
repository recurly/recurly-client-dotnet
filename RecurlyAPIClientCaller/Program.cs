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

            usageRecord.Create();*/

            DateTime? startDate = null;
            DateTime? endDate = null;

            Invoice invoice = Invoices.Get(1224);
            RecurlyList<Adjustment> adjustments = invoice.Adjustments;
            foreach (var adjustment in adjustments)
            {
                if (adjustment.ProductCode.Equals("EmailRemarketingAddOn"))
                {
                    startDate = adjustment.StartDate;
                    endDate = adjustment.EndDate.Value;
                }
            }

            var usages = Usages.List("390a1cd3ff15493d7683ad4525876178", "EmailRemarketingAddOn",
            Recurly.List.UsageList.UsageBillingState.Billed,
            Recurly.List.UsageList.UsageDateTimeType.Usage,
            startDate,
            endDate);


            long total = 0;
            while (usages.Any())
            {
                Console.WriteLine("Number of records: " + usages.Count);
                foreach (var usage in usages)
                {
                    total += usage.Amount;
                    Console.WriteLine("Usage: " + usage.ToString());
                }
                usages = usages.Next;
            }

            Console.WriteLine($"Total amount: {total}");
            Console.WriteLine("Press <Enter> to finish...");
            Console.ReadLine();
        }
    }
}
