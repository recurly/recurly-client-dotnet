using System;
using Recurly.Resources;
using RestSharp;

namespace Recurly {
  public class Client : BaseClient {
    public new string ApiVersion() { return "v2018-06-06"; }

    public Client(string siteId, string apiKey) : base(siteId, apiKey) {}
  
    /// <summary>
    /// List sites
    /// </summary>
    /// <returns>
    /// A list of sites.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Site> ListSites() {
      var url = $"/sites";
      return MakeRequest<Pager<Site>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a site
    /// </summary>
    /// <returns>
    /// A site.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Site GetSite(string site_id) {
      var url = $"/sites/{site_id}";
      return MakeRequest<Site>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's accounts
    /// </summary>
    /// <returns>
    /// A list of the site's accounts.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Account> ListAccounts(string site_id) {
      var url = $"/sites/{site_id}/accounts";
      return MakeRequest<Pager<Account>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Account CreateAccount(string site_id, AccountCreate body) {
      var url = $"/sites/{site_id}/accounts";
      return MakeRequest<Account>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Account GetAccount(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}";
      return MakeRequest<Account>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Modify an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Account UpdateAccount(string site_id, string account_id, AccountUpdate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}";
      return MakeRequest<Account>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Deactivate an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Account DeactivateAccount(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}";
      return MakeRequest<Account>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's acquisition data
    /// </summary>
    /// <returns>
    /// An account's acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AccountAcquisition GetAccountAcquisition(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/acquisition";
      return MakeRequest<AccountAcquisition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an account's acquisition data
    /// </summary>
    /// <returns>
    /// An account's updated acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AccountAcquisition UpdateAccountAcquisition(string site_id, string account_id, AccountAcquisitionUpdatable body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/acquisition";
      return MakeRequest<AccountAcquisition>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Remove an account's acquisition data
    /// </summary>
    /// <returns>
    /// Acquisition data was succesfully deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public void RemoveAccountAcquisition(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/acquisition";
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// Reactivate an inactive account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Account ReactivateAccount(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/reactivate";
      return MakeRequest<Account>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's balance and past due status
    /// </summary>
    /// <returns>
    /// An account's balance.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AccountBalance GetAccountBalance(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/balance";
      return MakeRequest<AccountBalance>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's billing information
    /// </summary>
    /// <returns>
    /// An account's billing information.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public BillingInfo GetBillingInfo(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/billing_info";
      return MakeRequest<BillingInfo>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Set an account's billing information
    /// </summary>
    /// <returns>
    /// Updated billing information.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public BillingInfo UpdateBillingInfo(string site_id, string account_id, BillingInfoCreate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/billing_info";
      return MakeRequest<BillingInfo>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Remove an account's billing information
    /// </summary>
    /// <returns>
    /// Billing information deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public void RemoveBillingInfo(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/billing_info";
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// Show the coupon redemptions for an account
    /// </summary>
    /// <returns>
    /// A list of the the coupon redemptions on an account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<CouponRedemption> ListAccountCouponRedemptions(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/coupon_redemptions";
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Show the coupon redemption that is active on an account
    /// </summary>
    /// <returns>
    /// An active coupon redemption on an account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public CouponRedemption GetActiveCouponRedemption(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/coupon_redemptions/active";
      return MakeRequest<CouponRedemption>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Delete the active coupon redemption from an account
    /// </summary>
    /// <returns>
    /// Coupon redemption deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public CouponRedemption RemoveCouponRedemption(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/coupon_redemptions/active";
      return MakeRequest<CouponRedemption>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List an account's credit payments
    /// </summary>
    /// <returns>
    /// A list of the account's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<CreditPayment> ListAccountCreditPayments(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/credit_payments";
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an account's invoices
    /// </summary>
    /// <returns>
    /// A list of the account's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Invoice> ListAccountInvoices(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/invoices";
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an invoice for pending line items
    /// </summary>
    /// <returns>
    /// Returns the new invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public InvoiceCollection CreateInvoice(string site_id, string account_id, InvoiceCreate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/invoices";
      return MakeRequest<InvoiceCollection>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Preview new invoice for pending line items
    /// </summary>
    /// <returns>
    /// Returns the invoice previews.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public InvoiceCollection PreviewInvoice(string site_id, string account_id, InvoiceCreate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/invoices/preview";
      return MakeRequest<InvoiceCollection>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// List an account's line items
    /// </summary>
    /// <returns>
    /// A list of the account's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<LineItem> ListAccountLineItems(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/line_items";
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new line item for the account
    /// </summary>
    /// <returns>
    /// Returns the new line item.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public LineItem CreateLineItem(string site_id, string account_id, LineItemCreate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/line_items";
      return MakeRequest<LineItem>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's notes
    /// </summary>
    /// <returns>
    /// A list of an account's notes.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<AccountNote> ListAccountNotes(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/notes";
      return MakeRequest<Pager<AccountNote>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an account note
    /// </summary>
    /// <returns>
    /// An account note.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AccountNote GetAccountNote(string site_id, string account_id, string account_note_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/notes/{account_note_id}";
      return MakeRequest<AccountNote>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's shipping addresses
    /// </summary>
    /// <returns>
    /// A list of an account's shipping addresses.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<ShippingAddress> ListShippingAddresses(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/shipping_addresses";
      return MakeRequest<Pager<ShippingAddress>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new shipping address for the account
    /// </summary>
    /// <returns>
    /// Returns the new shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public ShippingAddress CreateShippingAddress(string site_id, string account_id, ShippingAddressCreate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/shipping_addresses";
      return MakeRequest<ShippingAddress>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's shipping address
    /// </summary>
    /// <returns>
    /// A shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public ShippingAddress GetShippingAddress(string site_id, string account_id, string shipping_address_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}";
      return MakeRequest<ShippingAddress>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an account's shipping address
    /// </summary>
    /// <returns>
    /// The updated shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public ShippingAddress UpdateShippingAddress(string site_id, string account_id, string shipping_address_id, ShippingAddressUpdate body) {
      var url = $"/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}";
      return MakeRequest<ShippingAddress>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Remove an account's shipping address
    /// </summary>
    /// <returns>
    /// Shipping address deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public void RemoveShippingAddress(string site_id, string account_id, string shipping_address_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}";
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List an account's subscriptions
    /// </summary>
    /// <returns>
    /// A list of the account's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Subscription> ListAccountSubscriptions(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/subscriptions";
      return MakeRequest<Pager<Subscription>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an account's transactions
    /// </summary>
    /// <returns>
    /// A list of the account's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Transaction> ListAccountTransactions(string site_id, string account_id) {
      var url = $"/sites/{site_id}/accounts/{account_id}/transactions";
      return MakeRequest<Pager<Transaction>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's account acquisition data
    /// </summary>
    /// <returns>
    /// A list of the site's account acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AccountAcquisition ListAccountAcquisition(string site_id) {
      var url = $"/sites/{site_id}/acquisitions";
      return MakeRequest<AccountAcquisition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's coupons
    /// </summary>
    /// <returns>
    /// A list of the site's coupons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Coupon> ListCoupons(string site_id) {
      var url = $"/sites/{site_id}/coupons";
      return MakeRequest<Pager<Coupon>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new coupon
    /// </summary>
    /// <returns>
    /// A new coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Coupon CreateCoupon(string site_id, CouponCreate body) {
      var url = $"/sites/{site_id}/coupons";
      return MakeRequest<Coupon>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch a coupon
    /// </summary>
    /// <returns>
    /// A coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Coupon GetCoupon(string site_id, string coupon_id) {
      var url = $"/sites/{site_id}/coupons/{coupon_id}";
      return MakeRequest<Coupon>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an active coupon
    /// </summary>
    /// <returns>
    /// The updated coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Coupon UpdateCoupon(string site_id, string coupon_id, CouponUpdate body) {
      var url = $"/sites/{site_id}/coupons/{coupon_id}";
      return MakeRequest<Coupon>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// List unique coupon codes associated with a bulk coupon
    /// </summary>
    /// <returns>
    /// A list of unique coupon codes that were generated
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<UniqueCouponCode> ListUniqueCouponCodes(string site_id, string coupon_id) {
      var url = $"/sites/{site_id}/coupons/{coupon_id}/unique_coupon_codes";
      return MakeRequest<Pager<UniqueCouponCode>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's credit payments
    /// </summary>
    /// <returns>
    /// A list of the site's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<CreditPayment> ListCreditPayments(string site_id) {
      var url = $"/sites/{site_id}/credit_payments";
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a credit payment
    /// </summary>
    /// <returns>
    /// A credit payment.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public CreditPayment GetCreditPayment(string site_id, string credit_payment_id) {
      var url = $"/sites/{site_id}/credit_payments/{credit_payment_id}";
      return MakeRequest<CreditPayment>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's custom field definitions
    /// </summary>
    /// <returns>
    /// A list of the site's custom field definitions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<CustomFieldDefinition> ListCustomFieldDefinitions(string site_id) {
      var url = $"/sites/{site_id}/custom_field_definitions";
      return MakeRequest<Pager<CustomFieldDefinition>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an custom field definition
    /// </summary>
    /// <returns>
    /// An custom field definition.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public CustomFieldDefinition GetCustomFieldDefinition(string site_id, string custom_field_definition_id) {
      var url = $"/sites/{site_id}/custom_field_definitions/{custom_field_definition_id}";
      return MakeRequest<CustomFieldDefinition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's invoices
    /// </summary>
    /// <returns>
    /// A list of the site's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Invoice> ListInvoices(string site_id) {
      var url = $"/sites/{site_id}/invoices";
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an invoice
    /// </summary>
    /// <returns>
    /// An invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice GetInvoice(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}";
      return MakeRequest<Invoice>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Collect a pending or past due, automatic invoice
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice CollectInvoice(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/collect";
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Mark an open invoice as failed
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice FailInvoice(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/mark_failed";
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Mark an open invoice as successful
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice MarkInvoiceSuccessful(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/mark_successful";
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Reopen a closed, manual invoice
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice ReopenInvoice(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/reopen";
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// List a invoice's line items
    /// </summary>
    /// <returns>
    /// A list of the invoice's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<LineItem> ListInvoiceLineItems(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/line_items";
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Show the coupon redemptions applied to an invoice
    /// </summary>
    /// <returns>
    /// A list of the the coupon redemptions associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<CouponRedemption> ListInvoiceCouponRedemptions(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/coupon_redemptions";
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an invoice's related credit or charge invoices
    /// </summary>
    /// <returns>
    /// A list of the credit or charge invoices associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Invoice> ListRelatedInvoices(string site_id, string invoice_id) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/related_invoices";
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Refund an invoice
    /// </summary>
    /// <returns>
    /// Returns the new credit invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Invoice RefundInvoice(string site_id, string invoice_id, InvoiceRefund body) {
      var url = $"/sites/{site_id}/invoices/{invoice_id}/refund";
      return MakeRequest<Invoice>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// List a site's line items
    /// </summary>
    /// <returns>
    /// A list of the site's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<LineItem> ListLineItems(string site_id) {
      var url = $"/sites/{site_id}/line_items";
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a line item
    /// </summary>
    /// <returns>
    /// A line item.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public LineItem GetLineItem(string site_id, string line_item_id) {
      var url = $"/sites/{site_id}/line_items/{line_item_id}";
      return MakeRequest<LineItem>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Delete an uninvoiced line item
    /// </summary>
    /// <returns>
    /// Line item deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public void RemoveLineItem(string site_id, string line_item_id) {
      var url = $"/sites/{site_id}/line_items/{line_item_id}";
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a site's plans
    /// </summary>
    /// <returns>
    /// A list of plans.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Plan> ListPlans(string site_id) {
      var url = $"/sites/{site_id}/plans";
      return MakeRequest<Pager<Plan>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Plan CreatePlan(string site_id, PlanCreate body) {
      var url = $"/sites/{site_id}/plans";
      return MakeRequest<Plan>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Plan GetPlan(string site_id, string plan_id) {
      var url = $"/sites/{site_id}/plans/{plan_id}";
      return MakeRequest<Plan>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Plan UpdatePlan(string site_id, string plan_id, PlanUpdate body) {
      var url = $"/sites/{site_id}/plans/{plan_id}";
      return MakeRequest<Plan>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Remove a plan
    /// </summary>
    /// <returns>
    /// Plan deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Plan RemovePlan(string site_id, string plan_id) {
      var url = $"/sites/{site_id}/plans/{plan_id}";
      return MakeRequest<Plan>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List a plan's add-ons
    /// </summary>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<AddOn> ListPlanAddOns(string site_id, string plan_id) {
      var url = $"/sites/{site_id}/plans/{plan_id}/add_ons";
      return MakeRequest<Pager<AddOn>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AddOn CreatePlanAddOn(string site_id, string plan_id, AddOnCreate body) {
      var url = $"/sites/{site_id}/plans/{plan_id}/add_ons";
      return MakeRequest<AddOn>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch a plan's add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AddOn GetPlanAddOn(string site_id, string add_on_id, string plan_id) {
      var url = $"/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}";
      return MakeRequest<AddOn>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AddOn UpdatePlanAddOn(string site_id, string add_on_id, string plan_id, AddOnUpdate body) {
      var url = $"/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}";
      return MakeRequest<AddOn>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Remove an add-on
    /// </summary>
    /// <returns>
    /// Add-on deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AddOn RemovePlanAddOn(string site_id, string add_on_id, string plan_id) {
      var url = $"/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}";
      return MakeRequest<AddOn>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List a site's add-ons
    /// </summary>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<AddOn> ListAddOns(string site_id) {
      var url = $"/sites/{site_id}/add_ons";
      return MakeRequest<Pager<AddOn>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public AddOn GetAddOn(string site_id, string add_on_id) {
      var url = $"/sites/{site_id}/add_ons/{add_on_id}";
      return MakeRequest<AddOn>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's subscriptions
    /// </summary>
    /// <returns>
    /// A list of the site's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Subscription> ListSubscriptions(string site_id) {
      var url = $"/sites/{site_id}/subscriptions";
      return MakeRequest<Pager<Subscription>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription CreateSubscription(string site_id, SubscriptionCreate body) {
      var url = $"/sites/{site_id}/subscriptions";
      return MakeRequest<Subscription>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Fetch a subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription GetSubscription(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}";
      return MakeRequest<Subscription>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Modify a subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription ModifySubscription(string site_id, string subscription_id, SubscriptionUpdate body) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}";
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Terminate a subscription
    /// </summary>
    /// <returns>
    /// An expired subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription TerminateSubscription(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}";
      return MakeRequest<Subscription>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Cancel a subscription
    /// </summary>
    /// <returns>
    /// A canceled or failed subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription CancelSubscription(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/cancel";
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Reactivate a canceled subscription
    /// </summary>
    /// <returns>
    /// An active subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription ReactivateSubscription(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/reactivate";
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Resume subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Subscription ResumeSubscription(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/resume";
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Fetch a subscription's pending change
    /// </summary>
    /// <returns>
    /// A subscription's pending change.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public SubscriptionChange GetSubscriptionChange(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/change";
      return MakeRequest<SubscriptionChange>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new subscription change
    /// </summary>
    /// <returns>
    /// A subscription change.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public SubscriptionChange CreateSubscriptionChange(string site_id, string subscription_id, SubscriptionChangeCreate body) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/change";
      return MakeRequest<SubscriptionChange>(Method.POST, url).Data;
    }
  
    /// <summary>
    /// Delete the pending subscription change
    /// </summary>
    /// <returns>
    /// Subscription change was deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public void RemoveSubscriptionChange(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/change";
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a subscription's invoices
    /// </summary>
    /// <returns>
    /// A list of the subscription's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Invoice> ListSubscriptionInvoices(string site_id, string subscription_id) {
      var url = $"/sites/{site_id}/subscriptions/{subscription_id}/invoices";
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's transactions
    /// </summary>
    /// <returns>
    /// A list of the site's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Pager<Transaction> ListTransactions(string site_id) {
      var url = $"/sites/{site_id}/transactions";
      return MakeRequest<Pager<Transaction>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a transaction
    /// </summary>
    /// <returns>
    /// A transaction.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public Transaction GetTransaction(string site_id, string transaction_id) {
      var url = $"/sites/{site_id}/transactions/{transaction_id}";
      return MakeRequest<Transaction>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public UniqueCouponCode GetUniqueCouponCode(string site_id, string unique_coupon_code_id) {
      var url = $"/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}";
      return MakeRequest<UniqueCouponCode>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Deactivate a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public UniqueCouponCode DeactivateUniqueCouponCode(string site_id, string unique_coupon_code_id) {
      var url = $"/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}";
      return MakeRequest<UniqueCouponCode>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Restore a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</excption>
    public UniqueCouponCode ReactivateUniqueCouponCode(string site_id, string unique_coupon_code_id) {
      var url = $"/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}/restore";
      return MakeRequest<UniqueCouponCode>(Method.PUT, url).Data;
    }
    }
}
