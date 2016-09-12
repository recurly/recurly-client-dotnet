using System;
using FluentAssertions;


namespace Recurly.Test
{
    public class UsageRecordTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void LogUsageRecord()
        {
            var usageRecord = new UsageRecord();

            usageRecord.SubscriptionUuid = "3873a1b40b9568d1defca74b249139e4";
            usageRecord.AddOnCode = "TransactionAmountAddOn";

            usageRecord.Amount = 1000;
            usageRecord.MerchantTag = "OrderID: 111-222-333-444";
            usageRecord.RecordingTimestamp = DateTime.Now.AddHours(-3);
            usageRecord.UsageTimestamp = DateTime.Now;

            UsageRecord usageRecorded = usageRecord.Log();

            usageRecorded.Should().NotBeNull();
        }
    }
}
