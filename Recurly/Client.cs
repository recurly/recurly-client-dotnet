/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Recurly.Resources;
using RestSharp;

namespace Recurly {
  [ExcludeFromCodeCoverage]
  public class Client : BaseClient {
    public override string ApiVersion => "v2018-10-04";

    public Client(string siteId, string apiKey) : base(siteId, apiKey) {}
  
    /// <summary>
    /// List sites
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <returns>
    /// A list of sites.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Site> ListSites(string ids = null, int? limit = null, string order = null, string sort = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort } };
      var url = this.InterpolatePath("/sites", urlParams);
      return MakeRequest<Pager<Site>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch a site
    /// </summary>
    /// <returns>
    /// A site.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Site GetSite() {
      var urlParams = new Dictionary<string, object>{ };
      var url = this.InterpolatePath("/sites/{site_id}", urlParams);
      return MakeRequest<Site>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's accounts
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="subscriber">Filter accounts accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
    /// <param name="past_due">Filter for accounts with an invoice in the `past_due` state.</param>
    /// <returns>
    /// A list of the site's accounts.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Account> ListAccounts(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string subscriber = null, string past_due = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "subscriber", subscriber }, { "past_due", past_due } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts", urlParams);
      return MakeRequest<Pager<Account>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create an account
    /// </summary>
    /// <param name="body"></param>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account CreateAccount(AccountCreate body) {
      var urlParams = new Dictionary<string, object>{ };
      var url = this.InterpolatePath("/sites/{site_id}/accounts", urlParams);
      return MakeRequest<Account>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch an account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// An account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Account UpdateAccount(string account_id, AccountUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}", urlParams);
      return MakeRequest<Account>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Deactivate an account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// An account's updated acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountAcquisition UpdateAccountAcquisition(string account_id, AccountAcquisitionUpdatable body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/acquisition", urlParams);
      return MakeRequest<AccountAcquisition>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's acquisition data
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <returns>
    /// Acquisition data was succesfully deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveAccountAcquisition(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/acquisition", urlParams);
      MakeRequest<object>(Method.DELETE, url);
    }
  
