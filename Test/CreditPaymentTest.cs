using System;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace Recurly.Test
{
  public class CreditPaymentTest : BaseTest
  {
    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void LookupCreditPayment()
    {
      var collection = CreateNewCollection();
      var transactionUuid = collection.ChargeInvoice.Transactions[0].Uuid;
      var cancelledCollection = Purchase.Cancel(transactionUuid);
      var creditPaymentUuid = CreditPayments.List(FilterCriteria.Instance.WithSort(FilterCriteria.Sort.CreatedAt)).First().Uuid;
      var creditPayment = CreditPayments.Get(creditPaymentUuid);
      Assert.Equal(creditPayment.AmountInCents, 630);
    }
  }
}
