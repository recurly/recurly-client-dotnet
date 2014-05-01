using System.Xml;
using System.Collections.Generic;

namespace Recurly
{
    public class SubscriptionAddOnList : RecurlyList<SubscriptionAddOn>
    {
        private Subscription _subscription;

        public SubscriptionAddOnList(Subscription subscription)
        {
            _subscription = subscription;
        }

        public SubscriptionAddOnList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        public override RecurlyList<SubscriptionAddOn> Start
        {
            get { return HasStartPage() ? new SubscriptionAddOnList(StartUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        public override RecurlyList<SubscriptionAddOn> Next
        {
            get { return HasNextPage() ? new SubscriptionAddOnList(NextUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        public override RecurlyList<SubscriptionAddOn> Prev
        {
            get { return HasPrevPage() ? new SubscriptionAddOnList(PrevUrl) : RecurlyList.Empty<SubscriptionAddOn>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "subscription_add_ons" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "subscription_add_on")
                {
                    Add(new SubscriptionAddOn(reader));
                }
            }
        }

        //sub.AddOns.Add(planAddOn, quantity, unitInCents)
        //sub.AddOns.Add(planAddOn, quantity) // unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        //sub.AddOns.Add(planAddOn) // default quantity=1, unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        public void Add(AddOn planAddOn, int quantity=1)
        {
            var unitAmount = _subscription.Plan.UnitAmountInCents[_subscription.Currency];
            var sub = new SubscriptionAddOn(planAddOn.AddOnCode, unitAmount, quantity);
            base.Add(sub);
        }
        public void Add(AddOn planAddOn, int quantity, int unitAmountInCents)
        {
            var sub = new SubscriptionAddOn(planAddOn.AddOnCode, unitAmountInCents, quantity);
            base.Add(sub);
        }

        // sub.AddOns.Add(code, quantity, unitInCents);
        // sub.AddOns.Add(code, quantity); unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        // sub.AddOns.Add(code); 1, unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        public void Add(string planAddOnCode, int quantity=1)
        {
            var unitAmount = _subscription.Plan.UnitAmountInCents[_subscription.Currency];
            var sub = new SubscriptionAddOn(planAddOnCode, unitAmount, quantity);
            base.Add(sub);
        }
        public void Add(string planAddOnCode, int quantity, int unitAmountInCents)
        {
            var sub = new SubscriptionAddOn(planAddOnCode, unitAmountInCents, quantity);
            base.Add(sub);
        }
    }
}
