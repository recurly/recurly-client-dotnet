using System;
using System.Collections;
using System.Collections.Generic;
using Recurly.Resources;
using RestSharp;

namespace Recurly {
  public class Client : BaseClient {
    public new string ApiVersion() { return "v2018-10-04"; }

    public Client(string siteId, string apiKey) : base(siteId, apiKey) {}
  
    /// <summary>
    /// List sites
    /// </summary>
    /// <returns>
    /// A list of sites.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Site> ListSites() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites", urlParams);
      return MakeRequest<Pager<Site>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a site
    /// </summary>
    /// <returns>
    /// A site.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Site GetSite() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}", urlParams);
      return MakeRequest<Site>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's accounts
    /// </summary>
    /// <returns>
    /// A list of the site's accounts.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Account> ListAccounts() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/accounts", urlParams);
      return MakeRequest<Pager<Account>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account CreateAccount(AccountCreate body) {
      var urlParams = new Dictionary<string, object>{ { "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts", urlParams);
      return MakeRequest<Account>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account GetAccount(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}", urlParams);
      return MakeRequest<Account>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Modify an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account UpdateAccount(string account_id, AccountUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}", urlParams);
      return MakeRequest<Account>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Deactivate an account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account DeactivateAccount(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}", urlParams);
      return MakeRequest<Account>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's acquisition data
    /// </summary>
    /// <returns>
    /// An account's acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountAcquisition GetAccountAcquisition(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/acquisition", urlParams);
      return MakeRequest<AccountAcquisition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an account's acquisition data
    /// </summary>
    /// <returns>
    /// An account's updated acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountAcquisition UpdateAccountAcquisition(string account_id, AccountAcquisitionUpdatable body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/acquisition", urlParams);
      return MakeRequest<AccountAcquisition>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's acquisition data
    /// </summary>
    /// <returns>
    /// Acquisition data was succesfully deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveAccountAcquisition(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/acquisition", urlParams);
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// Reactivate an inactive account
    /// </summary>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account ReactivateAccount(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/reactivate", urlParams);
      return MakeRequest<Account>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's balance and past due status
    /// </summary>
    /// <returns>
    /// An account's balance.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountBalance GetAccountBalance(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/balance", urlParams);
      return MakeRequest<AccountBalance>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an account's billing information
    /// </summary>
    /// <returns>
    /// An account's billing information.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public BillingInfo GetBillingInfo(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/billing_info", urlParams);
      return MakeRequest<BillingInfo>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Set an account's billing information
    /// </summary>
    /// <returns>
    /// Updated billing information.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public BillingInfo UpdateBillingInfo(string account_id, BillingInfoCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/billing_info", urlParams);
      return MakeRequest<BillingInfo>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's billing information
    /// </summary>
    /// <returns>
    /// Billing information deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveBillingInfo(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/billing_info", urlParams);
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// Show the coupon redemptions for an account
    /// </summary>
    /// <returns>
    /// A list of the the coupon redemptions on an account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CouponRedemption> ListAccountCouponRedemptions(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/coupon_redemptions", urlParams);
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Show the coupon redemption that is active on an account
    /// </summary>
    /// <returns>
    /// An active coupon redemption on an account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public CouponRedemption GetActiveCouponRedemption(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/coupon_redemptions/active", urlParams);
      return MakeRequest<CouponRedemption>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Delete the active coupon redemption from an account
    /// </summary>
    /// <returns>
    /// Coupon redemption deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public CouponRedemption RemoveCouponRedemption(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/coupon_redemptions/active", urlParams);
      return MakeRequest<CouponRedemption>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List an account's credit payments
    /// </summary>
    /// <returns>
    /// A list of the account's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CreditPayment> ListAccountCreditPayments(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/credit_payments", urlParams);
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an account's invoices
    /// </summary>
    /// <returns>
    /// A list of the account's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListAccountInvoices(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an invoice for pending line items
    /// </summary>
    /// <returns>
    /// Returns the new invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public InvoiceCollection CreateInvoice(string account_id, InvoiceCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices", urlParams);
      return MakeRequest<InvoiceCollection>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Preview new invoice for pending line items
    /// </summary>
    /// <returns>
    /// Returns the invoice previews.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public InvoiceCollection PreviewInvoice(string account_id, InvoiceCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices/preview", urlParams);
      return MakeRequest<InvoiceCollection>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// List an account's line items
    /// </summary>
    /// <returns>
    /// A list of the account's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListAccountLineItems(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new line item for the account
    /// </summary>
    /// <returns>
    /// Returns the new line item.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public LineItem CreateLineItem(string account_id, LineItemCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/line_items", urlParams);
      return MakeRequest<LineItem>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's notes
    /// </summary>
    /// <returns>
    /// A list of an account's notes.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AccountNote> ListAccountNotes(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/notes", urlParams);
      return MakeRequest<Pager<AccountNote>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an account note
    /// </summary>
    /// <returns>
    /// An account note.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountNote GetAccountNote(string account_id, string account_note_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "account_note_id", account_note_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/notes/{account_note_id}", urlParams);
      return MakeRequest<AccountNote>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's shipping addresses
    /// </summary>
    /// <returns>
    /// A list of an account's shipping addresses.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<ShippingAddress> ListShippingAddresses(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses", urlParams);
      return MakeRequest<Pager<ShippingAddress>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new shipping address for the account
    /// </summary>
    /// <returns>
    /// Returns the new shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress CreateShippingAddress(string account_id, ShippingAddressCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses", urlParams);
      return MakeRequest<ShippingAddress>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch an account's shipping address
    /// </summary>
    /// <returns>
    /// A shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress GetShippingAddress(string account_id, string shipping_address_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "shipping_address_id", shipping_address_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      return MakeRequest<ShippingAddress>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an account's shipping address
    /// </summary>
    /// <returns>
    /// The updated shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress UpdateShippingAddress(string account_id, string shipping_address_id, ShippingAddressUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "shipping_address_id", shipping_address_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      return MakeRequest<ShippingAddress>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's shipping address
    /// </summary>
    /// <returns>
    /// Shipping address deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveShippingAddress(string account_id, string shipping_address_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id },{ "shipping_address_id", shipping_address_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List an account's subscriptions
    /// </summary>
    /// <returns>
    /// A list of the account's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Subscription> ListAccountSubscriptions(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/subscriptions", urlParams);
      return MakeRequest<Pager<Subscription>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an account's transactions
    /// </summary>
    /// <returns>
    /// A list of the account's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Transaction> ListAccountTransactions(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/transactions", urlParams);
      return MakeRequest<Pager<Transaction>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an account's child accounts
    /// </summary>
    /// <returns>
    /// A list of an account's child accounts.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Account> ListChildAccounts(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/accounts", urlParams);
      return MakeRequest<Pager<Account>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's account acquisition data
    /// </summary>
    /// <returns>
    /// A list of the site's account acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountAcquisition ListAccountAcquisition() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/acquisitions", urlParams);
      return MakeRequest<AccountAcquisition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's coupons
    /// </summary>
    /// <returns>
    /// A list of the site's coupons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Coupon> ListCoupons() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/coupons", urlParams);
      return MakeRequest<Pager<Coupon>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new coupon
    /// </summary>
    /// <returns>
    /// A new coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Coupon CreateCoupon(CouponCreate body) {
      var urlParams = new Dictionary<string, object>{ { "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons", urlParams);
      return MakeRequest<Coupon>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a coupon
    /// </summary>
    /// <returns>
    /// A coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Coupon GetCoupon(string coupon_id) {
      var urlParams = new Dictionary<string, object>{ { "coupon_id", coupon_id } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons/{coupon_id}", urlParams);
      return MakeRequest<Coupon>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an active coupon
    /// </summary>
    /// <returns>
    /// The updated coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Coupon UpdateCoupon(string coupon_id, CouponUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "coupon_id", coupon_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons/{coupon_id}", urlParams);
      return MakeRequest<Coupon>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// List unique coupon codes associated with a bulk coupon
    /// </summary>
    /// <returns>
    /// A list of unique coupon codes that were generated
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<UniqueCouponCode> ListUniqueCouponCodes(string coupon_id) {
      var urlParams = new Dictionary<string, object>{ { "coupon_id", coupon_id } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons/{coupon_id}/unique_coupon_codes", urlParams);
      return MakeRequest<Pager<UniqueCouponCode>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's credit payments
    /// </summary>
    /// <returns>
    /// A list of the site's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CreditPayment> ListCreditPayments() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/credit_payments", urlParams);
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a credit payment
    /// </summary>
    /// <returns>
    /// A credit payment.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public CreditPayment GetCreditPayment(string credit_payment_id) {
      var urlParams = new Dictionary<string, object>{ { "credit_payment_id", credit_payment_id } };
      var url = this.InterpolatePath("/sites/{site_id}/credit_payments/{credit_payment_id}", urlParams);
      return MakeRequest<CreditPayment>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's custom field definitions
    /// </summary>
    /// <returns>
    /// A list of the site's custom field definitions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CustomFieldDefinition> ListCustomFieldDefinitions() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/custom_field_definitions", urlParams);
      return MakeRequest<Pager<CustomFieldDefinition>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an custom field definition
    /// </summary>
    /// <returns>
    /// An custom field definition.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public CustomFieldDefinition GetCustomFieldDefinition(string custom_field_definition_id) {
      var urlParams = new Dictionary<string, object>{ { "custom_field_definition_id", custom_field_definition_id } };
      var url = this.InterpolatePath("/sites/{site_id}/custom_field_definitions/{custom_field_definition_id}", urlParams);
      return MakeRequest<CustomFieldDefinition>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's invoices
    /// </summary>
    /// <returns>
    /// A list of the site's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListInvoices() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an invoice
    /// </summary>
    /// <returns>
    /// An invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice GetInvoice(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}", urlParams);
      return MakeRequest<Invoice>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an invoice
    /// </summary>
    /// <returns>
    /// An invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice PutInvoice(string invoice_id, InvoiceUpdatable body) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Collect a pending or past due, automatic invoice
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice CollectInvoice(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/collect", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Mark an open invoice as failed
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice FailInvoice(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/mark_failed", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Mark an open invoice as successful
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice MarkInvoiceSuccessful(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/mark_successful", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Reopen a closed, manual invoice
    /// </summary>
    /// <returns>
    /// The updated invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice ReopenInvoice(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/reopen", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// List a invoice's line items
    /// </summary>
    /// <returns>
    /// A list of the invoice's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListInvoiceLineItems(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Show the coupon redemptions applied to an invoice
    /// </summary>
    /// <returns>
    /// A list of the the coupon redemptions associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CouponRedemption> ListInvoiceCouponRedemptions(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/coupon_redemptions", urlParams);
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List an invoice's related credit or charge invoices
    /// </summary>
    /// <returns>
    /// A list of the credit or charge invoices associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListRelatedInvoices(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/related_invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Refund an invoice
    /// </summary>
    /// <returns>
    /// Returns the new credit invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice RefundInvoice(string invoice_id, InvoiceRefund body) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/refund", urlParams);
      return MakeRequest<Invoice>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// List a site's line items
    /// </summary>
    /// <returns>
    /// A list of the site's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListLineItems() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a line item
    /// </summary>
    /// <returns>
    /// A line item.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public LineItem GetLineItem(string line_item_id) {
      var urlParams = new Dictionary<string, object>{ { "line_item_id", line_item_id } };
      var url = this.InterpolatePath("/sites/{site_id}/line_items/{line_item_id}", urlParams);
      return MakeRequest<LineItem>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Delete an uninvoiced line item
    /// </summary>
    /// <returns>
    /// Line item deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveLineItem(string line_item_id) {
      var urlParams = new Dictionary<string, object>{ { "line_item_id", line_item_id } };
      var url = this.InterpolatePath("/sites/{site_id}/line_items/{line_item_id}", urlParams);
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a site's plans
    /// </summary>
    /// <returns>
    /// A list of plans.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Plan> ListPlans() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/plans", urlParams);
      return MakeRequest<Pager<Plan>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan CreatePlan(PlanCreate body) {
      var urlParams = new Dictionary<string, object>{ { "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/plans", urlParams);
      return MakeRequest<Plan>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan GetPlan(string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}", urlParams);
      return MakeRequest<Plan>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update a plan
    /// </summary>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan UpdatePlan(string plan_id, PlanUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}", urlParams);
      return MakeRequest<Plan>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove a plan
    /// </summary>
    /// <returns>
    /// Plan deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan RemovePlan(string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}", urlParams);
      return MakeRequest<Plan>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List a plan's add-ons
    /// </summary>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AddOn> ListPlanAddOns(string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons", urlParams);
      return MakeRequest<Pager<AddOn>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn CreatePlanAddOn(string plan_id, AddOnCreate body) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons", urlParams);
      return MakeRequest<AddOn>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a plan's add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn GetPlanAddOn(string add_on_id, string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id },{ "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn UpdatePlanAddOn(string add_on_id, string plan_id, AddOnUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id },{ "plan_id", plan_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an add-on
    /// </summary>
    /// <returns>
    /// Add-on deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn RemovePlanAddOn(string add_on_id, string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id },{ "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List a site's add-ons
    /// </summary>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AddOn> ListAddOns() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/add_ons", urlParams);
      return MakeRequest<Pager<AddOn>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch an add-on
    /// </summary>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn GetAddOn(string add_on_id) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id } };
      var url = this.InterpolatePath("/sites/{site_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's subscriptions
    /// </summary>
    /// <returns>
    /// A list of the site's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Subscription> ListSubscriptions() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions", urlParams);
      return MakeRequest<Pager<Subscription>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription CreateSubscription(SubscriptionCreate body) {
      var urlParams = new Dictionary<string, object>{ { "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions", urlParams);
      return MakeRequest<Subscription>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription GetSubscription(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}", urlParams);
      return MakeRequest<Subscription>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Modify a subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription ModifySubscription(string subscription_id, SubscriptionUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}", urlParams);
      return MakeRequest<Subscription>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Terminate a subscription
    /// </summary>
    /// <returns>
    /// An expired subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription TerminateSubscription(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}", urlParams);
      return MakeRequest<Subscription>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Cancel a subscription
    /// </summary>
    /// <returns>
    /// A canceled or failed subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription CancelSubscription(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/cancel", urlParams);
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Reactivate a canceled subscription
    /// </summary>
    /// <returns>
    /// An active subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription ReactivateSubscription(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/reactivate", urlParams);
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Resume subscription
    /// </summary>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription ResumeSubscription(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/resume", urlParams);
      return MakeRequest<Subscription>(Method.PUT, url).Data;
    }
  
    /// <summary>
    /// Fetch a subscription's pending change
    /// </summary>
    /// <returns>
    /// A subscription's pending change.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public SubscriptionChange GetSubscriptionChange(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/change", urlParams);
      return MakeRequest<SubscriptionChange>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Create a new subscription change
    /// </summary>
    /// <returns>
    /// A subscription change.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public SubscriptionChange CreateSubscriptionChange(string subscription_id, SubscriptionChangeCreate body) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id },{ "body", body } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/change", urlParams);
      return MakeRequest<SubscriptionChange>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Delete the pending subscription change
    /// </summary>
    /// <returns>
    /// Subscription change was deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveSubscriptionChange(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/change", urlParams);
      MakeRequest(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a subscription's invoices
    /// </summary>
    /// <returns>
    /// A list of the subscription's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListSubscriptionInvoices(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's transactions
    /// </summary>
    /// <returns>
    /// A list of the site's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Transaction> ListTransactions() {
      var urlParams = new Dictionary<string, object>{  };
      var url = this.InterpolatePath("/sites/{site_id}/transactions", urlParams);
      return MakeRequest<Pager<Transaction>>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a transaction
    /// </summary>
    /// <returns>
    /// A transaction.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Transaction GetTransaction(string transaction_id) {
      var urlParams = new Dictionary<string, object>{ { "transaction_id", transaction_id } };
      var url = this.InterpolatePath("/sites/{site_id}/transactions/{transaction_id}", urlParams);
      return MakeRequest<Transaction>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public UniqueCouponCode GetUniqueCouponCode(string unique_coupon_code_id) {
      var urlParams = new Dictionary<string, object>{ { "unique_coupon_code_id", unique_coupon_code_id } };
      var url = this.InterpolatePath("/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
      return MakeRequest<UniqueCouponCode>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Deactivate a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public UniqueCouponCode DeactivateUniqueCouponCode(string unique_coupon_code_id) {
      var urlParams = new Dictionary<string, object>{ { "unique_coupon_code_id", unique_coupon_code_id } };
      var url = this.InterpolatePath("/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
      return MakeRequest<UniqueCouponCode>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// Restore a unique coupon code
    /// </summary>
    /// <returns>
    /// A unique coupon code.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public UniqueCouponCode ReactivateUniqueCouponCode(string unique_coupon_code_id) {
      var urlParams = new Dictionary<string, object>{ { "unique_coupon_code_id", unique_coupon_code_id } };
      var url = this.InterpolatePath("/sites/{site_id}/unique_coupon_codes/{unique_coupon_code_id}/restore", urlParams);
      return MakeRequest<UniqueCouponCode>(Method.PUT, url).Data;
    }
    }
}