    /// <summary>
    /// Reactivate an inactive account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Updated billing information.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public BillingInfo UpdateBillingInfo(string account_id, BillingInfoCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/billing_info", urlParams);
      return MakeRequest<BillingInfo>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's billing information
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <returns>
    /// Billing information deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveBillingInfo(string account_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/billing_info", urlParams);
      MakeRequest<object>(Method.DELETE, url);
    }
  
    /// <summary>
    /// Show the coupon redemptions for an account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <returns>
    /// A list of the the coupon redemptions on an account.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CouponRedemption> ListAccountCouponRedemptions(string account_id, string ids = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/coupon_redemptions", urlParams);
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Show the coupon redemption that is active on an account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the account's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CreditPayment> ListAccountCreditPayments(string account_id, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/credit_payments", urlParams);
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List an account's invoices
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
    /// <returns>
    /// A list of the account's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListAccountInvoices(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create an invoice for pending line items
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Returns the new invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public InvoiceCollection CreateInvoice(string account_id, InvoiceCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices", urlParams);
      return MakeRequest<InvoiceCollection>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Preview new invoice for pending line items
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Returns the invoice previews.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public InvoiceCollection PreviewInvoice(string account_id, InvoiceCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/invoices/preview", urlParams);
      return MakeRequest<InvoiceCollection>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// List an account's line items
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="original">Filter by original field.</param>
    /// <param name="state">Filter by state field.</param>
    /// <param name="type">Filter by type field.</param>
    /// <returns>
    /// A list of the account's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListAccountLineItems(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string original = null, string state = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "original", original }, { "state", state }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create a new line item for the account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Returns the new line item.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public LineItem CreateLineItem(string account_id, LineItemCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/line_items", urlParams);
      return MakeRequest<LineItem>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's notes
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <returns>
    /// A list of an account's notes.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AccountNote> ListAccountNotes(string account_id, string ids = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/notes", urlParams);
      return MakeRequest<Pager<AccountNote>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch an account note
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="account_note_id">Account Note ID.</param>
    /// <returns>
    /// An account note.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountNote GetAccountNote(string account_id, string account_note_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id }, { "account_note_id", account_note_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/notes/{account_note_id}", urlParams);
      return MakeRequest<AccountNote>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Fetch a list of an account's shipping addresses
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of an account's shipping addresses.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<ShippingAddress> ListShippingAddresses(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses", urlParams);
      return MakeRequest<Pager<ShippingAddress>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create a new shipping address for the account
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Returns the new shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress CreateShippingAddress(string account_id, ShippingAddressCreate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses", urlParams);
      return MakeRequest<ShippingAddress>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch an account's shipping address
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="shipping_address_id">Shipping Address ID.</param>
    /// <returns>
    /// A shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress GetShippingAddress(string account_id, string shipping_address_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id }, { "shipping_address_id", shipping_address_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      return MakeRequest<ShippingAddress>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an account's shipping address
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="shipping_address_id">Shipping Address ID.</param>
    /// <param name="body"></param>
    /// <returns>
    /// The updated shipping address.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingAddress UpdateShippingAddress(string account_id, string shipping_address_id, ShippingAddressUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id }, { "shipping_address_id", shipping_address_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      return MakeRequest<ShippingAddress>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an account's shipping address
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="shipping_address_id">Shipping Address ID.</param>
    /// <returns>
    /// Shipping address deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveShippingAddress(string account_id, string shipping_address_id) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id }, { "shipping_address_id", shipping_address_id } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
      MakeRequest<object>(Method.DELETE, url);
    }
  
    /// <summary>
    /// List an account's subscriptions
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="state">Filter by state.  - When `state=active`, `state=canceled`, `state=expired`, or `state=future`, subscriptions with states that match the query and only those subscriptions will be returned.  - When `state=in_trial`, only subscriptions that have a trial_started_at date earlier than now and a trial_ends_at date later than now will be returned.  - When `state=live`, only subscriptions that are in an active, canceled, or future state or are in trial will be returned.  </param>
    /// <returns>
    /// A list of the account's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Subscription> ListAccountSubscriptions(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string state = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "state", state } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/subscriptions", urlParams);
      return MakeRequest<Pager<Subscription>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List an account's transactions
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="type">Filter by type field. The value `payment` will return both `purchase` and `capture` transactions.</param>
    /// <param name="success">Filter by success field.</param>
    /// <returns>
    /// A list of the account's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Transaction> ListAccountTransactions(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string type = null, string success = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "type", type }, { "success", success } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/transactions", urlParams);
      return MakeRequest<Pager<Transaction>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List an account's child accounts
    /// </summary>
    /// <param name="account_id">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="subscriber">Filter accounts accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
    /// <param name="past_due">Filter for accounts with an invoice in the `past_due` state.</param>
    /// <returns>
    /// A list of an account's child accounts.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Account> ListChildAccounts(string account_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string subscriber = null, string past_due = null) {
      var urlParams = new Dictionary<string, object>{ { "account_id", account_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "subscriber", subscriber }, { "past_due", past_due } };
      var url = this.InterpolatePath("/sites/{site_id}/accounts/{account_id}/accounts", urlParams);
      return MakeRequest<Pager<Account>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List a site's account acquisition data
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the site's account acquisition data.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AccountAcquisition ListAccountAcquisition(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/acquisitions", urlParams);
      return MakeRequest<AccountAcquisition>(Method.GET, url, null, queryParams).Data;
    }
  
    /// <summary>
    /// List a site's coupons
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the site's coupons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Coupon> ListCoupons(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons", urlParams);
      return MakeRequest<Pager<Coupon>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create a new coupon
    /// </summary>
    /// <param name="body"></param>
    /// <returns>
    /// A new coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Coupon CreateCoupon(CouponCreate body) {
      var urlParams = new Dictionary<string, object>{ };
      var url = this.InterpolatePath("/sites/{site_id}/coupons", urlParams);
      return MakeRequest<Coupon>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a coupon
    /// </summary>
    /// <param name="coupon_id">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
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
    /// <param name="coupon_id">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// The updated coupon.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Coupon UpdateCoupon(string coupon_id, CouponUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "coupon_id", coupon_id } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons/{coupon_id}", urlParams);
      return MakeRequest<Coupon>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// List unique coupon codes associated with a bulk coupon
    /// </summary>
    /// <param name="coupon_id">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of unique coupon codes that were generated
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<UniqueCouponCode> ListUniqueCouponCodes(string coupon_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ { "coupon_id", coupon_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/coupons/{coupon_id}/unique_coupon_codes", urlParams);
      return MakeRequest<Pager<UniqueCouponCode>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List a site's credit payments
    /// </summary>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the site's credit payments.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CreditPayment> ListCreditPayments(int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/credit_payments", urlParams);
      return MakeRequest<Pager<CreditPayment>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch a credit payment
    /// </summary>
    /// <param name="credit_payment_id">Credit Payment ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the site's custom field definitions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CustomFieldDefinition> ListCustomFieldDefinitions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/custom_field_definitions", urlParams);
      return MakeRequest<Pager<CustomFieldDefinition>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch an custom field definition
    /// </summary>
    /// <param name="custom_field_definition_id">Custom Field Definition ID</param>
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
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
    /// <returns>
    /// A list of the site's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListInvoices(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch an invoice
    /// </summary>
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// An invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice PutInvoice(string invoice_id, InvoiceUpdatable body) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}", urlParams);
      return MakeRequest<Invoice>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Collect a pending or past due, automatic invoice
    /// </summary>
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="original">Filter by original field.</param>
    /// <param name="state">Filter by state field.</param>
    /// <param name="type">Filter by type field.</param>
    /// <returns>
    /// A list of the invoice's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListInvoiceLineItems(string invoice_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string original = null, string state = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "original", original }, { "state", state }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Show the coupon redemptions applied to an invoice
    /// </summary>
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <returns>
    /// A list of the the coupon redemptions associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<CouponRedemption> ListInvoiceCouponRedemptions(string invoice_id, string ids = null) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/coupon_redemptions", urlParams);
      return MakeRequest<Pager<CouponRedemption>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List an invoice's related credit or charge invoices
    /// </summary>
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
    /// <returns>
    /// A list of the credit or charge invoices associated with the invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListRelatedInvoices(string invoice_id) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/related_invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url).Data.WithClient(this);
    }
  
    /// <summary>
    /// Refund an invoice
    /// </summary>
    /// <param name="invoice_id">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// Returns the new credit invoice.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Invoice RefundInvoice(string invoice_id, InvoiceRefund body) {
      var urlParams = new Dictionary<string, object>{ { "invoice_id", invoice_id } };
      var url = this.InterpolatePath("/sites/{site_id}/invoices/{invoice_id}/refund", urlParams);
      return MakeRequest<Invoice>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// List a site's line items
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="original">Filter by original field.</param>
    /// <param name="state">Filter by state field.</param>
    /// <param name="type">Filter by type field.</param>
    /// <returns>
    /// A list of the site's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListLineItems(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string original = null, string state = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "original", original }, { "state", state }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch a line item
    /// </summary>
    /// <param name="line_item_id">Line Item ID.</param>
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
    /// <param name="line_item_id">Line Item ID.</param>
    /// <returns>
    /// Line item deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveLineItem(string line_item_id) {
      var urlParams = new Dictionary<string, object>{ { "line_item_id", line_item_id } };
      var url = this.InterpolatePath("/sites/{site_id}/line_items/{line_item_id}", urlParams);
      MakeRequest<object>(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a site's plans
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="state">Filter by state.</param>
    /// <returns>
    /// A list of plans.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Plan> ListPlans(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string state = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "state", state } };
      var url = this.InterpolatePath("/sites/{site_id}/plans", urlParams);
      return MakeRequest<Pager<Plan>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create a plan
    /// </summary>
    /// <param name="body"></param>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan CreatePlan(PlanCreate body) {
      var urlParams = new Dictionary<string, object>{ };
      var url = this.InterpolatePath("/sites/{site_id}/plans", urlParams);
      return MakeRequest<Plan>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a plan
    /// </summary>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
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
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// A plan.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Plan UpdatePlan(string plan_id, PlanUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}", urlParams);
      return MakeRequest<Plan>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove a plan
    /// </summary>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
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
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="state">Filter by state.</param>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AddOn> ListPlanAddOns(string plan_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string state = null) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "state", state } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons", urlParams);
      return MakeRequest<Pager<AddOn>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create an add-on
    /// </summary>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn CreatePlanAddOn(string plan_id, AddOnCreate body) {
      var urlParams = new Dictionary<string, object>{ { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons", urlParams);
      return MakeRequest<AddOn>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a plan's add-on
    /// </summary>
    /// <param name="add_on_id">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn GetPlanAddOn(string add_on_id, string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id }, { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// Update an add-on
    /// </summary>
    /// <param name="add_on_id">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// An add-on.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn UpdatePlanAddOn(string add_on_id, string plan_id, AddOnUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id }, { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Remove an add-on
    /// </summary>
    /// <param name="add_on_id">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <param name="plan_id">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
    /// <returns>
    /// Add-on deleted
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public AddOn RemovePlanAddOn(string add_on_id, string plan_id) {
      var urlParams = new Dictionary<string, object>{ { "add_on_id", add_on_id }, { "plan_id", plan_id } };
      var url = this.InterpolatePath("/sites/{site_id}/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
      return MakeRequest<AddOn>(Method.DELETE, url).Data;
    }
  
    /// <summary>
    /// List a site's add-ons
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="state">Filter by state.</param>
    /// <returns>
    /// A list of add-ons.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<AddOn> ListAddOns(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string state = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "state", state } };
      var url = this.InterpolatePath("/sites/{site_id}/add_ons", urlParams);
      return MakeRequest<Pager<AddOn>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch an add-on
    /// </summary>
    /// <param name="add_on_id">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
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
    /// List a site's shipping services
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <returns>
    /// A list of the site's shipping services.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<ShippingService> ListShippingServices(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time } };
      var url = this.InterpolatePath("/sites/{site_id}/shipping_services", urlParams);
      return MakeRequest<Pager<ShippingService>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch a shipping service
    /// </summary>
    /// <param name="id">Shipping Service ID or code (use prefix: `code-`, e.g. `code-usps_2-day`).</param>
    /// <returns>
    /// A shipping_service.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public ShippingService GetShippingService(string id) {
      var urlParams = new Dictionary<string, object>{ { "id", id } };
      var url = this.InterpolatePath("/sites/{site_id}/shipping_services/{id}", urlParams);
      return MakeRequest<ShippingService>(Method.GET, url).Data;
    }
  
    /// <summary>
    /// List a site's subscriptions
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="state">Filter by state.  - When `state=active`, `state=canceled`, `state=expired`, or `state=future`, subscriptions with states that match the query and only those subscriptions will be returned.  - When `state=in_trial`, only subscriptions that have a trial_started_at date earlier than now and a trial_ends_at date later than now will be returned.  - When `state=live`, only subscriptions that are in an active, canceled, or future state or are in trial will be returned.  </param>
    /// <returns>
    /// A list of the site's subscriptions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Subscription> ListSubscriptions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string state = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "state", state } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions", urlParams);
      return MakeRequest<Pager<Subscription>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Create a new subscription
    /// </summary>
    /// <param name="body"></param>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription CreateSubscription(SubscriptionCreate body) {
      var urlParams = new Dictionary<string, object>{ };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions", urlParams);
      return MakeRequest<Subscription>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Fetch a subscription
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// A subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription ModifySubscription(string subscription_id, SubscriptionUpdate body) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}", urlParams);
      return MakeRequest<Subscription>(Method.PUT, url, body).Data;
    }
  
    /// <summary>
    /// Terminate a subscription
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <param name="refund">The type of refund to perform:    * `full` - Performs a full refund of the last invoice for the current subscription term.  * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.  * `none` - Terminates the subscription without a refund.    In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.    You may also terminate a subscription with no refund and then manually refund specific invoices.  </param>
    /// <returns>
    /// An expired subscription.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Subscription TerminateSubscription(string subscription_id, string refund = null) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var queryParams = new Dictionary<string, object>{ { "refund", refund } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}", urlParams);
      return MakeRequest<Subscription>(Method.DELETE, url, null, queryParams).Data;
    }
  
    /// <summary>
    /// Cancel a subscription
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <param name="body"></param>
    /// <returns>
    /// A subscription change.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public SubscriptionChange CreateSubscriptionChange(string subscription_id, SubscriptionChangeCreate body) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/change", urlParams);
      return MakeRequest<SubscriptionChange>(Method.POST, url, body).Data;
    }
  
    /// <summary>
    /// Delete the pending subscription change
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <returns>
    /// Subscription change was deleted.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public void RemoveSubscriptionChange(string subscription_id) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/change", urlParams);
      MakeRequest<object>(Method.DELETE, url);
    }
  
    /// <summary>
    /// List a subscription's invoices
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
    /// <returns>
    /// A list of the subscription's invoices.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Invoice> ListSubscriptionInvoices(string subscription_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/invoices", urlParams);
      return MakeRequest<Pager<Invoice>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List a subscription's line items
    /// </summary>
    /// <param name="subscription_id">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="original">Filter by original field.</param>
    /// <param name="state">Filter by state field.</param>
    /// <param name="type">Filter by type field.</param>
    /// <returns>
    /// A list of the subscription's line items.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<LineItem> ListSubscriptionLineItems(string subscription_id, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string original = null, string state = null, string type = null) {
      var urlParams = new Dictionary<string, object>{ { "subscription_id", subscription_id } };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "original", original }, { "state", state }, { "type", type } };
      var url = this.InterpolatePath("/sites/{site_id}/subscriptions/{subscription_id}/line_items", urlParams);
      return MakeRequest<Pager<LineItem>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// List a site's transactions
    /// </summary>
    /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**  * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
    /// <param name="limit">Limit number of records 1-200.</param>
    /// <param name="order">Sort order.</param>
    /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
    /// <param name="begin_time">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="end_time">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
    /// <param name="type">Filter by type field. The value `payment` will return both `purchase` and `capture` transactions.</param>
    /// <param name="success">Filter by success field.</param>
    /// <returns>
    /// A list of the site's transactions.
    /// </returns>
    /// <exception cref="Recurly.ApiError">Thrown when the request is invalid.</exception>
    public Pager<Transaction> ListTransactions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? begin_time = null, DateTime? end_time = null, string type = null, string success = null) {
      var urlParams = new Dictionary<string, object>{ };
      var queryParams = new Dictionary<string, object>{ { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", begin_time }, { "end_time", end_time }, { "type", type }, { "success", success } };
      var url = this.InterpolatePath("/sites/{site_id}/transactions", urlParams);
      return MakeRequest<Pager<Transaction>>(Method.GET, url, null, queryParams).Data.WithClient(this);
    }
  
    /// <summary>
    /// Fetch a transaction
    /// </summary>
    /// <param name="transaction_id">Transaction ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
    /// <param name="unique_coupon_code_id">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
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
    /// <param name="unique_coupon_code_id">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
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
    /// <param name="unique_coupon_code_id">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
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