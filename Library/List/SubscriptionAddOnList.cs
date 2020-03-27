using System.Xml;

namespace Recurly
{
    public class SubscriptionAddOnList : RecurlyList<SubscriptionAddOn>
    {
        private Subscription _subscription;

        public SubscriptionAddOnList() {}

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

        public override bool includeEmptyTag()
        {
            return true;
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

        /// <summary>
        /// Adds the given <see cref="T:Recurly.AddOn"/> to the current Subscription.
        /// 
        /// Sample usage:
        /// <code>
        /// sub.AddOns.Add(planAddOn, quantity, unitInCents)
        /// sub.AddOns.Add(planAddOn, quantity) // unitInCents = planAddOn.UnitAmountInCents[this.Currency]
        /// sub.AddOns.Add(planAddOn) // default quantity = 1, unitInCents = planAddOn.UnitAmountInCents[this.Currency]
        /// </code>
        /// </summary>
        /// <param name="planAddOn">The <see cref="T:Recurly.AddOn"/> to add to the current Subscription.</param>
        /// <param name="quantity">The quantity of the add-on. Optional, default is 1.</param>
        public void Add(AddOn planAddOn, int quantity = 1)
        {
            int amount = 0;

            if (_subscription == null)
            {
                throw new ValidationException(
                    "SubscriptionAddOnList must be initialized with a Subscription in order to use this method. Try Add(AddOn planAddOn, int quantity, int unitAmountInCents) instead."
                    , new Errors());
            }

            if (planAddOn.UnitAmountInCents.Count > 0 && !planAddOn.UnitAmountInCents.TryGetValue(_subscription.Currency, out amount))
            {
                throw new ValidationException(
                    "The given AddOn does not have UnitAmountInCents for the currency of the subscription (" + _subscription.Currency + ")."
                    , new Errors());
            }
            int? unitAmountInCents = planAddOn.AddOnType.HasValue && (planAddOn.AddOnType.Value == AddOn.Type.Usage) ? (int?)null : amount;

            var sub = new SubscriptionAddOn(planAddOn.AddOnCode, planAddOn.AddOnType, unitAmountInCents, quantity);
            base.Add(sub);
        }

        /// <summary>
        /// Adds the given <see cref="T:Recurly.AddOn"/> to the current Subscription.
        /// 
        /// Sample usage:
        /// <code>
        /// sub.AddOns.Add(planAddOn, quantity, unitInCents)
        /// sub.AddOns.Add(planAddOn, quantity) // unitInCents = planAddOn.UnitAmountInCents[this.Currency]
        /// sub.AddOns.Add(planAddOn) // default quantity = 1, unitInCents = planAddOn.UnitAmountInCents[this.Currency]
        /// </code>
        /// </summary>
        /// <param name="planAddOn">The <see cref="T:Recurly.AddOn"/> to add to the current Subscription.</param>
        /// <param name="quantity">The quantity of the add-on. Optional, default is 1.</param>
        /// <param name="unitAmountInCents">Overrides the UnitAmountInCents of the add-on.</param>
        public void Add(AddOn planAddOn, int quantity, int unitAmountInCents)
        {
            var sub = new SubscriptionAddOn(planAddOn.AddOnCode, planAddOn.AddOnType, unitAmountInCents, quantity);
            base.Add(sub);
        }

        /// <summary>
        /// Adds the given tiered-pricing <see cref="T:Recurly.AddOn"/> to the current Subscription.
        /// 
        /// Sample usage:
        /// <code>
        /// sub.AddOns.Add(planAddOn, tierType, quantity)
        /// sub.AddOns.Add(planAddOn, tierType) // default quantity = 1
        /// </code>
        /// </summary>
        /// <param name="planAddOn">The <see cref="T:Recurly.AddOn"/> to add to the current Subscription.</param>
        /// <param name="tierType">The add-on tier-type.</param>
        /// <param name="quantity">The quantity of the add-on. Optional, default is 1.</param>

        public void Add(AddOn planAddOn, string tierType, int quantity)
        {
            var sub = new SubscriptionAddOn(planAddOn.AddOnCode, tierType, quantity);
            base.Add(sub);
        }

        // sub.AddOns.Add(code, quantity, unitInCents);
        // sub.AddOns.Add(code, quantity); unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        // sub.AddOns.Add(code); 1, unitInCents=this.Plan.UnitAmountInCents[this.Currency]
        public void Add(string planAddOnCode, int quantity=1)
        {
            if (_subscription == null)
            {
                throw new ValidationException(
                    "SubscriptionAddOnList must be initialized with a Subscription in order to use this method. Try Add(string planAddOnCode, int quantity, int unitAmountInCents) instead."
                    , new Errors());
            }
            var unitAmount = _subscription.Plan.AddOns.Find(ao => ao.AddOnCode == planAddOnCode).UnitAmountInCents[_subscription.Currency];
            var sub = new SubscriptionAddOn(planAddOnCode, unitAmount, quantity);
            base.Add(sub);
        }

        public void Add(string planAddOnCode, AddOn.Type addOnType, int quantity = 1)
        {
            if (_subscription == null)
            {
                throw new ValidationException(
                    "SubscriptionAddOnList must be initialized with a Subscription in order to use this method. Try Add(string planAddOnCode, AddOn.Type addOnType, int quantity, int unitAmountInCents) instead."
                    , new Errors());
            }
            var unitAmount = _subscription.Plan.AddOns.Find(ao => ao.AddOnCode == planAddOnCode).UnitAmountInCents[_subscription.Currency];
            var sub = new SubscriptionAddOn(planAddOnCode, addOnType, unitAmount, quantity);
            base.Add(sub);
        }

        public void Add(string planAddOnCode, int quantity, int unitAmountInCents)
        {
            var sub = new SubscriptionAddOn(planAddOnCode, unitAmountInCents, quantity);
            base.Add(sub);
        }

        public void Add(string planAddOnCode, AddOn.Type addOnType, int quantity, int unitAmountInCents)
        {
            var sub = new SubscriptionAddOn(planAddOnCode, addOnType, unitAmountInCents, quantity);
            base.Add(sub);
        }
    }
}
