/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Recurly.Resources;
using RestSharp;

namespace Recurly
{
    [ExcludeFromCodeCoverage]
    public class Client : BaseClient
    {
        public override string ApiVersion => "v2019-10-10";

        public Client(string apiKey) : base(apiKey) { }

        /// <summary>
        /// List sites <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_sites">list_sites api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <returns>
        /// A list of sites.
        /// </returns>
        public Pager<Site> ListSites(string ids = null, int? limit = null, string order = null, string sort = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort } };
            var url = this.InterpolatePath("/sites", urlParams);
            return Pager<Site>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch a site <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <param name="siteId">Site ID or subdomain. For ID no prefix is used e.g. `e28zov4fw0v2`. For subdomain use prefix `subdomain-`, e.g. `subdomain-recurly`.</param>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Site GetSite(string siteId)
        {
            var urlParams = new Dictionary<string, object> { { "site_id", siteId } };
            var url = this.InterpolatePath("/sites/{site_id}", urlParams);
            return MakeRequest<Site>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a site <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <param name="siteId">Site ID or subdomain. For ID no prefix is used e.g. `e28zov4fw0v2`. For subdomain use prefix `subdomain-`, e.g. `subdomain-recurly`.</param>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Site> GetSiteAsync(string siteId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "site_id", siteId } };
            var url = this.InterpolatePath("/sites/{site_id}", urlParams);
            return MakeRequestAsync<Site>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's accounts <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_accounts">list_accounts api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="email">Filter for accounts with this exact email address. A blank value will return accounts with both `null` and `""` email addresses. Note that multiple accounts can share one email address.</param>
        /// <param name="subscriber">Filter for accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
        /// <param name="pastDue">Filter for accounts with an invoice in the `past_due` state.</param>
        /// <returns>
        /// A list of the site's accounts.
        /// </returns>
        public Pager<Account> ListAccounts(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string email = null, bool? subscriber = null, string pastDue = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "email", email }, { "subscriber", subscriber }, { "past_due", pastDue } };
            var url = this.InterpolatePath("/accounts", urlParams);
            return Pager<Account>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account CreateAccount(AccountCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/accounts", urlParams);
            return MakeRequest<Account>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> CreateAccountAsync(AccountCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/accounts", urlParams);
            return MakeRequestAsync<Account>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account GetAccount(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> GetAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Modify an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account UpdateAccount(string accountId, AccountUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Modify an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> UpdateAccountAsync(string accountId, AccountUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Deactivate an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account DeactivateAccount(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Deactivate an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> DeactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountAcquisition GetAccountAcquisition(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequest<AccountAcquisition>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountAcquisition> GetAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<AccountAcquisition>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountAcquisition UpdateAccountAcquisition(string accountId, AccountAcquisitionUpdatable body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequest<AccountAcquisition>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountAcquisition> UpdateAccountAcquisitionAsync(string accountId, AccountAcquisitionUpdatable body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<AccountAcquisition>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Remove an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public void RemoveAccountAcquisition(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            MakeRequest<object>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Remove an account's acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<object> RemoveAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<object>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Reactivate an inactive account <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account ReactivateAccount(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/reactivate", urlParams);
            return MakeRequest<Account>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Reactivate an inactive account <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> ReactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/reactivate", urlParams);
            return MakeRequestAsync<Account>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountBalance GetAccountBalance(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/balance", urlParams);
            return MakeRequest<AccountBalance>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountBalance> GetAccountBalanceAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/balance", urlParams);
            return MakeRequestAsync<AccountBalance>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo GetBillingInfo(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequest<BillingInfo>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> GetBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<BillingInfo>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Set an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo UpdateBillingInfo(string accountId, BillingInfoCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequest<BillingInfo>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Set an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> UpdateBillingInfoAsync(string accountId, BillingInfoCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<BillingInfo>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public void RemoveBillingInfo(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            MakeRequest<object>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<object> RemoveBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<object>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Show the coupon redemptions for an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_coupon_redemptions">list_account_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions on an account.
        /// </returns>
        public Pager<CouponRedemption> ListAccountCouponRedemptions(string accountId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Show the coupon redemption that is active on an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_active_coupon_redemption">get_active_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An active coupon redemption on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption GetActiveCouponRedemption(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequest<CouponRedemption>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Show the coupon redemption that is active on an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_active_coupon_redemption">get_active_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// An active coupon redemption on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> GetActiveCouponRedemptionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequestAsync<CouponRedemption>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Generate an active coupon redemption on an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption CreateCouponRedemption(string accountId, CouponRedemptionCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequest<CouponRedemption>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Generate an active coupon redemption on an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> CreateCouponRedemptionAsync(string accountId, CouponRedemptionCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequestAsync<CouponRedemption>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption RemoveCouponRedemption(string accountId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequest<CouponRedemption>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> RemoveCouponRedemptionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequestAsync<CouponRedemption>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List an account's credit payments <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_credit_payments">list_account_credit_payments api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the account's credit payments.
        /// </returns>
        public Pager<CreditPayment> ListAccountCreditPayments(string accountId, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/accounts/{account_id}/credit_payments", urlParams);
            return Pager<CreditPayment>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List an account's invoices <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_invoices">list_account_invoices api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
        /// <returns>
        /// A list of the account's invoices.
        /// </returns>
        public Pager<Invoice> ListAccountInvoices(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "type", type } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create an invoice for pending line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreateInvoice(string accountId, InvoiceCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return MakeRequest<InvoiceCollection>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create an invoice for pending line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreateInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return MakeRequestAsync<InvoiceCollection>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Preview new invoice for pending line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection PreviewInvoice(string accountId, InvoiceCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices/preview", urlParams);
            return MakeRequest<InvoiceCollection>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Preview new invoice for pending line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> PreviewInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices/preview", urlParams);
            return MakeRequestAsync<InvoiceCollection>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// List an account's line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_line_items">list_account_line_items api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="original">Filter by original field.</param>
        /// <param name="state">Filter by state field.</param>
        /// <param name="type">Filter by type field.</param>
        /// <returns>
        /// A list of the account's line items.
        /// </returns>
        public Pager<LineItem> ListAccountLineItems(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "original", original }, { "state", state }, { "type", type } };
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a new line item for the account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public LineItem CreateLineItem(string accountId, LineItemCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return MakeRequest<LineItem>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new line item for the account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<LineItem> CreateLineItemAsync(string accountId, LineItemCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return MakeRequestAsync<LineItem>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a list of an account's notes <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_notes">list_account_notes api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <returns>
        /// A list of an account's notes.
        /// </returns>
        public Pager<AccountNote> ListAccountNotes(string accountId, string ids = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes", urlParams);
            return Pager<AccountNote>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch an account note <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="accountNoteId">Account Note ID.</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountNote GetAccountNote(string accountId, string accountNoteId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequest<AccountNote>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account note <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="accountNoteId">Account Note ID.</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountNote> GetAccountNoteAsync(string accountId, string accountNoteId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequestAsync<AccountNote>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a list of an account's shipping addresses <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_shipping_addresses">list_shipping_addresses api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of an account's shipping addresses.
        /// </returns>
        public Pager<ShippingAddress> ListShippingAddresses(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return Pager<ShippingAddress>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a new shipping address for the account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress CreateShippingAddress(string accountId, ShippingAddressCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return MakeRequest<ShippingAddress>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new shipping address for the account <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> CreateShippingAddressAsync(string accountId, ShippingAddressCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return MakeRequestAsync<ShippingAddress>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress GetShippingAddress(string accountId, string shippingAddressId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequest<ShippingAddress>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> GetShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<ShippingAddress>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress UpdateShippingAddress(string accountId, string shippingAddressId, ShippingAddressUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequest<ShippingAddress>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> UpdateShippingAddressAsync(string accountId, string shippingAddressId, ShippingAddressUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<ShippingAddress>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Remove an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public void RemoveShippingAddress(string accountId, string shippingAddressId)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            MakeRequest<object>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Remove an account's shipping address <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<object> RemoveShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<object>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List an account's subscriptions <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_subscriptions">list_account_subscriptions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.    - When `state=active`, `state=canceled`, `state=expired`, or `state=future`, subscriptions with states that match the query and only those subscriptions will be returned.  - When `state=in_trial`, only subscriptions that have a trial_started_at date earlier than now and a trial_ends_at date later than now will be returned.  - When `state=live`, only subscriptions that are in an active, canceled, or future state or are in trial will be returned.  </param>
        /// <returns>
        /// A list of the account's subscriptions.
        /// </returns>
        public Pager<Subscription> ListAccountSubscriptions(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/accounts/{account_id}/subscriptions", urlParams);
            return Pager<Subscription>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List an account's transactions <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_transactions">list_account_transactions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="type">Filter by type field. The value `payment` will return both `purchase` and `capture` transactions.</param>
        /// <param name="success">Filter by success field.</param>
        /// <returns>
        /// A list of the account's transactions.
        /// </returns>
        public Pager<Transaction> ListAccountTransactions(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null, string success = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "type", type }, { "success", success } };
            var url = this.InterpolatePath("/accounts/{account_id}/transactions", urlParams);
            return Pager<Transaction>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List an account's child accounts <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_child_accounts">list_child_accounts api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-bob`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="email">Filter for accounts with this exact email address. A blank value will return accounts with both `null` and `""` email addresses. Note that multiple accounts can share one email address.</param>
        /// <param name="subscriber">Filter for accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
        /// <param name="pastDue">Filter for accounts with an invoice in the `past_due` state.</param>
        /// <returns>
        /// A list of an account's child accounts.
        /// </returns>
        public Pager<Account> ListChildAccounts(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string email = null, bool? subscriber = null, string pastDue = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "email", email }, { "subscriber", subscriber }, { "past_due", pastDue } };
            var url = this.InterpolatePath("/accounts/{account_id}/accounts", urlParams);
            return Pager<Account>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List a site's account acquisition data <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_account_acquisition">list_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's account acquisition data.
        /// </returns>
        public Pager<AccountAcquisition> ListAccountAcquisition(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/acquisitions", urlParams);
            return Pager<AccountAcquisition>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List a site's coupons <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_coupons">list_coupons api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's coupons.
        /// </returns>
        public Pager<Coupon> ListCoupons(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/coupons", urlParams);
            return Pager<Coupon>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a new coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon CreateCoupon(CouponCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/coupons", urlParams);
            return MakeRequest<Coupon>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> CreateCouponAsync(CouponCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/coupons", urlParams);
            return MakeRequestAsync<Coupon>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-10off`.</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon GetCoupon(string couponId)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequest<Coupon>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-10off`.</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> GetCouponAsync(string couponId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequestAsync<Coupon>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an active coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-10off`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon UpdateCoupon(string couponId, CouponUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequest<Coupon>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an active coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-10off`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> UpdateCouponAsync(string couponId, CouponUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequestAsync<Coupon>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// List unique coupon codes associated with a bulk coupon <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_unique_coupon_codes">list_unique_coupon_codes api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-10off`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of unique coupon codes that were generated
        /// </returns>
        public Pager<UniqueCouponCode> ListUniqueCouponCodes(string couponId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/unique_coupon_codes", urlParams);
            return Pager<UniqueCouponCode>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List a site's credit payments <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_credit_payments">list_credit_payments api documentation</see>
        /// </summary>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's credit payments.
        /// </returns>
        public Pager<CreditPayment> ListCreditPayments(int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/credit_payments", urlParams);
            return Pager<CreditPayment>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch a credit payment <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="creditPaymentId">Credit Payment ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CreditPayment GetCreditPayment(string creditPaymentId)
        {
            var urlParams = new Dictionary<string, object> { { "credit_payment_id", creditPaymentId } };
            var url = this.InterpolatePath("/credit_payments/{credit_payment_id}", urlParams);
            return MakeRequest<CreditPayment>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a credit payment <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="creditPaymentId">Credit Payment ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CreditPayment> GetCreditPaymentAsync(string creditPaymentId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "credit_payment_id", creditPaymentId } };
            var url = this.InterpolatePath("/credit_payments/{credit_payment_id}", urlParams);
            return MakeRequestAsync<CreditPayment>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's custom field definitions <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_custom_field_definitions">list_custom_field_definitions api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="relatedType">Filter by related type.</param>
        /// <returns>
        /// A list of the site's custom field definitions.
        /// </returns>
        public Pager<CustomFieldDefinition> ListCustomFieldDefinitions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string relatedType = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "related_type", relatedType } };
            var url = this.InterpolatePath("/custom_field_definitions", urlParams);
            return Pager<CustomFieldDefinition>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch an custom field definition <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="customFieldDefinitionId">Custom Field Definition ID</param>
        /// <returns>
        /// An custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CustomFieldDefinition GetCustomFieldDefinition(string customFieldDefinitionId)
        {
            var urlParams = new Dictionary<string, object> { { "custom_field_definition_id", customFieldDefinitionId } };
            var url = this.InterpolatePath("/custom_field_definitions/{custom_field_definition_id}", urlParams);
            return MakeRequest<CustomFieldDefinition>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an custom field definition <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="customFieldDefinitionId">Custom Field Definition ID</param>
        /// <returns>
        /// An custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CustomFieldDefinition> GetCustomFieldDefinitionAsync(string customFieldDefinitionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "custom_field_definition_id", customFieldDefinitionId } };
            var url = this.InterpolatePath("/custom_field_definitions/{custom_field_definition_id}", urlParams);
            return MakeRequestAsync<CustomFieldDefinition>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's items <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_items">list_items api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.</param>
        /// <returns>
        /// A list of the site's items.
        /// </returns>
        public Pager<Item> ListItems(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/items", urlParams);
            return Pager<Item>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a new item <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_item">create_item api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item CreateItem(ItemCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/items", urlParams);
            return MakeRequest<Item>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new item <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_item">create_item api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> CreateItemAsync(ItemCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/items", urlParams);
            return MakeRequestAsync<Item>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an item <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_item">get_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item GetItem(string itemId)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an item <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_item">get_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> GetItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an active item <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_item">update_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item UpdateItem(string itemId, ItemUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an active item <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_item">update_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> UpdateItemAsync(string itemId, ItemUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Deactivate an item <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_item">deactivate_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item DeactivateItem(string itemId)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Deactivate an item <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_item">deactivate_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> DeactivateItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Reactivate an inactive item <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_item">reactivate_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item ReactivateItem(string itemId)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}/reactivate", urlParams);
            return MakeRequest<Item>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Reactivate an inactive item <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_item">reactivate_item api documentation</see>
        /// </summary>
        /// <param name="itemId">Item ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-red`.</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> ReactivateItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}/reactivate", urlParams);
            return MakeRequestAsync<Item>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's invoices <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_invoices">list_invoices api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
        /// <returns>
        /// A list of the site's invoices.
        /// </returns>
        public Pager<Invoice> ListInvoices(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "type", type } };
            var url = this.InterpolatePath("/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice GetInvoice(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequest<Invoice>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequestAsync<Invoice>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/put_invoice">put_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice PutInvoice(string invoiceId, InvoiceUpdatable body)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/put_invoice">put_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> PutInvoiceAsync(string invoiceId, InvoiceUpdatable body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch an invoice as a PDF <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_invoice_pdf">get_invoice_pdf api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// An invoice as a PDF.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BinaryFile GetInvoicePdf(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}.pdf", urlParams);
            return MakeRequest<BinaryFile>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an invoice as a PDF <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_invoice_pdf">get_invoice_pdf api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// An invoice as a PDF.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BinaryFile> GetInvoicePdfAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}.pdf", urlParams);
            return MakeRequestAsync<BinaryFile>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice CollectInvoice(string invoiceId, InvoiceCollect body = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/collect", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> CollectInvoiceAsync(string invoiceId, InvoiceCollect body = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/collect", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Mark an open invoice as failed <see href="https://developers.recurly.com/api/v2019-10-10#operation/fail_invoice">fail_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice FailInvoice(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_failed", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Mark an open invoice as failed <see href="https://developers.recurly.com/api/v2019-10-10#operation/fail_invoice">fail_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> FailInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_failed", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Mark an open invoice as successful <see href="https://developers.recurly.com/api/v2019-10-10#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice MarkInvoiceSuccessful(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_successful", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Mark an open invoice as successful <see href="https://developers.recurly.com/api/v2019-10-10#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> MarkInvoiceSuccessfulAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_successful", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice ReopenInvoice(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/reopen", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> ReopenInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/reopen", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Void a credit invoice. <see href="https://developers.recurly.com/api/v2019-10-10#operation/void_invoice">void_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice VoidInvoice(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/void", urlParams);
            return MakeRequest<Invoice>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Void a credit invoice. <see href="https://developers.recurly.com/api/v2019-10-10#operation/void_invoice">void_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> VoidInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/void", urlParams);
            return MakeRequestAsync<Invoice>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List an invoice's line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_invoice_line_items">list_invoice_line_items api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="original">Filter by original field.</param>
        /// <param name="state">Filter by state field.</param>
        /// <param name="type">Filter by type field.</param>
        /// <returns>
        /// A list of the invoice's line items.
        /// </returns>
        public Pager<LineItem> ListInvoiceLineItems(string invoiceId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "original", original }, { "state", state }, { "type", type } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Show the coupon redemptions applied to an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_invoice_coupon_redemptions">list_invoice_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions associated with the invoice.
        /// </returns>
        public Pager<CouponRedemption> ListInvoiceCouponRedemptions(string invoiceId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List an invoice's related credit or charge invoices <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_related_invoices">list_related_invoices api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <returns>
        /// A list of the credit or charge invoices associated with the invoice.
        /// </returns>
        public Pager<Invoice> ListRelatedInvoices(string invoiceId)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/related_invoices", urlParams);
            return Pager<Invoice>.Build(url, null, this);
        }


        /// <summary>
        /// Refund an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice RefundInvoice(string invoiceId, InvoiceRefund body)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/refund", urlParams);
            return MakeRequest<Invoice>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Refund an invoice <see href="https://developers.recurly.com/api/v2019-10-10#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number. For ID no prefix is used e.g. `e28zov4fw0v2`. For number use prefix `number-`, e.g. `number-1000`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> RefundInvoiceAsync(string invoiceId, InvoiceRefund body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/refund", urlParams);
            return MakeRequestAsync<Invoice>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// List a site's line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_line_items">list_line_items api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="original">Filter by original field.</param>
        /// <param name="state">Filter by state field.</param>
        /// <param name="type">Filter by type field.</param>
        /// <returns>
        /// A list of the site's line items.
        /// </returns>
        public Pager<LineItem> ListLineItems(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "original", original }, { "state", state }, { "type", type } };
            var url = this.InterpolatePath("/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch a line item <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public LineItem GetLineItem(string lineItemId)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequest<LineItem>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a line item <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<LineItem> GetLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequestAsync<LineItem>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Delete an uninvoiced line item <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public void RemoveLineItem(string lineItemId)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            MakeRequest<object>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Delete an uninvoiced line item <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<object> RemoveLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequestAsync<object>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's plans <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_plans">list_plans api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.</param>
        /// <returns>
        /// A list of plans.
        /// </returns>
        public Pager<Plan> ListPlans(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/plans", urlParams);
            return Pager<Plan>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan CreatePlan(PlanCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/plans", urlParams);
            return MakeRequest<Plan>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> CreatePlanAsync(PlanCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/plans", urlParams);
            return MakeRequestAsync<Plan>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan GetPlan(string planId)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> GetPlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan UpdatePlan(string planId, PlanUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> UpdatePlanAsync(string planId, PlanUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Remove a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan RemovePlan(string planId)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Remove a plan <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> RemovePlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a plan's add-ons <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_plan_add_ons">list_plan_add_ons api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.</param>
        /// <returns>
        /// A list of add-ons.
        /// </returns>
        public Pager<AddOn> ListPlanAddOns(string planId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return Pager<AddOn>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn CreatePlanAddOn(string planId, AddOnCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return MakeRequest<AddOn>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> CreatePlanAddOnAsync(string planId, AddOnCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return MakeRequestAsync<AddOn>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a plan's add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn GetPlanAddOn(string planId, string addOnId)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a plan's add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> GetPlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Update an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn UpdatePlanAddOn(string planId, string addOnId, AddOnUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Update an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> UpdatePlanAddOnAsync(string planId, string addOnId, AddOnUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Remove an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn RemovePlanAddOn(string planId, string addOnId)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Remove an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> RemovePlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's add-ons <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_add_ons">list_add_ons api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.</param>
        /// <returns>
        /// A list of add-ons.
        /// </returns>
        public Pager<AddOn> ListAddOns(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/add_ons", urlParams);
            return Pager<AddOn>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn GetAddOn(string addOnId)
        {
            var urlParams = new Dictionary<string, object> { { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch an add-on <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="addOnId">Add-on ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-gold`.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> GetAddOnAsync(string addOnId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's shipping methods <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_shipping_methods">list_shipping_methods api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's shipping methods.
        /// </returns>
        public Pager<ShippingMethod> ListShippingMethods(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/shipping_methods", urlParams);
            return Pager<ShippingMethod>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch a shipping method <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_shipping_method">get_shipping_method api documentation</see>
        /// </summary>
        /// <param name="id">Shipping Method ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-usps_2-day`.</param>
        /// <returns>
        /// A shipping_method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingMethod GetShippingMethod(string id)
        {
            var urlParams = new Dictionary<string, object> { { "id", id } };
            var url = this.InterpolatePath("/shipping_methods/{id}", urlParams);
            return MakeRequest<ShippingMethod>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a shipping method <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_shipping_method">get_shipping_method api documentation</see>
        /// </summary>
        /// <param name="id">Shipping Method ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-usps_2-day`.</param>
        /// <returns>
        /// A shipping_method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingMethod> GetShippingMethodAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "id", id } };
            var url = this.InterpolatePath("/shipping_methods/{id}", urlParams);
            return MakeRequestAsync<ShippingMethod>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a site's subscriptions <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_subscriptions">list_subscriptions api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="state">Filter by state.    - When `state=active`, `state=canceled`, `state=expired`, or `state=future`, subscriptions with states that match the query and only those subscriptions will be returned.  - When `state=in_trial`, only subscriptions that have a trial_started_at date earlier than now and a trial_ends_at date later than now will be returned.  - When `state=live`, only subscriptions that are in an active, canceled, or future state or are in trial will be returned.  </param>
        /// <returns>
        /// A list of the site's subscriptions.
        /// </returns>
        public Pager<Subscription> ListSubscriptions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "state", state } };
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return Pager<Subscription>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Create a new subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription CreateSubscription(SubscriptionCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return MakeRequest<Subscription>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> CreateSubscriptionAsync(SubscriptionCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return MakeRequestAsync<Subscription>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription GetSubscription(string subscriptionId)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Modify a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/modify_subscription">modify_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ModifySubscription(string subscriptionId, SubscriptionUpdate body)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Modify a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/modify_subscription">modify_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ModifySubscriptionAsync(string subscriptionId, SubscriptionUpdate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Terminate a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="refund">The type of refund to perform:    * `full` - Performs a full refund of the last invoice for the current subscription term.  * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.  * `none` - Terminates the subscription without a refund.    In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.    You may also terminate a subscription with no refund and then manually refund specific invoices.  </param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription TerminateSubscription(string subscriptionId, string refund = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = new Dictionary<string, object> { { "refund", refund } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(Method.DELETE, url, null, queryParams);
        }

        /// <summary>
        /// Terminate a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="refund">The type of refund to perform:    * `full` - Performs a full refund of the last invoice for the current subscription term.  * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.  * `none` - Terminates the subscription without a refund.    In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.    You may also terminate a subscription with no refund and then manually refund specific invoices.  </param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> TerminateSubscriptionAsync(string subscriptionId, string refund = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = new Dictionary<string, object> { { "refund", refund } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(Method.DELETE, url, null, queryParams, cancellationToken);
        }

        /// <summary>
        /// Cancel a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription CancelSubscription(string subscriptionId, SubscriptionCancel body = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/cancel", urlParams);
            return MakeRequest<Subscription>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Cancel a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> CancelSubscriptionAsync(string subscriptionId, SubscriptionCancel body = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/cancel", urlParams);
            return MakeRequestAsync<Subscription>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Reactivate a canceled subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ReactivateSubscription(string subscriptionId)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/reactivate", urlParams);
            return MakeRequest<Subscription>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Reactivate a canceled subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ReactivateSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/reactivate", urlParams);
            return MakeRequestAsync<Subscription>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Pause subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription PauseSubscription(string subscriptionId, SubscriptionPause body)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/pause", urlParams);
            return MakeRequest<Subscription>(Method.PUT, url, body, null);
        }

        /// <summary>
        /// Pause subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> PauseSubscriptionAsync(string subscriptionId, SubscriptionPause body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/pause", urlParams);
            return MakeRequestAsync<Subscription>(Method.PUT, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Resume subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ResumeSubscription(string subscriptionId)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/resume", urlParams);
            return MakeRequest<Subscription>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Resume subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ResumeSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/resume", urlParams);
            return MakeRequestAsync<Subscription>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a subscription's pending change <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public SubscriptionChange GetSubscriptionChange(string subscriptionId)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequest<SubscriptionChange>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a subscription's pending change <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<SubscriptionChange> GetSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<SubscriptionChange>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Create a new subscription change <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public SubscriptionChange CreateSubscriptionChange(string subscriptionId, SubscriptionChangeCreate body)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequest<SubscriptionChange>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new subscription change <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<SubscriptionChange> CreateSubscriptionChangeAsync(string subscriptionId, SubscriptionChangeCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<SubscriptionChange>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Delete the pending subscription change <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public void RemoveSubscriptionChange(string subscriptionId)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            MakeRequest<object>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Delete the pending subscription change <see href="https://developers.recurly.com/api/v2019-10-10#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<object> RemoveSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<object>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// List a subscription's invoices <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_subscription_invoices">list_subscription_invoices api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="type">Filter by type when:  - `type=charge`, only charge invoices will be returned.  - `type=credit`, only credit invoices will be returned.  - `type=non-legacy`, only charge and credit invoices will be returned.  - `type=legacy`, only legacy invoices will be returned.  </param>
        /// <returns>
        /// A list of the subscription's invoices.
        /// </returns>
        public Pager<Invoice> ListSubscriptionInvoices(string subscriptionId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "type", type } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List a subscription's line items <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_subscription_line_items">list_subscription_line_items api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="original">Filter by original field.</param>
        /// <param name="state">Filter by state field.</param>
        /// <param name="type">Filter by type field.</param>
        /// <returns>
        /// A list of the subscription's line items.
        /// </returns>
        public Pager<LineItem> ListSubscriptionLineItems(string subscriptionId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "original", original }, { "state", state }, { "type", type } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Show the coupon redemptions for a subscription <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_subscription_coupon_redemptions">list_subscription_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions on a subscription.
        /// </returns>
        public Pager<CouponRedemption> ListSubscriptionCouponRedemptions(string subscriptionId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, this);
        }


        /// <summary>
        /// List a site's transactions <see href="https://developers.recurly.com/api/v2019-10-10#operation/list_transactions">list_transactions api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="type">Filter by type field. The value `payment` will return both `purchase` and `capture` transactions.</param>
        /// <param name="success">Filter by success field.</param>
        /// <returns>
        /// A list of the site's transactions.
        /// </returns>
        public Pager<Transaction> ListTransactions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null, string success = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = new Dictionary<string, object> { { "ids", ids }, { "limit", limit }, { "order", order }, { "sort", sort }, { "begin_time", beginTime }, { "end_time", endTime }, { "type", type }, { "success", success } };
            var url = this.InterpolatePath("/transactions", urlParams);
            return Pager<Transaction>.Build(url, queryParams, this);
        }


        /// <summary>
        /// Fetch a transaction <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="transactionId">Transaction ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction GetTransaction(string transactionId)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/transactions/{transaction_id}", urlParams);
            return MakeRequest<Transaction>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a transaction <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="transactionId">Transaction ID or UUID. For ID no prefix is used e.g. `e28zov4fw0v2`. For UUID use prefix `uuid-`, e.g. `uuid-123457890`.</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> GetTransactionAsync(string transactionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/transactions/{transaction_id}", urlParams);
            return MakeRequestAsync<Transaction>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Fetch a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode GetUniqueCouponCode(string uniqueCouponCodeId)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequest<UniqueCouponCode>(Method.GET, url, null, null);
        }

        /// <summary>
        /// Fetch a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> GetUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(Method.GET, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Deactivate a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode DeactivateUniqueCouponCode(string uniqueCouponCodeId)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequest<UniqueCouponCode>(Method.DELETE, url, null, null);
        }

        /// <summary>
        /// Deactivate a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> DeactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(Method.DELETE, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Restore a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode ReactivateUniqueCouponCode(string uniqueCouponCodeId)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}/restore", urlParams);
            return MakeRequest<UniqueCouponCode>(Method.PUT, url, null, null);
        }

        /// <summary>
        /// Restore a unique coupon code <see href="https://developers.recurly.com/api/v2019-10-10#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code. For ID no prefix is used e.g. `e28zov4fw0v2`. For code use prefix `code-`, e.g. `code-abc-8dh2-def`.</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> ReactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}/restore", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(Method.PUT, url, null, null, cancellationToken);
        }

        /// <summary>
        /// Create a new purchase <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_purchase">create_purchase api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreatePurchase(PurchaseCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases", urlParams);
            return MakeRequest<InvoiceCollection>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Create a new purchase <see href="https://developers.recurly.com/api/v2019-10-10#operation/create_purchase">create_purchase api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreatePurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases", urlParams);
            return MakeRequestAsync<InvoiceCollection>(Method.POST, url, body, null, cancellationToken);
        }

        /// <summary>
        /// Preview a new purchase <see href="https://developers.recurly.com/api/v2019-10-10#operation/preview_purchase">preview_purchase api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns preview of the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection PreviewPurchase(PurchaseCreate body)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/preview", urlParams);
            return MakeRequest<InvoiceCollection>(Method.POST, url, body, null);
        }

        /// <summary>
        /// Preview a new purchase <see href="https://developers.recurly.com/api/v2019-10-10#operation/preview_purchase">preview_purchase api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns preview of the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> PreviewPurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken))
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/preview", urlParams);
            return MakeRequestAsync<InvoiceCollection>(Method.POST, url, body, null, cancellationToken);
        }
    }
}
