using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Recurly.Resources {
  public class Subscription : Resource {
  
    
    [DeserializeAs(Name = "account")]
    public AccountMini Account { get; set; }
  
    /// <value>Activated at</value>
    [DeserializeAs(Name = "activated_at")]
    public DateTime? ActivatedAt { get; set; }
  
    /// <value>Add-ons</value>
    [DeserializeAs(Name = "add_ons")]
    public List<SubscriptionAddOn> AddOns { get; set; }
  
    /// <value>Total price of add-ons</value>
    [DeserializeAs(Name = "add_ons_total")]
    public float? AddOnsTotal { get; set; }
  
    /// <value>Whether the subscription renews at the end of its term.</value>
    [DeserializeAs(Name = "auto_renew")]
    public bool? AutoRenew { get; set; }
  
    /// <value>Recurring subscriptions paid with ACH will have this attribute set. This timestamp is used for alerting customers to reauthorize in 3 years in accordance with NACHA rules. If a subscription becomes inactive or the billing info is no longer a bank account, this timestamp is cleared.</value>
    [DeserializeAs(Name = "bank_account_authorized_at")]
    public DateTime? BankAccountAuthorizedAt { get; set; }
  
    /// <value>Canceled at</value>
    [DeserializeAs(Name = "canceled_at")]
    public DateTime? CanceledAt { get; set; }
  
    /// <value>Collection method</value>
    [DeserializeAs(Name = "collection_method")]
    public string CollectionMethod { get; set; }
  
    /// <value>Coupon redemptions</value>
    [DeserializeAs(Name = "coupon_redemptions")]
    public List<CouponRedemptionMini> CouponRedemptions { get; set; }
  
    /// <value>Created at</value>
    [DeserializeAs(Name = "created_at")]
    public DateTime? CreatedAt { get; set; }
  
    /// <value>3-letter ISO 4217 currency code.</value>
    [DeserializeAs(Name = "currency")]
    public string Currency { get; set; }
  
    /// <value>Current billing period ends at</value>
    [DeserializeAs(Name = "current_period_ends_at")]
    public DateTime? CurrentPeriodEndsAt { get; set; }
  
    /// <value>Current billing period started at</value>
    [DeserializeAs(Name = "current_period_started_at")]
    public DateTime? CurrentPeriodStartedAt { get; set; }
  
    /// <value>When the term ends. This is calculated by a plan's interval and `total_billing_cycles` in a term. Subscription changes with a `timeframe=renewal` will be applied on this date.</value>
    [DeserializeAs(Name = "current_term_ends_at")]
    public DateTime? CurrentTermEndsAt { get; set; }
  
    /// <value>The start date of the term when the first billing period starts. The subscription term is the length of time that a customer will be committed to a subscription. A term can span multiple billing periods.</value>
    [DeserializeAs(Name = "current_term_started_at")]
    public DateTime? CurrentTermStartedAt { get; set; }
  
    
    [DeserializeAs(Name = "custom_fields")]
    public List<CustomField> CustomFields { get; set; }
  
    /// <value>Customer notes</value>
    [DeserializeAs(Name = "customer_notes")]
    public string CustomerNotes { get; set; }
  
    /// <value>Expiration reason</value>
    [DeserializeAs(Name = "expiration_reason")]
    public string ExpirationReason { get; set; }
  
    /// <value>Expires at</value>
    [DeserializeAs(Name = "expires_at")]
    public DateTime? ExpiresAt { get; set; }
  
    /// <value>Subscription ID</value>
    [DeserializeAs(Name = "id")]
    public string Id { get; set; }
  
    /// <value>Integer representing the number of days after an invoice's creation that the invoice will become past due. If an invoice's net terms are set to '0', it is due 'On Receipt' and will become past due 24 hours after it’s created. If an invoice is due net 30, it will become past due at 31 days exactly.</value>
    [DeserializeAs(Name = "net_terms")]
    public int? NetTerms { get; set; }
  
    /// <value>Object type</value>
    [DeserializeAs(Name = "object")]
    public string Object { get; set; }
  
    /// <value>Null unless subscription is paused or will pause at the end of the current billing period.</value>
    [DeserializeAs(Name = "paused_at")]
    public DateTime? PausedAt { get; set; }
  
    
    [DeserializeAs(Name = "pending_change")]
    public SubscriptionChange PendingChange { get; set; }
  
    
    [DeserializeAs(Name = "plan")]
    public PlanMini Plan { get; set; }
  
    /// <value>For manual invoicing, this identifies the PO number associated with the subscription.</value>
    [DeserializeAs(Name = "po_number")]
    public string PoNumber { get; set; }
  
    /// <value>Subscription quantity</value>
    [DeserializeAs(Name = "quantity")]
    public int? Quantity { get; set; }
  
    /// <value>The remaining billing cycles in the current term.</value>
    [DeserializeAs(Name = "remaining_billing_cycles")]
    public int? RemainingBillingCycles { get; set; }
  
    /// <value>Null unless subscription is paused or will pause at the end of the current billing period.</value>
    [DeserializeAs(Name = "remaining_pause_cycles")]
    public int? RemainingPauseCycles { get; set; }
  
    /// <value>If `auto_renew=true`, when a term completes, `total_billing_cycles` takes this value as the length of subsequent terms. Defaults to the plan's `total_billing_cycles`.</value>
    [DeserializeAs(Name = "renewal_billing_cycles")]
    public int? RenewalBillingCycles { get; set; }
  
    
    [DeserializeAs(Name = "shipping_address")]
    public ShippingAddress ShippingAddress { get; set; }
  
    /// <value>State</value>
    [DeserializeAs(Name = "state")]
    public string State { get; set; }
  
    /// <value>Estimated total, before tax.</value>
    [DeserializeAs(Name = "subtotal")]
    public float? Subtotal { get; set; }
  
    /// <value>Terms and conditions</value>
    [DeserializeAs(Name = "terms_and_conditions")]
    public string TermsAndConditions { get; set; }
  
    /// <value>The number of cycles/billing periods in a term. When `remaining_billing_cycles=0`, if `auto_renew=true` the subscription will renew and a new term will begin, otherwise the subscription will expire.</value>
    [DeserializeAs(Name = "total_billing_cycles")]
    public int? TotalBillingCycles { get; set; }
  
    /// <value>Trial period ends at</value>
    [DeserializeAs(Name = "trial_ends_at")]
    public DateTime? TrialEndsAt { get; set; }
  
    /// <value>Trial period started at</value>
    [DeserializeAs(Name = "trial_started_at")]
    public DateTime? TrialStartedAt { get; set; }
  
    /// <value>Subscription unit price</value>
    [DeserializeAs(Name = "unit_amount")]
    public float? UnitAmount { get; set; }
  
    /// <value>Last updated at</value>
    [DeserializeAs(Name = "updated_at")]
    public DateTime? UpdatedAt { get; set; }
  
    /// <value>The UUID is useful for matching data with the CSV exports and building URLs into Recurly's UI.</value>
    [DeserializeAs(Name = "uuid")]
    public string Uuid { get; set; }
  
  }
}
