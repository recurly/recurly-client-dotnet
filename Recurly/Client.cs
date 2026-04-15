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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Recurly.Resources;

namespace Recurly
{
    [ExcludeFromCodeCoverage]
    public class Client : BaseClient, IClient
    {
        public override string ApiVersion => "v2021-02-25";

        public Client(string apiKey, ClientOptions options) : base(apiKey, options) { }
        public Client(string apiKey) : base(apiKey) { }

        /// <summary>
        /// List sites <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_sites">list_sites api documentation</see>
        /// </summary>
        /// <param name="ListSitesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of sites.
        /// </returns>
        public Pager<Site> ListSites(ListSitesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListSitesParams()).ToDictionary();
            var url = this.InterpolatePath("/sites", urlParams);
            return Pager<Site>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <param name="GetSiteParams">Optional Parameters for the request</param>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Site GetSite(string siteId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "site_id", siteId } };
            var url = this.InterpolatePath("/sites/{site_id}", urlParams);
            return MakeRequest<Site>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <param name="GetSiteParams">Optional Parameters for the request</param>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Site> GetSiteAsync(string siteId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "site_id", siteId } };
            var url = this.InterpolatePath("/sites/{site_id}", urlParams);
            return MakeRequestAsync<Site>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's accounts <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_accounts">list_accounts api documentation</see>
        /// </summary>
        /// <param name="ListAccountsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's accounts.
        /// </returns>
        public Pager<Account> ListAccounts(ListAccountsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListAccountsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts", urlParams);
            return Pager<Account>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="CreateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account CreateAccount(AccountCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/accounts", urlParams);
            return MakeRequest<Account>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="CreateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> CreateAccountAsync(AccountCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/accounts", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="GetAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account GetAccount(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="GetAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> GetAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account UpdateAccount(string accountId, AccountUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> UpdateAccountAsync(string accountId, AccountUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="DeactivateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account DeactivateAccount(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequest<Account>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="DeactivateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> DeactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Redact an account (GDPR Right to Erasure) <see href="https://developers.recurly.com/api/v2021-02-25#operation/redact_account">redact_account api documentation</see>
        /// </summary>
        /// <param name="RedactAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// Account has been accepted for redaction and will be processed asynchronously.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account RedactAccount(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/redact", urlParams);
            return MakeRequest<Account>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Redact an account (GDPR Right to Erasure) <see href="https://developers.recurly.com/api/v2021-02-25#operation/redact_account">redact_account api documentation</see>
        /// </summary>
        /// <param name="RedactAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// Account has been accepted for redaction and will be processed asynchronously.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> RedactAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/redact", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="GetAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountAcquisition GetAccountAcquisition(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequest<AccountAcquisition>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="GetAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountAcquisition> GetAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<AccountAcquisition>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountAcquisition UpdateAccountAcquisition(string accountId, AccountAcquisitionUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequest<AccountAcquisition>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountAcquisition> UpdateAccountAcquisitionAsync(string accountId, AccountAcquisitionUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<AccountAcquisition>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="RemoveAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveAccountAcquisition(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove an account's acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="RemoveAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/acquisition", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Reactivate an inactive account <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="ReactivateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Account ReactivateAccount(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/reactivate", urlParams);
            return MakeRequest<Account>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Reactivate an inactive account <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="ReactivateAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Account> ReactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/reactivate", urlParams);
            return MakeRequestAsync<Account>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="GetAccountBalanceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountBalance GetAccountBalance(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/balance", urlParams);
            return MakeRequest<AccountBalance>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="GetAccountBalanceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountBalance> GetAccountBalanceAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/balance", urlParams);
            return MakeRequestAsync<AccountBalance>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="GetBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo GetBillingInfo(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequest<BillingInfo>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="GetBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> GetBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<BillingInfo>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Set an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="UpdateBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo UpdateBillingInfo(string accountId, BillingInfoCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequest<BillingInfo>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Set an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="UpdateBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> UpdateBillingInfoAsync(string accountId, BillingInfoCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<BillingInfo>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="RemoveBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveBillingInfo(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="RemoveBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Verify an account's credit card billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_info">verify_billing_info api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction VerifyBillingInfo(string accountId, BillingInfoVerify body = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info/verify", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Verify an account's credit card billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_info">verify_billing_info api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> VerifyBillingInfoAsync(string accountId, BillingInfoVerify body = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info/verify", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Verify an account's credit card billing cvv <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_info_cvv">verify_billing_info_cvv api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfoCvvParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction VerifyBillingInfoCvv(string accountId, BillingInfoVerifyCVV body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info/verify_cvv", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Verify an account's credit card billing cvv <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_info_cvv">verify_billing_info_cvv api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfoCvvParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> VerifyBillingInfoCvvAsync(string accountId, BillingInfoVerifyCVV body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_info/verify_cvv", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Get the list of billing information associated with an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_billing_infos">list_billing_infos api documentation</see>
        /// </summary>
        /// <param name="ListBillingInfosParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the billing information for an account's
        /// </returns>
        public Pager<BillingInfo> ListBillingInfos(string accountId, ListBillingInfosParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListBillingInfosParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos", urlParams);
            return Pager<BillingInfo>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Add new billing information on an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_billing_info">create_billing_info api documentation</see>
        /// </summary>
        /// <param name="CreateBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo CreateBillingInfo(string accountId, BillingInfoCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos", urlParams);
            return MakeRequest<BillingInfo>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Add new billing information on an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_billing_info">create_billing_info api documentation</see>
        /// </summary>
        /// <param name="CreateBillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> CreateBillingInfoAsync(string accountId, BillingInfoCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos", urlParams);
            return MakeRequestAsync<BillingInfo>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a billing info <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_a_billing_info">get_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="GetABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// A billing info.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo GetABillingInfo(string accountId, string billingInfoId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequest<BillingInfo>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a billing info <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_a_billing_info">get_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="GetABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// A billing info.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> GetABillingInfoAsync(string accountId, string billingInfoId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequestAsync<BillingInfo>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_a_billing_info">update_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="UpdateABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BillingInfo UpdateABillingInfo(string accountId, string billingInfoId, BillingInfoCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequest<BillingInfo>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_a_billing_info">update_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="UpdateABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BillingInfo> UpdateABillingInfoAsync(string accountId, string billingInfoId, BillingInfoCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequestAsync<BillingInfo>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_a_billing_info">remove_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="RemoveABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveABillingInfo(string accountId, string billingInfoId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove an account's billing information <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_a_billing_info">remove_a_billing_info api documentation</see>
        /// </summary>
        /// <param name="RemoveABillingInfoParams">Optional Parameters for the request</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveABillingInfoAsync(string accountId, string billingInfoId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Verify a billing information's credit card <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_infos">verify_billing_infos api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfosParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction VerifyBillingInfos(string accountId, string billingInfoId, BillingInfoVerify body = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}/verify", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Verify a billing information's credit card <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_infos">verify_billing_infos api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfosParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> VerifyBillingInfosAsync(string accountId, string billingInfoId, BillingInfoVerify body = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}/verify", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Verify a billing information's credit card cvv <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_infos_cvv">verify_billing_infos_cvv api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfosCvvParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction VerifyBillingInfosCvv(string accountId, string billingInfoId, BillingInfoVerifyCVV body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}/verify_cvv", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Verify a billing information's credit card cvv <see href="https://developers.recurly.com/api/v2021-02-25#operation/verify_billing_infos_cvv">verify_billing_infos_cvv api documentation</see>
        /// </summary>
        /// <param name="VerifyBillingInfosCvvParams">Optional Parameters for the request</param>
        /// <returns>
        /// Transaction information from verify.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> VerifyBillingInfosCvvAsync(string accountId, string billingInfoId, BillingInfoVerifyCVV body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "billing_info_id", billingInfoId } };
            var url = this.InterpolatePath("/accounts/{account_id}/billing_infos/{billing_info_id}/verify_cvv", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List the coupon redemptions for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_coupon_redemptions">list_account_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="ListAccountCouponRedemptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the coupon redemptions on an account.
        /// </returns>
        public Pager<CouponRedemption> ListAccountCouponRedemptions(string accountId, ListAccountCouponRedemptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountCouponRedemptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List the coupon redemptions that are active on an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_active_coupon_redemptions">list_active_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="ListActiveCouponRedemptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// Active coupon redemptions on an account.
        /// </returns>
        public Pager<CouponRedemption> ListActiveCouponRedemptions(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return Pager<CouponRedemption>.Build(url, null, options, this);
        }





        /// <summary>
        /// Generate an active coupon redemption on an account or subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="CreateCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption CreateCouponRedemption(string accountId, CouponRedemptionCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Generate an active coupon redemption on an account or subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="CreateCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> CreateCouponRedemptionAsync(string accountId, CouponRedemptionCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="RemoveCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption RemoveCouponRedemption(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="RemoveCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> RemoveCouponRedemptionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/active", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Show the coupon redemption <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_coupon_redemption">get_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="GetCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption GetCouponRedemption(string accountId, string couponRedemptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Show the coupon redemption <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_coupon_redemption">get_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="GetCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> GetCouponRedemptionAsync(string accountId, string couponRedemptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete the coupon redemption <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_coupon_redemption_by_id">remove_coupon_redemption_by_id api documentation</see>
        /// </summary>
        /// <param name="RemoveCouponRedemptionByIdParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption RemoveCouponRedemptionById(string accountId, string couponRedemptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete the coupon redemption <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_coupon_redemption_by_id">remove_coupon_redemption_by_id api documentation</see>
        /// </summary>
        /// <param name="RemoveCouponRedemptionByIdParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> RemoveCouponRedemptionByIdAsync(string accountId, string couponRedemptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/accounts/{account_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List an account's credit payments <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_credit_payments">list_account_credit_payments api documentation</see>
        /// </summary>
        /// <param name="ListAccountCreditPaymentsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the account's credit payments.
        /// </returns>
        public Pager<CreditPayment> ListAccountCreditPayments(string accountId, ListAccountCreditPaymentsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountCreditPaymentsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/credit_payments", urlParams);
            return Pager<CreditPayment>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List external accounts for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_external_account">list_account_external_account api documentation</see>
        /// </summary>
        /// <param name="ListAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of external accounts on an account.
        /// </returns>
        public Pager<ExternalAccount> ListAccountExternalAccount(string accountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts", urlParams);
            return Pager<ExternalAccount>.Build(url, null, options, this);
        }





        /// <summary>
        /// Create an external account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account_external_account">create_account_external_account api documentation</see>
        /// </summary>
        /// <param name="CreateAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A representation of the created external_account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalAccount CreateAccountExternalAccount(string accountId, ExternalAccountCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts", urlParams);
            return MakeRequest<ExternalAccount>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an external account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account_external_account">create_account_external_account api documentation</see>
        /// </summary>
        /// <param name="CreateAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A representation of the created external_account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalAccount> CreateAccountExternalAccountAsync(string accountId, ExternalAccountCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts", urlParams);
            return MakeRequestAsync<ExternalAccount>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Get an external account for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_external_account">get_account_external_account api documentation</see>
        /// </summary>
        /// <param name="GetAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A external account on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalAccount GetAccountExternalAccount(string accountId, string externalAccountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequest<ExternalAccount>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Get an external account for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_external_account">get_account_external_account api documentation</see>
        /// </summary>
        /// <param name="GetAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A external account on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalAccount> GetAccountExternalAccountAsync(string accountId, string externalAccountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequestAsync<ExternalAccount>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an external account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account_external_account">update_account_external_account api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A representation of the updated external_account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalAccount UpdateAccountExternalAccount(string accountId, string externalAccountId, ExternalAccountUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequest<ExternalAccount>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an external account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_account_external_account">update_account_external_account api documentation</see>
        /// </summary>
        /// <param name="UpdateAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A representation of the updated external_account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalAccount> UpdateAccountExternalAccountAsync(string accountId, string externalAccountId, ExternalAccountUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequestAsync<ExternalAccount>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete an external account for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/delete_account_external_account">delete_account_external_account api documentation</see>
        /// </summary>
        /// <param name="DeleteAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// Successful Delete
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalAccount DeleteAccountExternalAccount(string accountId, string externalAccountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequest<ExternalAccount>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete an external account for an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/delete_account_external_account">delete_account_external_account api documentation</see>
        /// </summary>
        /// <param name="DeleteAccountExternalAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// Successful Delete
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalAccount> DeleteAccountExternalAccountAsync(string accountId, string externalAccountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "external_account_id", externalAccountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/external_accounts/{external_account_id}", urlParams);
            return MakeRequestAsync<ExternalAccount>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external invoices on an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_external_invoices">list_account_external_invoices api documentation</see>
        /// </summary>
        /// <param name="ListAccountExternalInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_invoices on an account.
        /// </returns>
        public Pager<ExternalInvoice> ListAccountExternalInvoices(string accountId, ListAccountExternalInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountExternalInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/external_invoices", urlParams);
            return Pager<ExternalInvoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List an account's invoices <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_invoices">list_account_invoices api documentation</see>
        /// </summary>
        /// <param name="ListAccountInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the account's invoices.
        /// </returns>
        public Pager<Invoice> ListAccountInvoices(string accountId, ListAccountInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an invoice for pending line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="CreateInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreateInvoice(string accountId, InvoiceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an invoice for pending line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="CreateInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreateInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Preview new invoice for pending line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="PreviewInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection PreviewInvoice(string accountId, InvoiceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices/preview", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Preview new invoice for pending line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="PreviewInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> PreviewInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/invoices/preview", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List an account's line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_line_items">list_account_line_items api documentation</see>
        /// </summary>
        /// <param name="ListAccountLineItemsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the account's line items.
        /// </returns>
        public Pager<LineItem> ListAccountLineItems(string accountId, ListAccountLineItemsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountLineItemsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new line item for the account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="CreateLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public LineItem CreateLineItem(string accountId, LineItemCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return MakeRequest<LineItem>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new line item for the account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="CreateLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<LineItem> CreateLineItemAsync(string accountId, LineItemCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/line_items", urlParams);
            return MakeRequestAsync<LineItem>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List an account's notes <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_notes">list_account_notes api documentation</see>
        /// </summary>
        /// <param name="ListAccountNotesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of an account's notes.
        /// </returns>
        public Pager<AccountNote> ListAccountNotes(string accountId, ListAccountNotesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountNotesParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/notes", urlParams);
            return Pager<AccountNote>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account_note">create_account_note api documentation</see>
        /// </summary>
        /// <param name="CreateAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountNote CreateAccountNote(string accountId, AccountNoteCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes", urlParams);
            return MakeRequest<AccountNote>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_account_note">create_account_note api documentation</see>
        /// </summary>
        /// <param name="CreateAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountNote> CreateAccountNoteAsync(string accountId, AccountNoteCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes", urlParams);
            return MakeRequestAsync<AccountNote>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="GetAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AccountNote GetAccountNote(string accountId, string accountNoteId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequest<AccountNote>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="GetAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AccountNote> GetAccountNoteAsync(string accountId, string accountNoteId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequestAsync<AccountNote>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_account_note">remove_account_note api documentation</see>
        /// </summary>
        /// <param name="RemoveAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// Account note deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveAccountNote(string accountId, string accountNoteId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete an account note <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_account_note">remove_account_note api documentation</see>
        /// </summary>
        /// <param name="RemoveAccountNoteParams">Optional Parameters for the request</param>
        /// <returns>
        /// Account note deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveAccountNoteAsync(string accountId, string accountNoteId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "account_note_id", accountNoteId } };
            var url = this.InterpolatePath("/accounts/{account_id}/notes/{account_note_id}", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a list of an account's shipping addresses <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_shipping_addresses">list_shipping_addresses api documentation</see>
        /// </summary>
        /// <param name="ListShippingAddressesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of an account's shipping addresses.
        /// </returns>
        public Pager<ShippingAddress> ListShippingAddresses(string accountId, ListShippingAddressesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListShippingAddressesParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return Pager<ShippingAddress>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new shipping address for the account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="CreateShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress CreateShippingAddress(string accountId, ShippingAddressCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return MakeRequest<ShippingAddress>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new shipping address for the account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="CreateShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> CreateShippingAddressAsync(string accountId, ShippingAddressCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses", urlParams);
            return MakeRequestAsync<ShippingAddress>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="GetShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress GetShippingAddress(string accountId, string shippingAddressId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequest<ShippingAddress>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="GetShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> GetShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<ShippingAddress>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="UpdateShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingAddress UpdateShippingAddress(string accountId, string shippingAddressId, ShippingAddressUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequest<ShippingAddress>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="UpdateShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingAddress> UpdateShippingAddressAsync(string accountId, string shippingAddressId, ShippingAddressUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<ShippingAddress>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="RemoveShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveShippingAddress(string accountId, string shippingAddressId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove an account's shipping address <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="RemoveShippingAddressParams">Optional Parameters for the request</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId }, { "shipping_address_id", shippingAddressId } };
            var url = this.InterpolatePath("/accounts/{account_id}/shipping_addresses/{shipping_address_id}", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List an account's subscriptions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_subscriptions">list_account_subscriptions api documentation</see>
        /// </summary>
        /// <param name="ListAccountSubscriptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the account's subscriptions.
        /// </returns>
        public Pager<Subscription> ListAccountSubscriptions(string accountId, ListAccountSubscriptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountSubscriptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/subscriptions", urlParams);
            return Pager<Subscription>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List an account's transactions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_transactions">list_account_transactions api documentation</see>
        /// </summary>
        /// <param name="ListAccountTransactionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the account's transactions.
        /// </returns>
        public Pager<Transaction> ListAccountTransactions(string accountId, ListAccountTransactionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountTransactionsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/transactions", urlParams);
            return Pager<Transaction>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List an account's child accounts <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_child_accounts">list_child_accounts api documentation</see>
        /// </summary>
        /// <param name="ListChildAccountsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of an account's child accounts.
        /// </returns>
        public Pager<Account> ListChildAccounts(string accountId, ListChildAccountsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListChildAccountsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/accounts", urlParams);
            return Pager<Account>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List a site's account acquisition data <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_acquisition">list_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="ListAccountAcquisitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's account acquisition data.
        /// </returns>
        public Pager<AccountAcquisition> ListAccountAcquisition(ListAccountAcquisitionParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListAccountAcquisitionParams()).ToDictionary();
            var url = this.InterpolatePath("/acquisitions", urlParams);
            return Pager<AccountAcquisition>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List a site's coupons <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_coupons">list_coupons api documentation</see>
        /// </summary>
        /// <param name="ListCouponsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's coupons.
        /// </returns>
        public Pager<Coupon> ListCoupons(ListCouponsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListCouponsParams()).ToDictionary();
            var url = this.InterpolatePath("/coupons", urlParams);
            return Pager<Coupon>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="CreateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon CreateCoupon(CouponCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/coupons", urlParams);
            return MakeRequest<Coupon>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="CreateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> CreateCouponAsync(CouponCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/coupons", urlParams);
            return MakeRequestAsync<Coupon>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="GetCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon GetCoupon(string couponId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequest<Coupon>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="GetCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> GetCouponAsync(string couponId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequestAsync<Coupon>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an active coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="UpdateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon UpdateCoupon(string couponId, CouponUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequest<Coupon>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an active coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="UpdateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> UpdateCouponAsync(string couponId, CouponUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequestAsync<Coupon>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Expire a coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_coupon">deactivate_coupon api documentation</see>
        /// </summary>
        /// <param name="DeactivateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The expired Coupon
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon DeactivateCoupon(string couponId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequest<Coupon>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Expire a coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_coupon">deactivate_coupon api documentation</see>
        /// </summary>
        /// <param name="DeactivateCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The expired Coupon
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> DeactivateCouponAsync(string couponId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}", urlParams);
            return MakeRequestAsync<Coupon>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Generate unique coupon codes <see href="https://developers.recurly.com/api/v2021-02-25#operation/generate_unique_coupon_codes">generate_unique_coupon_codes api documentation</see>
        /// </summary>
        /// <param name="GenerateUniqueCouponCodesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A set of parameters that can be passed to the `list_unique_coupon_codes` endpoint to obtain only the newly generated `UniqueCouponCodes`. 
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCodeParams GenerateUniqueCouponCodes(string couponId, CouponBulkCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/generate", urlParams);
            return MakeRequest<UniqueCouponCodeParams>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Generate unique coupon codes <see href="https://developers.recurly.com/api/v2021-02-25#operation/generate_unique_coupon_codes">generate_unique_coupon_codes api documentation</see>
        /// </summary>
        /// <param name="GenerateUniqueCouponCodesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A set of parameters that can be passed to the `list_unique_coupon_codes` endpoint to obtain only the newly generated `UniqueCouponCodes`. 
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCodeParams> GenerateUniqueCouponCodesAsync(string couponId, CouponBulkCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/generate", urlParams);
            return MakeRequestAsync<UniqueCouponCodeParams>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Generate unique coupon codes synchronously <see href="https://developers.recurly.com/api/v2021-02-25#operation/generate_unique_coupon_codes_sync">generate_unique_coupon_codes_sync api documentation</see>
        /// </summary>
        /// <param name="GenerateUniqueCouponCodesSyncParams">Optional Parameters for the request</param>
        /// <returns>
        /// The newly generated unique coupon codes.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCodeGenerationResponse GenerateUniqueCouponCodesSync(string couponId, CouponBulkCreateSync body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/generate_sync", urlParams);
            return MakeRequest<UniqueCouponCodeGenerationResponse>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Generate unique coupon codes synchronously <see href="https://developers.recurly.com/api/v2021-02-25#operation/generate_unique_coupon_codes_sync">generate_unique_coupon_codes_sync api documentation</see>
        /// </summary>
        /// <param name="GenerateUniqueCouponCodesSyncParams">Optional Parameters for the request</param>
        /// <returns>
        /// The newly generated unique coupon codes.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCodeGenerationResponse> GenerateUniqueCouponCodesSyncAsync(string couponId, CouponBulkCreateSync body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/generate_sync", urlParams);
            return MakeRequestAsync<UniqueCouponCodeGenerationResponse>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Restore an inactive coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/restore_coupon">restore_coupon api documentation</see>
        /// </summary>
        /// <param name="RestoreCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The restored coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Coupon RestoreCoupon(string couponId, CouponUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/restore", urlParams);
            return MakeRequest<Coupon>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Restore an inactive coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/restore_coupon">restore_coupon api documentation</see>
        /// </summary>
        /// <param name="RestoreCouponParams">Optional Parameters for the request</param>
        /// <returns>
        /// The restored coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Coupon> RestoreCouponAsync(string couponId, CouponUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var url = this.InterpolatePath("/coupons/{coupon_id}/restore", urlParams);
            return MakeRequestAsync<Coupon>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List unique coupon codes associated with a bulk coupon <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_unique_coupon_codes">list_unique_coupon_codes api documentation</see>
        /// </summary>
        /// <param name="ListUniqueCouponCodesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of unique coupon codes that were generated
        /// </returns>
        public Pager<UniqueCouponCode> ListUniqueCouponCodes(string couponId, ListUniqueCouponCodesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "coupon_id", couponId } };
            var queryParams = (optionalParams ?? new ListUniqueCouponCodesParams()).ToDictionary();
            var url = this.InterpolatePath("/coupons/{coupon_id}/unique_coupon_codes", urlParams);
            return Pager<UniqueCouponCode>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List a site's credit payments <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_credit_payments">list_credit_payments api documentation</see>
        /// </summary>
        /// <param name="ListCreditPaymentsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's credit payments.
        /// </returns>
        public Pager<CreditPayment> ListCreditPayments(ListCreditPaymentsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListCreditPaymentsParams()).ToDictionary();
            var url = this.InterpolatePath("/credit_payments", urlParams);
            return Pager<CreditPayment>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a credit payment <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="GetCreditPaymentParams">Optional Parameters for the request</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CreditPayment GetCreditPayment(string creditPaymentId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "credit_payment_id", creditPaymentId } };
            var url = this.InterpolatePath("/credit_payments/{credit_payment_id}", urlParams);
            return MakeRequest<CreditPayment>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a credit payment <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="GetCreditPaymentParams">Optional Parameters for the request</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CreditPayment> GetCreditPaymentAsync(string creditPaymentId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "credit_payment_id", creditPaymentId } };
            var url = this.InterpolatePath("/credit_payments/{credit_payment_id}", urlParams);
            return MakeRequestAsync<CreditPayment>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's custom field definitions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_custom_field_definitions">list_custom_field_definitions api documentation</see>
        /// </summary>
        /// <param name="ListCustomFieldDefinitionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's custom field definitions.
        /// </returns>
        public Pager<CustomFieldDefinition> ListCustomFieldDefinitions(ListCustomFieldDefinitionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListCustomFieldDefinitionsParams()).ToDictionary();
            var url = this.InterpolatePath("/custom_field_definitions", urlParams);
            return Pager<CustomFieldDefinition>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an custom field definition <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="GetCustomFieldDefinitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CustomFieldDefinition GetCustomFieldDefinition(string customFieldDefinitionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "custom_field_definition_id", customFieldDefinitionId } };
            var url = this.InterpolatePath("/custom_field_definitions/{custom_field_definition_id}", urlParams);
            return MakeRequest<CustomFieldDefinition>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an custom field definition <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="GetCustomFieldDefinitionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CustomFieldDefinition> GetCustomFieldDefinitionAsync(string customFieldDefinitionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "custom_field_definition_id", customFieldDefinitionId } };
            var url = this.InterpolatePath("/custom_field_definitions/{custom_field_definition_id}", urlParams);
            return MakeRequestAsync<CustomFieldDefinition>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Create a new general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_general_ledger_account">create_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="CreateGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GeneralLedgerAccount CreateGeneralLedgerAccount(GeneralLedgerAccountCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/general_ledger_accounts", urlParams);
            return MakeRequest<GeneralLedgerAccount>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_general_ledger_account">create_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="CreateGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GeneralLedgerAccount> CreateGeneralLedgerAccountAsync(GeneralLedgerAccountCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/general_ledger_accounts", urlParams);
            return MakeRequestAsync<GeneralLedgerAccount>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's general ledger accounts <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_general_ledger_accounts">list_general_ledger_accounts api documentation</see>
        /// </summary>
        /// <param name="ListGeneralLedgerAccountsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's general ledger accounts.
        /// </returns>
        public Pager<GeneralLedgerAccount> ListGeneralLedgerAccounts(ListGeneralLedgerAccountsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListGeneralLedgerAccountsParams()).ToDictionary();
            var url = this.InterpolatePath("/general_ledger_accounts", urlParams);
            return Pager<GeneralLedgerAccount>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_general_ledger_account">get_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="GetGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GeneralLedgerAccount GetGeneralLedgerAccount(string generalLedgerAccountId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "general_ledger_account_id", generalLedgerAccountId } };
            var url = this.InterpolatePath("/general_ledger_accounts/{general_ledger_account_id}", urlParams);
            return MakeRequest<GeneralLedgerAccount>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_general_ledger_account">get_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="GetGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// A general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GeneralLedgerAccount> GetGeneralLedgerAccountAsync(string generalLedgerAccountId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "general_ledger_account_id", generalLedgerAccountId } };
            var url = this.InterpolatePath("/general_ledger_accounts/{general_ledger_account_id}", urlParams);
            return MakeRequestAsync<GeneralLedgerAccount>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update a general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_general_ledger_account">update_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="UpdateGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GeneralLedgerAccount UpdateGeneralLedgerAccount(string generalLedgerAccountId, GeneralLedgerAccountUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "general_ledger_account_id", generalLedgerAccountId } };
            var url = this.InterpolatePath("/general_ledger_accounts/{general_ledger_account_id}", urlParams);
            return MakeRequest<GeneralLedgerAccount>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update a general ledger account <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_general_ledger_account">update_general_ledger_account api documentation</see>
        /// </summary>
        /// <param name="UpdateGeneralLedgerAccountParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated general ledger account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GeneralLedgerAccount> UpdateGeneralLedgerAccountAsync(string generalLedgerAccountId, GeneralLedgerAccountUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "general_ledger_account_id", generalLedgerAccountId } };
            var url = this.InterpolatePath("/general_ledger_accounts/{general_ledger_account_id}", urlParams);
            return MakeRequestAsync<GeneralLedgerAccount>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Get a single Performance Obligation. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_performance_obligation">get_performance_obligation api documentation</see>
        /// </summary>
        /// <param name="GetPerformanceObligationParams">Optional Parameters for the request</param>
        /// <returns>
        /// A single Performance Obligation.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public PerformanceObligation GetPerformanceObligation(string performanceObligationId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "performance_obligation_id", performanceObligationId } };
            var url = this.InterpolatePath("/performance_obligations/{performance_obligation_id}", urlParams);
            return MakeRequest<PerformanceObligation>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Get a single Performance Obligation. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_performance_obligation">get_performance_obligation api documentation</see>
        /// </summary>
        /// <param name="GetPerformanceObligationParams">Optional Parameters for the request</param>
        /// <returns>
        /// A single Performance Obligation.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<PerformanceObligation> GetPerformanceObligationAsync(string performanceObligationId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "performance_obligation_id", performanceObligationId } };
            var url = this.InterpolatePath("/performance_obligations/{performance_obligation_id}", urlParams);
            return MakeRequestAsync<PerformanceObligation>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Get a site's Performance Obligations <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_performance_obligations">get_performance_obligations api documentation</see>
        /// </summary>
        /// <param name="GetPerformanceObligationsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of Performance Obligations.
        /// </returns>
        public Pager<PerformanceObligation> GetPerformanceObligations(RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/performance_obligations", urlParams);
            return Pager<PerformanceObligation>.Build(url, null, options, this);
        }





        /// <summary>
        /// List an invoice template's associated accounts <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_invoice_template_accounts">list_invoice_template_accounts api documentation</see>
        /// </summary>
        /// <param name="ListInvoiceTemplateAccountsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of an invoice template's associated accounts.
        /// </returns>
        public Pager<Account> ListInvoiceTemplateAccounts(string invoiceTemplateId, ListInvoiceTemplateAccountsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_template_id", invoiceTemplateId } };
            var queryParams = (optionalParams ?? new ListInvoiceTemplateAccountsParams()).ToDictionary();
            var url = this.InterpolatePath("/invoice_templates/{invoice_template_id}/accounts", urlParams);
            return Pager<Account>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List a site's items <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_items">list_items api documentation</see>
        /// </summary>
        /// <param name="ListItemsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's items.
        /// </returns>
        public Pager<Item> ListItems(ListItemsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListItemsParams()).ToDictionary();
            var url = this.InterpolatePath("/items", urlParams);
            return Pager<Item>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new item <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_item">create_item api documentation</see>
        /// </summary>
        /// <param name="CreateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item CreateItem(ItemCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/items", urlParams);
            return MakeRequest<Item>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new item <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_item">create_item api documentation</see>
        /// </summary>
        /// <param name="CreateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> CreateItemAsync(ItemCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/items", urlParams);
            return MakeRequestAsync<Item>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an item <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_item">get_item api documentation</see>
        /// </summary>
        /// <param name="GetItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item GetItem(string itemId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an item <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_item">get_item api documentation</see>
        /// </summary>
        /// <param name="GetItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> GetItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an active item <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_item">update_item api documentation</see>
        /// </summary>
        /// <param name="UpdateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item UpdateItem(string itemId, ItemUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an active item <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_item">update_item api documentation</see>
        /// </summary>
        /// <param name="UpdateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> UpdateItemAsync(string itemId, ItemUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate an item <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_item">deactivate_item api documentation</see>
        /// </summary>
        /// <param name="DeactivateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item DeactivateItem(string itemId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequest<Item>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate an item <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_item">deactivate_item api documentation</see>
        /// </summary>
        /// <param name="DeactivateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> DeactivateItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}", urlParams);
            return MakeRequestAsync<Item>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Reactivate an inactive item <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_item">reactivate_item api documentation</see>
        /// </summary>
        /// <param name="ReactivateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Item ReactivateItem(string itemId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}/reactivate", urlParams);
            return MakeRequest<Item>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Reactivate an inactive item <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_item">reactivate_item api documentation</see>
        /// </summary>
        /// <param name="ReactivateItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Item> ReactivateItemAsync(string itemId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "item_id", itemId } };
            var url = this.InterpolatePath("/items/{item_id}/reactivate", urlParams);
            return MakeRequestAsync<Item>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's measured units <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_measured_unit">list_measured_unit api documentation</see>
        /// </summary>
        /// <param name="ListMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's measured units.
        /// </returns>
        public Pager<MeasuredUnit> ListMeasuredUnit(ListMeasuredUnitParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListMeasuredUnitParams()).ToDictionary();
            var url = this.InterpolatePath("/measured_units", urlParams);
            return Pager<MeasuredUnit>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_measured_unit">create_measured_unit api documentation</see>
        /// </summary>
        /// <param name="CreateMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new measured unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public MeasuredUnit CreateMeasuredUnit(MeasuredUnitCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/measured_units", urlParams);
            return MakeRequest<MeasuredUnit>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_measured_unit">create_measured_unit api documentation</see>
        /// </summary>
        /// <param name="CreateMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new measured unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<MeasuredUnit> CreateMeasuredUnitAsync(MeasuredUnitCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/measured_units", urlParams);
            return MakeRequestAsync<MeasuredUnit>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_measured_unit">get_measured_unit api documentation</see>
        /// </summary>
        /// <param name="GetMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public MeasuredUnit GetMeasuredUnit(string measuredUnitId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequest<MeasuredUnit>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_measured_unit">get_measured_unit api documentation</see>
        /// </summary>
        /// <param name="GetMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// An item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<MeasuredUnit> GetMeasuredUnitAsync(string measuredUnitId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequestAsync<MeasuredUnit>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_measured_unit">update_measured_unit api documentation</see>
        /// </summary>
        /// <param name="UpdateMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated measured_unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public MeasuredUnit UpdateMeasuredUnit(string measuredUnitId, MeasuredUnitUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequest<MeasuredUnit>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_measured_unit">update_measured_unit api documentation</see>
        /// </summary>
        /// <param name="UpdateMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated measured_unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<MeasuredUnit> UpdateMeasuredUnitAsync(string measuredUnitId, MeasuredUnitUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequestAsync<MeasuredUnit>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_measured_unit">remove_measured_unit api documentation</see>
        /// </summary>
        /// <param name="RemoveMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// A measured unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public MeasuredUnit RemoveMeasuredUnit(string measuredUnitId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequest<MeasuredUnit>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove a measured unit <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_measured_unit">remove_measured_unit api documentation</see>
        /// </summary>
        /// <param name="RemoveMeasuredUnitParams">Optional Parameters for the request</param>
        /// <returns>
        /// A measured unit.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<MeasuredUnit> RemoveMeasuredUnitAsync(string measuredUnitId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "measured_unit_id", measuredUnitId } };
            var url = this.InterpolatePath("/measured_units/{measured_unit_id}", urlParams);
            return MakeRequestAsync<MeasuredUnit>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's external products <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_products">list_external_products api documentation</see>
        /// </summary>
        /// <param name="ListExternalProductsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_products on a site.
        /// </returns>
        public Pager<ExternalProduct> ListExternalProducts(ListExternalProductsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListExternalProductsParams()).ToDictionary();
            var url = this.InterpolatePath("/external_products", urlParams);
            return Pager<ExternalProduct>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_product">create_external_product api documentation</see>
        /// </summary>
        /// <param name="CreateExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external product
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProduct CreateExternalProduct(ExternalProductCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/external_products", urlParams);
            return MakeRequest<ExternalProduct>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_product">create_external_product api documentation</see>
        /// </summary>
        /// <param name="CreateExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external product
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProduct> CreateExternalProductAsync(ExternalProductCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/external_products", urlParams);
            return MakeRequestAsync<ExternalProduct>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_product">get_external_product api documentation</see>
        /// </summary>
        /// <param name="GetExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProduct GetExternalProduct(string externalProductId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequest<ExternalProduct>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_product">get_external_product api documentation</see>
        /// </summary>
        /// <param name="GetExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProduct> GetExternalProductAsync(string externalProductId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequestAsync<ExternalProduct>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_external_product">update_external_product api documentation</see>
        /// </summary>
        /// <param name="UpdateExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProduct UpdateExternalProduct(string externalProductId, ExternalProductUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequest<ExternalProduct>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_external_product">update_external_product api documentation</see>
        /// </summary>
        /// <param name="UpdateExternalProductParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProduct> UpdateExternalProductAsync(string externalProductId, ExternalProductUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequestAsync<ExternalProduct>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_external_products">deactivate_external_products api documentation</see>
        /// </summary>
        /// <param name="DeactivateExternalProductsParams">Optional Parameters for the request</param>
        /// <returns>
        /// Deactivated external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProduct DeactivateExternalProducts(string externalProductId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequest<ExternalProduct>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_external_products">deactivate_external_products api documentation</see>
        /// </summary>
        /// <param name="DeactivateExternalProductsParams">Optional Parameters for the request</param>
        /// <returns>
        /// Deactivated external product.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProduct> DeactivateExternalProductsAsync(string externalProductId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}", urlParams);
            return MakeRequestAsync<ExternalProduct>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external product references for an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_product_external_product_references">list_external_product_external_product_references api documentation</see>
        /// </summary>
        /// <param name="ListExternalProductExternalProductReferencesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external product references for an external product.
        /// </returns>
        public Pager<ExternalProductReferenceCollection> ListExternalProductExternalProductReferences(string externalProductId, ListExternalProductExternalProductReferencesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var queryParams = (optionalParams ?? new ListExternalProductExternalProductReferencesParams()).ToDictionary();
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references", urlParams);
            return Pager<ExternalProductReferenceCollection>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an external product reference on an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_product_external_product_reference">create_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="CreateExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for the external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProductReferenceMini CreateExternalProductExternalProductReference(string externalProductId, ExternalProductReferenceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references", urlParams);
            return MakeRequest<ExternalProductReferenceMini>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an external product reference on an external product <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_product_external_product_reference">create_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="CreateExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for the external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProductReferenceMini> CreateExternalProductExternalProductReferenceAsync(string externalProductId, ExternalProductReferenceCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references", urlParams);
            return MakeRequestAsync<ExternalProductReferenceMini>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an external product reference <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_product_external_product_reference">get_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="GetExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProductReferenceMini GetExternalProductExternalProductReference(string externalProductId, string externalProductReferenceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId }, { "external_product_reference_id", externalProductReferenceId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references/{external_product_reference_id}", urlParams);
            return MakeRequest<ExternalProductReferenceMini>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an external product reference <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_product_external_product_reference">get_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="GetExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProductReferenceMini> GetExternalProductExternalProductReferenceAsync(string externalProductId, string externalProductReferenceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId }, { "external_product_reference_id", externalProductReferenceId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references/{external_product_reference_id}", urlParams);
            return MakeRequestAsync<ExternalProductReferenceMini>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate an external product reference <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_external_product_external_product_reference">deactivate_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="DeactivateExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalProductReferenceMini DeactivateExternalProductExternalProductReference(string externalProductId, string externalProductReferenceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId }, { "external_product_reference_id", externalProductReferenceId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references/{external_product_reference_id}", urlParams);
            return MakeRequest<ExternalProductReferenceMini>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate an external product reference <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_external_product_external_product_reference">deactivate_external_product_external_product_reference api documentation</see>
        /// </summary>
        /// <param name="DeactivateExternalProductExternalProductReferenceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external product reference.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalProductReferenceMini> DeactivateExternalProductExternalProductReferenceAsync(string externalProductId, string externalProductReferenceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_product_id", externalProductId }, { "external_product_reference_id", externalProductReferenceId } };
            var url = this.InterpolatePath("/external_products/{external_product_id}/external_product_references/{external_product_reference_id}", urlParams);
            return MakeRequestAsync<ExternalProductReferenceMini>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Create an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_subscription">create_external_subscription api documentation</see>
        /// </summary>
        /// <param name="CreateExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external subscription
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalSubscription CreateExternalSubscription(ExternalSubscriptionCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/external_subscriptions", urlParams);
            return MakeRequest<ExternalSubscription>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_subscription">create_external_subscription api documentation</see>
        /// </summary>
        /// <param name="CreateExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external subscription
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalSubscription> CreateExternalSubscriptionAsync(ExternalSubscriptionCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/external_subscriptions", urlParams);
            return MakeRequestAsync<ExternalSubscription>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external subscriptions on a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_subscriptions">list_external_subscriptions api documentation</see>
        /// </summary>
        /// <param name="ListExternalSubscriptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_subscriptions on a site.
        /// </returns>
        public Pager<ExternalSubscription> ListExternalSubscriptions(ListExternalSubscriptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListExternalSubscriptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/external_subscriptions", urlParams);
            return Pager<ExternalSubscription>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_subscription">get_external_subscription api documentation</see>
        /// </summary>
        /// <param name="GetExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalSubscription GetExternalSubscription(string externalSubscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}", urlParams);
            return MakeRequest<ExternalSubscription>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_subscription">get_external_subscription api documentation</see>
        /// </summary>
        /// <param name="GetExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalSubscription> GetExternalSubscriptionAsync(string externalSubscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}", urlParams);
            return MakeRequestAsync<ExternalSubscription>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/put_external_subscription">put_external_subscription api documentation</see>
        /// </summary>
        /// <param name="PutExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalSubscription PutExternalSubscription(string externalSubscriptionId, ExternalSubscriptionUpdate body = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}", urlParams);
            return MakeRequest<ExternalSubscription>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/put_external_subscription">put_external_subscription api documentation</see>
        /// </summary>
        /// <param name="PutExternalSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an external subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalSubscription> PutExternalSubscriptionAsync(string externalSubscriptionId, ExternalSubscriptionUpdate body = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}", urlParams);
            return MakeRequestAsync<ExternalSubscription>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external invoices on an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_subscription_external_invoices">list_external_subscription_external_invoices api documentation</see>
        /// </summary>
        /// <param name="ListExternalSubscriptionExternalInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_invoices on a site.
        /// </returns>
        public Pager<ExternalInvoice> ListExternalSubscriptionExternalInvoices(string externalSubscriptionId, ListExternalSubscriptionExternalInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var queryParams = (optionalParams ?? new ListExternalSubscriptionExternalInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_invoices", urlParams);
            return Pager<ExternalInvoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an external invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_invoice">create_external_invoice api documentation</see>
        /// </summary>
        /// <param name="CreateExternalInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalInvoice CreateExternalInvoice(string externalSubscriptionId, ExternalInvoiceCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_invoices", urlParams);
            return MakeRequest<ExternalInvoice>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an external invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_external_invoice">create_external_invoice api documentation</see>
        /// </summary>
        /// <param name="CreateExternalInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalInvoice> CreateExternalInvoiceAsync(string externalSubscriptionId, ExternalInvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_invoices", urlParams);
            return MakeRequestAsync<ExternalInvoice>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's invoices <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_invoices">list_invoices api documentation</see>
        /// </summary>
        /// <param name="ListInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's invoices.
        /// </returns>
        public Pager<Invoice> ListInvoices(ListInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="GetInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice GetInvoice(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="GetInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_invoice">update_invoice api documentation</see>
        /// </summary>
        /// <param name="UpdateInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice UpdateInvoice(string invoiceId, InvoiceUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_invoice">update_invoice api documentation</see>
        /// </summary>
        /// <param name="UpdateInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> UpdateInvoiceAsync(string invoiceId, InvoiceUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch an invoice as a PDF <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice_pdf">get_invoice_pdf api documentation</see>
        /// </summary>
        /// <param name="GetInvoicePdfParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice as a PDF.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BinaryFile GetInvoicePdf(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}.pdf", urlParams);
            return MakeRequest<BinaryFile>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an invoice as a PDF <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice_pdf">get_invoice_pdf api documentation</see>
        /// </summary>
        /// <param name="GetInvoicePdfParams">Optional Parameters for the request</param>
        /// <returns>
        /// An invoice as a PDF.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BinaryFile> GetInvoicePdfAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}.pdf", urlParams);
            return MakeRequestAsync<BinaryFile>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Apply available credit to a pending or past due charge invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/apply_credit_balance">apply_credit_balance api documentation</see>
        /// </summary>
        /// <param name="ApplyCreditBalanceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice ApplyCreditBalance(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/apply_credit_balance", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Apply available credit to a pending or past due charge invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/apply_credit_balance">apply_credit_balance api documentation</see>
        /// </summary>
        /// <param name="ApplyCreditBalanceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> ApplyCreditBalanceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/apply_credit_balance", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="CollectInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice CollectInvoice(string invoiceId, InvoiceCollect body = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/collect", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="CollectInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> CollectInvoiceAsync(string invoiceId, InvoiceCollect body = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/collect", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Mark an open invoice as failed <see href="https://developers.recurly.com/api/v2021-02-25#operation/mark_invoice_failed">mark_invoice_failed api documentation</see>
        /// </summary>
        /// <param name="MarkInvoiceFailedParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice MarkInvoiceFailed(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_failed", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Mark an open invoice as failed <see href="https://developers.recurly.com/api/v2021-02-25#operation/mark_invoice_failed">mark_invoice_failed api documentation</see>
        /// </summary>
        /// <param name="MarkInvoiceFailedParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> MarkInvoiceFailedAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_failed", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Mark an open invoice as successful <see href="https://developers.recurly.com/api/v2021-02-25#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="MarkInvoiceSuccessfulParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice MarkInvoiceSuccessful(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_successful", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Mark an open invoice as successful <see href="https://developers.recurly.com/api/v2021-02-25#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="MarkInvoiceSuccessfulParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> MarkInvoiceSuccessfulAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/mark_successful", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="ReopenInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice ReopenInvoice(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/reopen", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="ReopenInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> ReopenInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/reopen", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Void a credit invoice. <see href="https://developers.recurly.com/api/v2021-02-25#operation/void_invoice">void_invoice api documentation</see>
        /// </summary>
        /// <param name="VoidInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice VoidInvoice(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/void", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Void a credit invoice. <see href="https://developers.recurly.com/api/v2021-02-25#operation/void_invoice">void_invoice api documentation</see>
        /// </summary>
        /// <param name="VoidInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> VoidInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/void", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Record an external payment for a manual invoices. <see href="https://developers.recurly.com/api/v2021-02-25#operation/record_external_transaction">record_external_transaction api documentation</see>
        /// </summary>
        /// <param name="RecordExternalTransactionParams">Optional Parameters for the request</param>
        /// <returns>
        /// The recorded transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction RecordExternalTransaction(string invoiceId, ExternalTransaction body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/transactions", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Record an external payment for a manual invoices. <see href="https://developers.recurly.com/api/v2021-02-25#operation/record_external_transaction">record_external_transaction api documentation</see>
        /// </summary>
        /// <param name="RecordExternalTransactionParams">Optional Parameters for the request</param>
        /// <returns>
        /// The recorded transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> RecordExternalTransactionAsync(string invoiceId, ExternalTransaction body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/transactions", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List an invoice's line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_invoice_line_items">list_invoice_line_items api documentation</see>
        /// </summary>
        /// <param name="ListInvoiceLineItemsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the invoice's line items.
        /// </returns>
        public Pager<LineItem> ListInvoiceLineItems(string invoiceId, ListInvoiceLineItemsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var queryParams = (optionalParams ?? new ListInvoiceLineItemsParams()).ToDictionary();
            var url = this.InterpolatePath("/invoices/{invoice_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List the coupon redemptions applied to an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_invoice_coupon_redemptions">list_invoice_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="ListInvoiceCouponRedemptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the coupon redemptions associated with the invoice.
        /// </returns>
        public Pager<CouponRedemption> ListInvoiceCouponRedemptions(string invoiceId, ListInvoiceCouponRedemptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var queryParams = (optionalParams ?? new ListInvoiceCouponRedemptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/invoices/{invoice_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List an invoice's related credit or charge invoices <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_related_invoices">list_related_invoices api documentation</see>
        /// </summary>
        /// <param name="ListRelatedInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the credit or charge invoices associated with the invoice.
        /// </returns>
        public Pager<Invoice> ListRelatedInvoices(string invoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/related_invoices", urlParams);
            return Pager<Invoice>.Build(url, null, options, this);
        }





        /// <summary>
        /// Refund an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="RefundInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Invoice RefundInvoice(string invoiceId, InvoiceRefund body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/refund", urlParams);
            return MakeRequest<Invoice>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Refund an invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="RefundInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Invoice> RefundInvoiceAsync(string invoiceId, InvoiceRefund body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_id", invoiceId } };
            var url = this.InterpolatePath("/invoices/{invoice_id}/refund", urlParams);
            return MakeRequestAsync<Invoice>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_line_items">list_line_items api documentation</see>
        /// </summary>
        /// <param name="ListLineItemsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's line items.
        /// </returns>
        public Pager<LineItem> ListLineItems(ListLineItemsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListLineItemsParams()).ToDictionary();
            var url = this.InterpolatePath("/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a line item <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="GetLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public LineItem GetLineItem(string lineItemId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequest<LineItem>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a line item <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="GetLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<LineItem> GetLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequestAsync<LineItem>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete an uninvoiced line item <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="RemoveLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveLineItem(string lineItemId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete an uninvoiced line item <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="RemoveLineItemParams">Optional Parameters for the request</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "line_item_id", lineItemId } };
            var url = this.InterpolatePath("/line_items/{line_item_id}", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's plans <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_plans">list_plans api documentation</see>
        /// </summary>
        /// <param name="ListPlansParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of plans.
        /// </returns>
        public Pager<Plan> ListPlans(ListPlansParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListPlansParams()).ToDictionary();
            var url = this.InterpolatePath("/plans", urlParams);
            return Pager<Plan>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="CreatePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan CreatePlan(PlanCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/plans", urlParams);
            return MakeRequest<Plan>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="CreatePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> CreatePlanAsync(PlanCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/plans", urlParams);
            return MakeRequestAsync<Plan>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="GetPlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan GetPlan(string planId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="GetPlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> GetPlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="UpdatePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan UpdatePlan(string planId, PlanUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="UpdatePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> UpdatePlanAsync(string planId, PlanUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="RemovePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Plan RemovePlan(string planId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequest<Plan>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove a plan <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="RemovePlanParams">Optional Parameters for the request</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Plan> RemovePlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}", urlParams);
            return MakeRequestAsync<Plan>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a plan's add-ons <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_plan_add_ons">list_plan_add_ons api documentation</see>
        /// </summary>
        /// <param name="ListPlanAddOnsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of add-ons.
        /// </returns>
        public Pager<AddOn> ListPlanAddOns(string planId, ListPlanAddOnsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var queryParams = (optionalParams ?? new ListPlanAddOnsParams()).ToDictionary();
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return Pager<AddOn>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="CreatePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn CreatePlanAddOn(string planId, AddOnCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return MakeRequest<AddOn>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="CreatePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> CreatePlanAddOnAsync(string planId, AddOnCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons", urlParams);
            return MakeRequestAsync<AddOn>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a plan's add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="GetPlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn GetPlanAddOn(string planId, string addOnId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a plan's add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="GetPlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> GetPlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="UpdatePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn UpdatePlanAddOn(string planId, string addOnId, AddOnUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="UpdatePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> UpdatePlanAddOnAsync(string planId, string addOnId, AddOnUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Remove an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="RemovePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn RemovePlanAddOn(string planId, string addOnId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Remove an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="RemovePlanAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> RemovePlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "plan_id", planId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/plans/{plan_id}/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's price segments <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_price_segments">list_price_segments api documentation</see>
        /// </summary>
        /// <param name="ListPriceSegmentsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of price segments.
        /// </returns>
        public Pager<PriceSegment> ListPriceSegments(ListPriceSegmentsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListPriceSegmentsParams()).ToDictionary();
            var url = this.InterpolatePath("/price_segments", urlParams);
            return Pager<PriceSegment>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a price segment <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_price_segment">get_price_segment api documentation</see>
        /// </summary>
        /// <param name="GetPriceSegmentParams">Optional Parameters for the request</param>
        /// <returns>
        /// A price segment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public PriceSegment GetPriceSegment(string priceSegmentId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "price_segment_id", priceSegmentId } };
            var url = this.InterpolatePath("/price_segments/{price_segment_id}", urlParams);
            return MakeRequest<PriceSegment>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a price segment <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_price_segment">get_price_segment api documentation</see>
        /// </summary>
        /// <param name="GetPriceSegmentParams">Optional Parameters for the request</param>
        /// <returns>
        /// A price segment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<PriceSegment> GetPriceSegmentAsync(string priceSegmentId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "price_segment_id", priceSegmentId } };
            var url = this.InterpolatePath("/price_segments/{price_segment_id}", urlParams);
            return MakeRequestAsync<PriceSegment>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's add-ons <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_add_ons">list_add_ons api documentation</see>
        /// </summary>
        /// <param name="ListAddOnsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of add-ons.
        /// </returns>
        public Pager<AddOn> ListAddOns(ListAddOnsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListAddOnsParams()).ToDictionary();
            var url = this.InterpolatePath("/add_ons", urlParams);
            return Pager<AddOn>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="GetAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public AddOn GetAddOn(string addOnId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/add_ons/{add_on_id}", urlParams);
            return MakeRequest<AddOn>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="GetAddOnParams">Optional Parameters for the request</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<AddOn> GetAddOnAsync(string addOnId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/add_ons/{add_on_id}", urlParams);
            return MakeRequestAsync<AddOn>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's shipping methods <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_shipping_methods">list_shipping_methods api documentation</see>
        /// </summary>
        /// <param name="ListShippingMethodsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's shipping methods.
        /// </returns>
        public Pager<ShippingMethod> ListShippingMethods(ListShippingMethodsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListShippingMethodsParams()).ToDictionary();
            var url = this.InterpolatePath("/shipping_methods", urlParams);
            return Pager<ShippingMethod>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_shipping_method">create_shipping_method api documentation</see>
        /// </summary>
        /// <param name="CreateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingMethod CreateShippingMethod(ShippingMethodCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/shipping_methods", urlParams);
            return MakeRequest<ShippingMethod>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_shipping_method">create_shipping_method api documentation</see>
        /// </summary>
        /// <param name="CreateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A new shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingMethod> CreateShippingMethodAsync(ShippingMethodCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/shipping_methods", urlParams);
            return MakeRequestAsync<ShippingMethod>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_shipping_method">get_shipping_method api documentation</see>
        /// </summary>
        /// <param name="GetShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingMethod GetShippingMethod(string shippingMethodId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequest<ShippingMethod>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_shipping_method">get_shipping_method api documentation</see>
        /// </summary>
        /// <param name="GetShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingMethod> GetShippingMethodAsync(string shippingMethodId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequestAsync<ShippingMethod>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update an active Shipping Method <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_shipping_method">update_shipping_method api documentation</see>
        /// </summary>
        /// <param name="UpdateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingMethod UpdateShippingMethod(string shippingMethodId, ShippingMethodUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequest<ShippingMethod>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update an active Shipping Method <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_shipping_method">update_shipping_method api documentation</see>
        /// </summary>
        /// <param name="UpdateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingMethod> UpdateShippingMethodAsync(string shippingMethodId, ShippingMethodUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequestAsync<ShippingMethod>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate a shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_shipping_method">deactivate_shipping_method api documentation</see>
        /// </summary>
        /// <param name="DeactivateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ShippingMethod DeactivateShippingMethod(string shippingMethodId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequest<ShippingMethod>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate a shipping method <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_shipping_method">deactivate_shipping_method api documentation</see>
        /// </summary>
        /// <param name="DeactivateShippingMethodParams">Optional Parameters for the request</param>
        /// <returns>
        /// A shipping method.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ShippingMethod> DeactivateShippingMethodAsync(string shippingMethodId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "shipping_method_id", shippingMethodId } };
            var url = this.InterpolatePath("/shipping_methods/{shipping_method_id}", urlParams);
            return MakeRequestAsync<ShippingMethod>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's subscriptions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_subscriptions">list_subscriptions api documentation</see>
        /// </summary>
        /// <param name="ListSubscriptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's subscriptions.
        /// </returns>
        public Pager<Subscription> ListSubscriptions(ListSubscriptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListSubscriptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return Pager<Subscription>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Create a new subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="CreateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription CreateSubscription(SubscriptionCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="CreateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> CreateSubscriptionAsync(SubscriptionCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/subscriptions", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription GetSubscription(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_subscription">update_subscription api documentation</see>
        /// </summary>
        /// <param name="UpdateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription UpdateSubscription(string subscriptionId, SubscriptionUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_subscription">update_subscription api documentation</see>
        /// </summary>
        /// <param name="UpdateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> UpdateSubscriptionAsync(string subscriptionId, SubscriptionUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Terminate a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="TerminateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription TerminateSubscription(string subscriptionId, TerminateSubscriptionParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = (optionalParams ?? new TerminateSubscriptionParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Delete, url, null, queryParams, options);
        }



        /// <summary>
        /// Terminate a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="TerminateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> TerminateSubscriptionAsync(string subscriptionId, TerminateSubscriptionParams optionalParams = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = (optionalParams ?? new TerminateSubscriptionParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Delete, url, null, queryParams, options, cancellationToken);
        }



        /// <summary>
        /// Cancel a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="CancelSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription CancelSubscription(string subscriptionId, SubscriptionCancel body = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/cancel", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Cancel a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="CancelSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> CancelSubscriptionAsync(string subscriptionId, SubscriptionCancel body = null, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/cancel", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Reactivate a canceled subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="ReactivateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ReactivateSubscription(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/reactivate", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Reactivate a canceled subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="ReactivateSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ReactivateSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/reactivate", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Pause subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="PauseSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription PauseSubscription(string subscriptionId, SubscriptionPause body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/pause", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Pause subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="PauseSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> PauseSubscriptionAsync(string subscriptionId, SubscriptionPause body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/pause", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Resume subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="ResumeSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ResumeSubscription(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/resume", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Resume subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="ResumeSubscriptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ResumeSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/resume", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Convert trial subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/convert_trial">convert_trial api documentation</see>
        /// </summary>
        /// <param name="ConvertTrialParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Subscription ConvertTrial(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/convert_trial", urlParams);
            return MakeRequest<Subscription>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Convert trial subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/convert_trial">convert_trial api documentation</see>
        /// </summary>
        /// <param name="ConvertTrialParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Subscription> ConvertTrialAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/convert_trial", urlParams);
            return MakeRequestAsync<Subscription>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a preview of a subscription's renewal invoice(s) <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_preview_renewal">get_preview_renewal api documentation</see>
        /// </summary>
        /// <param name="GetPreviewRenewalParams">Optional Parameters for the request</param>
        /// <returns>
        /// A preview of the subscription's renewal invoice(s).
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection GetPreviewRenewal(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/preview_renewal", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a preview of a subscription's renewal invoice(s) <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_preview_renewal">get_preview_renewal api documentation</see>
        /// </summary>
        /// <param name="GetPreviewRenewalParams">Optional Parameters for the request</param>
        /// <returns>
        /// A preview of the subscription's renewal invoice(s).
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> GetPreviewRenewalAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/preview_renewal", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a subscription's pending change <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public SubscriptionChange GetSubscriptionChange(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequest<SubscriptionChange>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a subscription's pending change <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<SubscriptionChange> GetSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<SubscriptionChange>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Create a new subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="CreateSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public SubscriptionChange CreateSubscriptionChange(string subscriptionId, SubscriptionChangeCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequest<SubscriptionChange>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="CreateSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<SubscriptionChange> CreateSubscriptionChangeAsync(string subscriptionId, SubscriptionChangeCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<SubscriptionChange>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete the pending subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="RemoveSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveSubscriptionChange(string subscriptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete the pending subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="RemoveSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Preview a new subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_subscription_change">preview_subscription_change api documentation</see>
        /// </summary>
        /// <param name="PreviewSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public SubscriptionChange PreviewSubscriptionChange(string subscriptionId, SubscriptionChangeCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change/preview", urlParams);
            return MakeRequest<SubscriptionChange>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Preview a new subscription change <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_subscription_change">preview_subscription_change api documentation</see>
        /// </summary>
        /// <param name="PreviewSubscriptionChangeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<SubscriptionChange> PreviewSubscriptionChangeAsync(string subscriptionId, SubscriptionChangeCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/change/preview", urlParams);
            return MakeRequestAsync<SubscriptionChange>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List a subscription's invoices <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_subscription_invoices">list_subscription_invoices api documentation</see>
        /// </summary>
        /// <param name="ListSubscriptionInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the subscription's invoices.
        /// </returns>
        public Pager<Invoice> ListSubscriptionInvoices(string subscriptionId, ListSubscriptionInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = (optionalParams ?? new ListSubscriptionInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List a subscription's line items <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_subscription_line_items">list_subscription_line_items api documentation</see>
        /// </summary>
        /// <param name="ListSubscriptionLineItemsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the subscription's line items.
        /// </returns>
        public Pager<LineItem> ListSubscriptionLineItems(string subscriptionId, ListSubscriptionLineItemsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = (optionalParams ?? new ListSubscriptionLineItemsParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/line_items", urlParams);
            return Pager<LineItem>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List the coupon redemptions for a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_subscription_coupon_redemptions">list_subscription_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="ListSubscriptionCouponRedemptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the coupon redemptions on a subscription.
        /// </returns>
        public Pager<CouponRedemption> ListSubscriptionCouponRedemptions(string subscriptionId, ListSubscriptionCouponRedemptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId } };
            var queryParams = (optionalParams ?? new ListSubscriptionCouponRedemptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions", urlParams);
            return Pager<CouponRedemption>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Show the coupon redemption for a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription_coupon_redemption">get_subscription_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// The coupon redemption on a subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption GetSubscriptionCouponRedemption(string subscriptionId, string couponRedemptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Show the coupon redemption for a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_subscription_coupon_redemption">get_subscription_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="GetSubscriptionCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// The coupon redemption on a subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> GetSubscriptionCouponRedemptionAsync(string subscriptionId, string couponRedemptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete the coupon redemption from a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_subscription_coupon_redemption">remove_subscription_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="RemoveSubscriptionCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public CouponRedemption RemoveSubscriptionCouponRedemption(string subscriptionId, string couponRedemptionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequest<CouponRedemption>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete the coupon redemption from a subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_subscription_coupon_redemption">remove_subscription_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="RemoveSubscriptionCouponRedemptionParams">Optional Parameters for the request</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<CouponRedemption> RemoveSubscriptionCouponRedemptionAsync(string subscriptionId, string couponRedemptionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "coupon_redemption_id", couponRedemptionId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/coupon_redemptions/{coupon_redemption_id}", urlParams);
            return MakeRequestAsync<CouponRedemption>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a subscription add-on's usage records <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_usage">list_usage api documentation</see>
        /// </summary>
        /// <param name="ListUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the subscription add-on's usage records.
        /// </returns>
        public Pager<Usage> ListUsage(string subscriptionId, string addOnId, ListUsageParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "add_on_id", addOnId } };
            var queryParams = (optionalParams ?? new ListUsageParams()).ToDictionary();
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/add_ons/{add_on_id}/usage", urlParams);
            return Pager<Usage>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Log a usage record on this subscription add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_usage">create_usage api documentation</see>
        /// </summary>
        /// <param name="CreateUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The created usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Usage CreateUsage(string subscriptionId, string addOnId, UsageCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/add_ons/{add_on_id}/usage", urlParams);
            return MakeRequest<Usage>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Log a usage record on this subscription add-on <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_usage">create_usage api documentation</see>
        /// </summary>
        /// <param name="CreateUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The created usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Usage> CreateUsageAsync(string subscriptionId, string addOnId, UsageCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "subscription_id", subscriptionId }, { "add_on_id", addOnId } };
            var url = this.InterpolatePath("/subscriptions/{subscription_id}/add_ons/{add_on_id}/usage", urlParams);
            return MakeRequestAsync<Usage>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Get a usage record <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_usage">get_usage api documentation</see>
        /// </summary>
        /// <param name="GetUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Usage GetUsage(string usageId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequest<Usage>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Get a usage record <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_usage">get_usage api documentation</see>
        /// </summary>
        /// <param name="GetUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Usage> GetUsageAsync(string usageId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequestAsync<Usage>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Update a usage record <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_usage">update_usage api documentation</see>
        /// </summary>
        /// <param name="UpdateUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Usage UpdateUsage(string usageId, UsageCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequest<Usage>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Update a usage record <see href="https://developers.recurly.com/api/v2021-02-25#operation/update_usage">update_usage api documentation</see>
        /// </summary>
        /// <param name="UpdateUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// The updated usage record.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Usage> UpdateUsageAsync(string usageId, UsageCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequestAsync<Usage>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Delete a usage record. <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_usage">remove_usage api documentation</see>
        /// </summary>
        /// <param name="RemoveUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// Usage was successfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public EmptyResource RemoveUsage(string usageId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequest<EmptyResource>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Delete a usage record. <see href="https://developers.recurly.com/api/v2021-02-25#operation/remove_usage">remove_usage api documentation</see>
        /// </summary>
        /// <param name="RemoveUsageParams">Optional Parameters for the request</param>
        /// <returns>
        /// Usage was successfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<EmptyResource> RemoveUsageAsync(string usageId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "usage_id", usageId } };
            var url = this.InterpolatePath("/usage/{usage_id}", urlParams);
            return MakeRequestAsync<EmptyResource>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List a site's transactions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_transactions">list_transactions api documentation</see>
        /// </summary>
        /// <param name="ListTransactionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the site's transactions.
        /// </returns>
        public Pager<Transaction> ListTransactions(ListTransactionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListTransactionsParams()).ToDictionary();
            var url = this.InterpolatePath("/transactions", urlParams);
            return Pager<Transaction>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a transaction <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="GetTransactionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Transaction GetTransaction(string transactionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/transactions/{transaction_id}", urlParams);
            return MakeRequest<Transaction>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a transaction <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="GetTransactionParams">Optional Parameters for the request</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<Transaction> GetTransactionAsync(string transactionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/transactions/{transaction_id}", urlParams);
            return MakeRequestAsync<Transaction>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="GetUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode GetUniqueCouponCode(string uniqueCouponCodeId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequest<UniqueCouponCode>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="GetUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> GetUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Deactivate a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="DeactivateUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode DeactivateUniqueCouponCode(string uniqueCouponCodeId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequest<UniqueCouponCode>(HttpMethod.Delete, url, null, null, options);
        }



        /// <summary>
        /// Deactivate a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="DeactivateUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> DeactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(HttpMethod.Delete, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Restore a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="ReactivateUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public UniqueCouponCode ReactivateUniqueCouponCode(string uniqueCouponCodeId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}/restore", urlParams);
            return MakeRequest<UniqueCouponCode>(HttpMethod.Put, url, null, null, options);
        }



        /// <summary>
        /// Restore a unique coupon code <see href="https://developers.recurly.com/api/v2021-02-25#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="ReactivateUniqueCouponCodeParams">Optional Parameters for the request</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<UniqueCouponCode> ReactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "unique_coupon_code_id", uniqueCouponCodeId } };
            var url = this.InterpolatePath("/unique_coupon_codes/{unique_coupon_code_id}/restore", urlParams);
            return MakeRequestAsync<UniqueCouponCode>(HttpMethod.Put, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Create a new purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_purchase">create_purchase api documentation</see>
        /// </summary>
        /// <param name="CreatePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreatePurchase(PurchaseCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a new purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_purchase">create_purchase api documentation</see>
        /// </summary>
        /// <param name="CreatePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreatePurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Preview a new purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_purchase">preview_purchase api documentation</see>
        /// </summary>
        /// <param name="PreviewPurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns preview of the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection PreviewPurchase(PurchaseCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/preview", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Preview a new purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_purchase">preview_purchase api documentation</see>
        /// </summary>
        /// <param name="PreviewPurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns preview of the new invoices
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> PreviewPurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/preview", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Create a pending purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_pending_purchase">create_pending_purchase api documentation</see>
        /// </summary>
        /// <param name="CreatePendingPurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the pending invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreatePendingPurchase(PurchaseCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/pending", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create a pending purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_pending_purchase">create_pending_purchase api documentation</see>
        /// </summary>
        /// <param name="CreatePendingPurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the pending invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreatePendingPurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/pending", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Authorize a purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_authorize_purchase">create_authorize_purchase api documentation</see>
        /// </summary>
        /// <param name="CreateAuthorizePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the authorize invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreateAuthorizePurchase(PurchaseCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/authorize", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Authorize a purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_authorize_purchase">create_authorize_purchase api documentation</see>
        /// </summary>
        /// <param name="CreateAuthorizePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the authorize invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreateAuthorizePurchaseAsync(PurchaseCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/purchases/authorize", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Capture a purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_capture_purchase">create_capture_purchase api documentation</see>
        /// </summary>
        /// <param name="CreateCapturePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the captured invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection CreateCapturePurchase(string transactionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/purchases/{transaction_id}/capture", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, null, null, options);
        }



        /// <summary>
        /// Capture a purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_capture_purchase">create_capture_purchase api documentation</see>
        /// </summary>
        /// <param name="CreateCapturePurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the captured invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CreateCapturePurchaseAsync(string transactionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/purchases/{transaction_id}/capture", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Cancel Purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/cancelPurchase">cancelPurchase api documentation</see>
        /// </summary>
        /// <param name="CancelpurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the cancelled invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceCollection Cancelpurchase(string transactionId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/purchases/{transaction_id}/cancel/", urlParams);
            return MakeRequest<InvoiceCollection>(HttpMethod.Post, url, null, null, options);
        }



        /// <summary>
        /// Cancel Purchase <see href="https://developers.recurly.com/api/v2021-02-25#operation/cancelPurchase">cancelPurchase api documentation</see>
        /// </summary>
        /// <param name="CancelpurchaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the cancelled invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceCollection> CancelpurchaseAsync(string transactionId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "transaction_id", transactionId } };
            var url = this.InterpolatePath("/purchases/{transaction_id}/cancel/", urlParams);
            return MakeRequestAsync<InvoiceCollection>(HttpMethod.Post, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the dates that have an available export to download. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_export_dates">get_export_dates api documentation</see>
        /// </summary>
        /// <param name="GetExportDatesParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns a list of dates.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExportDates GetExportDates(RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/export_dates", urlParams);
            return MakeRequest<ExportDates>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// List the dates that have an available export to download. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_export_dates">get_export_dates api documentation</see>
        /// </summary>
        /// <param name="GetExportDatesParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns a list of dates.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExportDates> GetExportDatesAsync(CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/export_dates", urlParams);
            return MakeRequestAsync<ExportDates>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List of the export files that are available to download. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_export_files">get_export_files api documentation</see>
        /// </summary>
        /// <param name="GetExportFilesParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns a list of export files to download.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExportFiles GetExportFiles(string exportDate, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "export_date", exportDate } };
            var url = this.InterpolatePath("/export_dates/{export_date}/export_files", urlParams);
            return MakeRequest<ExportFiles>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// List of the export files that are available to download. <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_export_files">get_export_files api documentation</see>
        /// </summary>
        /// <param name="GetExportFilesParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns a list of export files to download.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExportFiles> GetExportFilesAsync(string exportDate, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "export_date", exportDate } };
            var url = this.InterpolatePath("/export_dates/{export_date}/export_files", urlParams);
            return MakeRequestAsync<ExportFiles>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the dunning campaigns for a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_dunning_campaigns">list_dunning_campaigns api documentation</see>
        /// </summary>
        /// <param name="ListDunningCampaignsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the dunning_campaigns on an account.
        /// </returns>
        public Pager<DunningCampaign> ListDunningCampaigns(ListDunningCampaignsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListDunningCampaignsParams()).ToDictionary();
            var url = this.InterpolatePath("/dunning_campaigns", urlParams);
            return Pager<DunningCampaign>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a dunning campaign <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_dunning_campaign">get_dunning_campaign api documentation</see>
        /// </summary>
        /// <param name="GetDunningCampaignParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for a dunning campaign.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public DunningCampaign GetDunningCampaign(string dunningCampaignId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "dunning_campaign_id", dunningCampaignId } };
            var url = this.InterpolatePath("/dunning_campaigns/{dunning_campaign_id}", urlParams);
            return MakeRequest<DunningCampaign>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a dunning campaign <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_dunning_campaign">get_dunning_campaign api documentation</see>
        /// </summary>
        /// <param name="GetDunningCampaignParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for a dunning campaign.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<DunningCampaign> GetDunningCampaignAsync(string dunningCampaignId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "dunning_campaign_id", dunningCampaignId } };
            var url = this.InterpolatePath("/dunning_campaigns/{dunning_campaign_id}", urlParams);
            return MakeRequestAsync<DunningCampaign>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Assign a dunning campaign to multiple plans <see href="https://developers.recurly.com/api/v2021-02-25#operation/put_dunning_campaign_bulk_update">put_dunning_campaign_bulk_update api documentation</see>
        /// </summary>
        /// <param name="PutDunningCampaignBulkUpdateParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of updated plans.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public DunningCampaignsBulkUpdateResponse PutDunningCampaignBulkUpdate(string dunningCampaignId, DunningCampaignsBulkUpdate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "dunning_campaign_id", dunningCampaignId } };
            var url = this.InterpolatePath("/dunning_campaigns/{dunning_campaign_id}/bulk_update", urlParams);
            return MakeRequest<DunningCampaignsBulkUpdateResponse>(HttpMethod.Put, url, body, null, options);
        }



        /// <summary>
        /// Assign a dunning campaign to multiple plans <see href="https://developers.recurly.com/api/v2021-02-25#operation/put_dunning_campaign_bulk_update">put_dunning_campaign_bulk_update api documentation</see>
        /// </summary>
        /// <param name="PutDunningCampaignBulkUpdateParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of updated plans.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<DunningCampaignsBulkUpdateResponse> PutDunningCampaignBulkUpdateAsync(string dunningCampaignId, DunningCampaignsBulkUpdate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "dunning_campaign_id", dunningCampaignId } };
            var url = this.InterpolatePath("/dunning_campaigns/{dunning_campaign_id}/bulk_update", urlParams);
            return MakeRequestAsync<DunningCampaignsBulkUpdateResponse>(HttpMethod.Put, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Show the invoice templates for a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_invoice_templates">list_invoice_templates api documentation</see>
        /// </summary>
        /// <param name="ListInvoiceTemplatesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the invoice templates on a site.
        /// </returns>
        public Pager<InvoiceTemplate> ListInvoiceTemplates(ListInvoiceTemplatesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListInvoiceTemplatesParams()).ToDictionary();
            var url = this.InterpolatePath("/invoice_templates", urlParams);
            return Pager<InvoiceTemplate>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an invoice template <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice_template">get_invoice_template api documentation</see>
        /// </summary>
        /// <param name="GetInvoiceTemplateParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an invoice template.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public InvoiceTemplate GetInvoiceTemplate(string invoiceTemplateId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_template_id", invoiceTemplateId } };
            var url = this.InterpolatePath("/invoice_templates/{invoice_template_id}", urlParams);
            return MakeRequest<InvoiceTemplate>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an invoice template <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_invoice_template">get_invoice_template api documentation</see>
        /// </summary>
        /// <param name="GetInvoiceTemplateParams">Optional Parameters for the request</param>
        /// <returns>
        /// Settings for an invoice template.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<InvoiceTemplate> GetInvoiceTemplateAsync(string invoiceTemplateId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "invoice_template_id", invoiceTemplateId } };
            var url = this.InterpolatePath("/invoice_templates/{invoice_template_id}", urlParams);
            return MakeRequestAsync<InvoiceTemplate>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external invoices on a site <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_invoices">list_external_invoices api documentation</see>
        /// </summary>
        /// <param name="ListExternalInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_invoices on a site.
        /// </returns>
        public Pager<ExternalInvoice> ListExternalInvoices(ListExternalInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var queryParams = (optionalParams ?? new ListExternalInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/external_invoices", urlParams);
            return Pager<ExternalInvoice>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an external invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/show_external_invoice">show_external_invoice api documentation</see>
        /// </summary>
        /// <param name="ShowExternalInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalInvoice ShowExternalInvoice(string externalInvoiceId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_invoice_id", externalInvoiceId } };
            var url = this.InterpolatePath("/external_invoices/{external_invoice_id}", urlParams);
            return MakeRequest<ExternalInvoice>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an external invoice <see href="https://developers.recurly.com/api/v2021-02-25#operation/show_external_invoice">show_external_invoice api documentation</see>
        /// </summary>
        /// <param name="ShowExternalInvoiceParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the external invoice
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalInvoice> ShowExternalInvoiceAsync(string externalInvoiceId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_invoice_id", externalInvoiceId } };
            var url = this.InterpolatePath("/external_invoices/{external_invoice_id}", urlParams);
            return MakeRequestAsync<ExternalInvoice>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List the external payment phases on an external subscription <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_external_subscription_external_payment_phases">list_external_subscription_external_payment_phases api documentation</see>
        /// </summary>
        /// <param name="ListExternalSubscriptionExternalPaymentPhasesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_payment_phases on a site.
        /// </returns>
        public Pager<ExternalPaymentPhase> ListExternalSubscriptionExternalPaymentPhases(string externalSubscriptionId, ListExternalSubscriptionExternalPaymentPhasesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId } };
            var queryParams = (optionalParams ?? new ListExternalSubscriptionExternalPaymentPhasesParams()).ToDictionary();
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_payment_phases", urlParams);
            return Pager<ExternalPaymentPhase>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch an external payment phase <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_subscription_external_payment_phase">get_external_subscription_external_payment_phase api documentation</see>
        /// </summary>
        /// <param name="GetExternalSubscriptionExternalPaymentPhaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external payment phase.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public ExternalPaymentPhase GetExternalSubscriptionExternalPaymentPhase(string externalSubscriptionId, string externalPaymentPhaseId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId }, { "external_payment_phase_id", externalPaymentPhaseId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_payment_phases/{external_payment_phase_id}", urlParams);
            return MakeRequest<ExternalPaymentPhase>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch an external payment phase <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_external_subscription_external_payment_phase">get_external_subscription_external_payment_phase api documentation</see>
        /// </summary>
        /// <param name="GetExternalSubscriptionExternalPaymentPhaseParams">Optional Parameters for the request</param>
        /// <returns>
        /// Details for an external payment phase.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<ExternalPaymentPhase> GetExternalSubscriptionExternalPaymentPhaseAsync(string externalSubscriptionId, string externalPaymentPhaseId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "external_subscription_id", externalSubscriptionId }, { "external_payment_phase_id", externalPaymentPhaseId } };
            var url = this.InterpolatePath("/external_subscriptions/{external_subscription_id}/external_payment_phases/{external_payment_phase_id}", urlParams);
            return MakeRequestAsync<ExternalPaymentPhase>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List entitlements granted to an account <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_entitlements">list_entitlements api documentation</see>
        /// </summary>
        /// <param name="ListEntitlementsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the entitlements granted to an account.
        /// </returns>
        public Pager<Entitlements> ListEntitlements(string accountId, ListEntitlementsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListEntitlementsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/entitlements", urlParams);
            return Pager<Entitlements>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// List an account's external subscriptions <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_account_external_subscriptions">list_account_external_subscriptions api documentation</see>
        /// </summary>
        /// <param name="ListAccountExternalSubscriptionsParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the the external_subscriptions on an account.
        /// </returns>
        public Pager<ExternalSubscription> ListAccountExternalSubscriptions(string accountId, ListAccountExternalSubscriptionsParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "account_id", accountId } };
            var queryParams = (optionalParams ?? new ListAccountExternalSubscriptionsParams()).ToDictionary();
            var url = this.InterpolatePath("/accounts/{account_id}/external_subscriptions", urlParams);
            return Pager<ExternalSubscription>.Build(url, queryParams, options, this);
        }





        /// <summary>
        /// Fetch a business entity <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_business_entity">get_business_entity api documentation</see>
        /// </summary>
        /// <param name="GetBusinessEntityParams">Optional Parameters for the request</param>
        /// <returns>
        /// Business entity details
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public BusinessEntity GetBusinessEntity(string businessEntityId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "business_entity_id", businessEntityId } };
            var url = this.InterpolatePath("/business_entities/{business_entity_id}", urlParams);
            return MakeRequest<BusinessEntity>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a business entity <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_business_entity">get_business_entity api documentation</see>
        /// </summary>
        /// <param name="GetBusinessEntityParams">Optional Parameters for the request</param>
        /// <returns>
        /// Business entity details
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<BusinessEntity> GetBusinessEntityAsync(string businessEntityId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "business_entity_id", businessEntityId } };
            var url = this.InterpolatePath("/business_entities/{business_entity_id}", urlParams);
            return MakeRequestAsync<BusinessEntity>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// List business entities <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_business_entities">list_business_entities api documentation</see>
        /// </summary>
        /// <param name="ListBusinessEntitiesParams">Optional Parameters for the request</param>
        /// <returns>
        /// List of all business entities on your site.
        /// </returns>
        public Pager<BusinessEntity> ListBusinessEntities(RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/business_entities", urlParams);
            return Pager<BusinessEntity>.Build(url, null, options, this);
        }





        /// <summary>
        /// List gift cards <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_gift_cards">list_gift_cards api documentation</see>
        /// </summary>
        /// <param name="ListGiftCardsParams">Optional Parameters for the request</param>
        /// <returns>
        /// List of all created gift cards on your site.
        /// </returns>
        public Pager<GiftCard> ListGiftCards(RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/gift_cards", urlParams);
            return Pager<GiftCard>.Build(url, null, options, this);
        }





        /// <summary>
        /// Create gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_gift_card">create_gift_card api documentation</see>
        /// </summary>
        /// <param name="CreateGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GiftCard CreateGiftCard(GiftCardCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/gift_cards", urlParams);
            return MakeRequest<GiftCard>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Create gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/create_gift_card">create_gift_card api documentation</see>
        /// </summary>
        /// <param name="CreateGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GiftCard> CreateGiftCardAsync(GiftCardCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/gift_cards", urlParams);
            return MakeRequestAsync<GiftCard>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Fetch a gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_gift_card">get_gift_card api documentation</see>
        /// </summary>
        /// <param name="GetGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Gift card details
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GiftCard GetGiftCard(string giftCardId, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "gift_card_id", giftCardId } };
            var url = this.InterpolatePath("/gift_cards/{gift_card_id}", urlParams);
            return MakeRequest<GiftCard>(HttpMethod.Get, url, null, null, options);
        }



        /// <summary>
        /// Fetch a gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/get_gift_card">get_gift_card api documentation</see>
        /// </summary>
        /// <param name="GetGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Gift card details
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GiftCard> GetGiftCardAsync(string giftCardId, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "gift_card_id", giftCardId } };
            var url = this.InterpolatePath("/gift_cards/{gift_card_id}", urlParams);
            return MakeRequestAsync<GiftCard>(HttpMethod.Get, url, null, null, options, cancellationToken);
        }



        /// <summary>
        /// Preview gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_gift_card">preview_gift_card api documentation</see>
        /// </summary>
        /// <param name="PreviewGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GiftCard PreviewGiftCard(GiftCardCreate body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/gift_cards/preview", urlParams);
            return MakeRequest<GiftCard>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Preview gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/preview_gift_card">preview_gift_card api documentation</see>
        /// </summary>
        /// <param name="PreviewGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GiftCard> PreviewGiftCardAsync(GiftCardCreate body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { };
            var url = this.InterpolatePath("/gift_cards/preview", urlParams);
            return MakeRequestAsync<GiftCard>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// Redeem gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/redeem_gift_card">redeem_gift_card api documentation</see>
        /// </summary>
        /// <param name="RedeemGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Redeems and returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public GiftCard RedeemGiftCard(string redemptionCode, GiftCardRedeem body, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "redemption_code", redemptionCode } };
            var url = this.InterpolatePath("/gift_cards/{redemption_code}/redeem", urlParams);
            return MakeRequest<GiftCard>(HttpMethod.Post, url, body, null, options);
        }



        /// <summary>
        /// Redeem gift card <see href="https://developers.recurly.com/api/v2021-02-25#operation/redeem_gift_card">redeem_gift_card api documentation</see>
        /// </summary>
        /// <param name="RedeemGiftCardParams">Optional Parameters for the request</param>
        /// <returns>
        /// Redeems and returns the gift card
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        public Task<GiftCard> RedeemGiftCardAsync(string redemptionCode, GiftCardRedeem body, CancellationToken cancellationToken = default(CancellationToken), RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "redemption_code", redemptionCode } };
            var url = this.InterpolatePath("/gift_cards/{redemption_code}/redeem", urlParams);
            return MakeRequestAsync<GiftCard>(HttpMethod.Post, url, body, null, options, cancellationToken);
        }



        /// <summary>
        /// List a business entity's invoices <see href="https://developers.recurly.com/api/v2021-02-25#operation/list_business_entity_invoices">list_business_entity_invoices api documentation</see>
        /// </summary>
        /// <param name="ListBusinessEntityInvoicesParams">Optional Parameters for the request</param>
        /// <returns>
        /// A list of the business entity's invoices.
        /// </returns>
        public Pager<Invoice> ListBusinessEntityInvoices(string businessEntityId, ListBusinessEntityInvoicesParams optionalParams = null, RequestOptions options = null)
        {
            var urlParams = new Dictionary<string, object> { { "business_entity_id", businessEntityId } };
            var queryParams = (optionalParams ?? new ListBusinessEntityInvoicesParams()).ToDictionary();
            var url = this.InterpolatePath("/business_entities/{business_entity_id}/invoices", urlParams);
            return Pager<Invoice>.Build(url, queryParams, options, this);
        }




    }
}
