using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using AccountState = Recurly.Account.AccountState;
using AdjustmentState = Recurly.Adjustment.AdjustmentState;
using AdjustmentType = Recurly.Adjustment.AdjustmentType;
using CreditCardType = Recurly.BillingInfo.CreditCardType;
using CouponState = Recurly.Coupon.CouponState;
using CouponDiscountType = Recurly.Coupon.CouponDiscountType;
using InvoiceState = Recurly.Invoice.InvoiceState;
using SubscriptionState = Recurly.Subscription.SubscriptionState;

namespace Recurly.Test
{
    public class EnumTest
    {
        [Theory,
        ClassData(typeof(EnumActionData))]
        public void AccountState_gets_written_and_parsed_correctly(Action a)
        {
            a.ShouldNotThrow();
        }

        private static void EnumOperations<T>()
        {
            var states = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            var names = states.Select(x => x.ToString().EnumNameToTransportCase());

            var parsed = names.Select(x => x.ParseAsEnum<T>());

            parsed.Should().BeEquivalentTo(states);
        }

        internal class EnumActionData : IEnumerable<object[]>
        {
            private static readonly Action AccountState = () => EnumOperations<AccountState>();
            private static readonly Action AdjustmentState = () => EnumOperations<AdjustmentState>();
            private static readonly Action AdjustmentType = () => EnumOperations<AdjustmentType>();
            private static readonly Action CreditCardType = () => EnumOperations<CreditCardType>();
            private static readonly Action CouponDiscountType = () => EnumOperations<CouponDiscountType>();
            private static readonly Action CouponState = () => EnumOperations<CouponState>();
            private static readonly Action InvoiceState = () => EnumOperations<InvoiceState>();
            private static readonly Action SubscriptionState = () => EnumOperations<SubscriptionState>();
            private static readonly Action SubscriptionChangeTimeframe = () => EnumOperations<Subscription.ChangeTimeframe>();
            private static readonly Action SubscriptionRefundType = () => EnumOperations<Subscription.RefundType>();

            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { AccountState },
                new object[] { AdjustmentState },
                new object[] { AdjustmentType },
                new object[] { CreditCardType },
                new object[] { CouponDiscountType },
                new object[] { CouponState },
                new object[] { InvoiceState },
                new object[] { SubscriptionState },
                new object[] { SubscriptionChangeTimeframe },
                new object[] { SubscriptionRefundType }
            }; 

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}