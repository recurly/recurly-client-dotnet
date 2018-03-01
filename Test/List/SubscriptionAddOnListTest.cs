using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test.List
{
    public class SubscriptionAddOnListTest : BaseTest
    {
        private const string USD = "USD";
        private const string GBP = "GBP";

        [Fact]
        public void AddAddOnFailsValidationWhenCurrencyDoesNotMatch()
        {
            var account = new Account("1");

            var plan = new Plan(GetMockPlanCode(), "add add on test");
            plan.UnitAmountInCents.Add(USD, 100);
            
            var addOn = plan.NewAddOn("1", "test");
            addOn.UnitAmountInCents.Add(USD, 200);
            addOn.AddOnType = AddOn.Type.Fixed;
            
            var sub = new Subscription(account, plan, GBP);

            Action a = () => sub.AddOns.Add(addOn);
            a.ShouldThrow<ValidationException>()
                .And
                .Message.Should().Be("The given AddOn does not have UnitAmountInCents for the currency of the subscription (GBP).");

        }

        [Fact]
        public void AddAddOnSucceedsWhenCurrencyMatches()
        {
            var account = new Account("1");

            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.UnitAmountInCents.Add(USD, 100);

            var addOn = plan.NewAddOn("1", "test");
            addOn.UnitAmountInCents.Add(USD, 200);
            addOn.AddOnType = AddOn.Type.Fixed;

            var sub = new Subscription(account, plan, USD);

            Action a = () => sub.AddOns.Add(addOn);
            a.ShouldNotThrow<ValidationException>();
        }

        [Fact]
        public void AddAddOnMaintainsData()
        {
            const string addOnCode = "1";

            var account = new Account("1");

            var plan = new Plan(GetMockPlanCode(), GetMockPlanName());
            plan.UnitAmountInCents.Add(USD, 100);

            var addOn = plan.NewAddOn(addOnCode, "test");
            addOn.UnitAmountInCents.Add(USD, 200);
            addOn.AddOnType = AddOn.Type.Fixed;

            var sub = new Subscription(account, plan, USD);

            sub.AddOns.Add(addOn);

            var newAddOn = sub.AddOns.First();
            newAddOn.Should()
                .Match<SubscriptionAddOn>(x => x.AddOnCode == addOnCode)
                .And.Match<SubscriptionAddOn>(x => x.UnitAmountInCents == addOn.UnitAmountInCents[sub.Currency]);
        }
    }
}
