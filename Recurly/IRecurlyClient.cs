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
    public interface IRecurlyClient
    {

        string ApiVersion { get; }
        string SiteId { get; }
        void _SetApiUrl(string url);


        /// <summary>
        /// List sites <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_sites">list_sites api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <returns>
        /// A list of sites.
        /// </returns>
        Pager<Site> ListSites(string ids = null, int? limit = null, string order = null, string sort = null);


        /// <summary>
        /// Fetch a site <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Site GetSite();

        /// <summary>
        /// Fetch a site <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_site">get_site api documentation</see>
        /// </summary>
        /// <returns>
        /// A site.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Site> GetSiteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's accounts <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_accounts">list_accounts api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="subscriber">Filter accounts accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
        /// <param name="pastDue">Filter for accounts with an invoice in the `past_due` state.</param>
        /// <returns>
        /// A list of the site's accounts.
        /// </returns>
        Pager<Account> ListAccounts(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string subscriber = null, string pastDue = null);


        /// <summary>
        /// Create an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Account CreateAccount(AccountCreate body);

        /// <summary>
        /// Create an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_account">create_account api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Account> CreateAccountAsync(AccountCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Account GetAccount(string accountId);

        /// <summary>
        /// Fetch an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account">get_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Account> GetAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Modify an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Account UpdateAccount(string accountId, AccountUpdate body);

        /// <summary>
        /// Modify an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_account">update_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Account> UpdateAccountAsync(string accountId, AccountUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivate an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Account DeactivateAccount(string accountId);

        /// <summary>
        /// Deactivate an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/deactivate_account">deactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Account> DeactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AccountAcquisition GetAccountAcquisition(string accountId);

        /// <summary>
        /// Fetch an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_acquisition">get_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AccountAcquisition> GetAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AccountAcquisition UpdateAccountAcquisition(string accountId, AccountAcquisitionUpdatable body);

        /// <summary>
        /// Update an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_account_acquisition">update_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An account's updated acquisition data.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AccountAcquisition> UpdateAccountAcquisitionAsync(string accountId, AccountAcquisitionUpdatable body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        void RemoveAccountAcquisition(string accountId);

        /// <summary>
        /// Remove an account's acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_account_acquisition">remove_account_acquisition api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Acquisition data was succesfully deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<object> RemoveAccountAcquisitionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reactivate an inactive account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Account ReactivateAccount(string accountId);

        /// <summary>
        /// Reactivate an inactive account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_account">reactivate_account api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Account> ReactivateAccountAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AccountBalance GetAccountBalance(string accountId);

        /// <summary>
        /// Fetch an account's balance and past due status <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_balance">get_account_balance api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's balance.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AccountBalance> GetAccountBalanceAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        BillingInfo GetBillingInfo(string accountId);

        /// <summary>
        /// Fetch an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_billing_info">get_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An account's billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<BillingInfo> GetBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Set an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        BillingInfo UpdateBillingInfo(string accountId, BillingInfoCreate body);

        /// <summary>
        /// Set an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_billing_info">update_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Updated billing information.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<BillingInfo> UpdateBillingInfoAsync(string accountId, BillingInfoCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        void RemoveBillingInfo(string accountId);

        /// <summary>
        /// Remove an account's billing information <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_billing_info">remove_billing_info api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Billing information deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<object> RemoveBillingInfoAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Show the coupon redemptions for an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_coupon_redemptions">list_account_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions on an account.
        /// </returns>
        Pager<CouponRedemption> ListAccountCouponRedemptions(string accountId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// Show the coupon redemption that is active on an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_active_coupon_redemption">get_active_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An active coupon redemption on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        CouponRedemption GetActiveCouponRedemption(string accountId);

        /// <summary>
        /// Show the coupon redemption that is active on an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_active_coupon_redemption">get_active_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// An active coupon redemption on an account.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<CouponRedemption> GetActiveCouponRedemptionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Generate an active coupon redemption on an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        CouponRedemption CreateCouponRedemption(string accountId, CouponRedemptionCreate body);

        /// <summary>
        /// Generate an active coupon redemption on an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_coupon_redemption">create_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new coupon redemption.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<CouponRedemption> CreateCouponRedemptionAsync(string accountId, CouponRedemptionCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        CouponRedemption RemoveCouponRedemption(string accountId);

        /// <summary>
        /// Delete the active coupon redemption from an account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_coupon_redemption">remove_coupon_redemption api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <returns>
        /// Coupon redemption deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<CouponRedemption> RemoveCouponRedemptionAsync(string accountId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List an account's credit payments <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_credit_payments">list_account_credit_payments api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the account's credit payments.
        /// </returns>
        Pager<CreditPayment> ListAccountCreditPayments(string accountId, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// List an account's invoices <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_invoices">list_account_invoices api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
        Pager<Invoice> ListAccountInvoices(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null);


        /// <summary>
        /// Create an invoice for pending line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        InvoiceCollection CreateInvoice(string accountId, InvoiceCreate body);

        /// <summary>
        /// Create an invoice for pending line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_invoice">create_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new invoices.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<InvoiceCollection> CreateInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Preview new invoice for pending line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        InvoiceCollection PreviewInvoice(string accountId, InvoiceCreate body);

        /// <summary>
        /// Preview new invoice for pending line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/preview_invoice">preview_invoice api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the invoice previews.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<InvoiceCollection> PreviewInvoiceAsync(string accountId, InvoiceCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List an account's line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_line_items">list_account_line_items api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
        Pager<LineItem> ListAccountLineItems(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null);


        /// <summary>
        /// Create a new line item for the account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        LineItem CreateLineItem(string accountId, LineItemCreate body);

        /// <summary>
        /// Create a new line item for the account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_line_item">create_line_item api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<LineItem> CreateLineItemAsync(string accountId, LineItemCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a list of an account's notes <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_notes">list_account_notes api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <returns>
        /// A list of an account's notes.
        /// </returns>
        Pager<AccountNote> ListAccountNotes(string accountId, string ids = null);


        /// <summary>
        /// Fetch an account note <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="accountNoteId">Account Note ID.</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AccountNote GetAccountNote(string accountId, string accountNoteId);

        /// <summary>
        /// Fetch an account note <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_account_note">get_account_note api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="accountNoteId">Account Note ID.</param>
        /// <returns>
        /// An account note.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AccountNote> GetAccountNoteAsync(string accountId, string accountNoteId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a list of an account's shipping addresses <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_shipping_addresses">list_shipping_addresses api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of an account's shipping addresses.
        /// </returns>
        Pager<ShippingAddress> ListShippingAddresses(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// Create a new shipping address for the account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        ShippingAddress CreateShippingAddress(string accountId, ShippingAddressCreate body);

        /// <summary>
        /// Create a new shipping address for the account <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_shipping_address">create_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<ShippingAddress> CreateShippingAddressAsync(string accountId, ShippingAddressCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        ShippingAddress GetShippingAddress(string accountId, string shippingAddressId);

        /// <summary>
        /// Fetch an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_shipping_address">get_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// A shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<ShippingAddress> GetShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        ShippingAddress UpdateShippingAddress(string accountId, string shippingAddressId, ShippingAddressUpdate body);

        /// <summary>
        /// Update an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_shipping_address">update_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated shipping address.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<ShippingAddress> UpdateShippingAddressAsync(string accountId, string shippingAddressId, ShippingAddressUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        void RemoveShippingAddress(string accountId, string shippingAddressId);

        /// <summary>
        /// Remove an account's shipping address <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_shipping_address">remove_shipping_address api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="shippingAddressId">Shipping Address ID.</param>
        /// <returns>
        /// Shipping address deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<object> RemoveShippingAddressAsync(string accountId, string shippingAddressId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List an account's subscriptions <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_subscriptions">list_account_subscriptions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
        Pager<Subscription> ListAccountSubscriptions(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null);


        /// <summary>
        /// List an account's transactions <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_transactions">list_account_transactions api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
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
        Pager<Transaction> ListAccountTransactions(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null, string success = null);


        /// <summary>
        /// List an account's child accounts <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_child_accounts">list_child_accounts api documentation</see>
        /// </summary>
        /// <param name="accountId">Account ID or code (use prefix: `code-`, e.g. `code-bob`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="subscriber">Filter accounts accounts with or without a subscription in the `active`,  `canceled`, or `future` state.  </param>
        /// <param name="pastDue">Filter for accounts with an invoice in the `past_due` state.</param>
        /// <returns>
        /// A list of an account's child accounts.
        /// </returns>
        Pager<Account> ListChildAccounts(string accountId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string subscriber = null, string pastDue = null);


        /// <summary>
        /// List a site's account acquisition data <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_account_acquisition">list_account_acquisition api documentation</see>
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
        Pager<AccountAcquisition> ListAccountAcquisition(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// List a site's coupons <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_coupons">list_coupons api documentation</see>
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
        Pager<Coupon> ListCoupons(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// Create a new coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Coupon CreateCoupon(CouponCreate body);

        /// <summary>
        /// Create a new coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_coupon">create_coupon api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A new coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Coupon> CreateCouponAsync(CouponCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Coupon GetCoupon(string couponId);

        /// <summary>
        /// Fetch a coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_coupon">get_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
        /// <returns>
        /// A coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Coupon> GetCouponAsync(string couponId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an active coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Coupon UpdateCoupon(string couponId, CouponUpdate body);

        /// <summary>
        /// Update an active coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_coupon">update_coupon api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// The updated coupon.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Coupon> UpdateCouponAsync(string couponId, CouponUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List unique coupon codes associated with a bulk coupon <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_unique_coupon_codes">list_unique_coupon_codes api documentation</see>
        /// </summary>
        /// <param name="couponId">Coupon ID or code (use prefix: `code-`, e.g. `code-10off`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of unique coupon codes that were generated
        /// </returns>
        Pager<UniqueCouponCode> ListUniqueCouponCodes(string couponId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// List a site's credit payments <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_credit_payments">list_credit_payments api documentation</see>
        /// </summary>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's credit payments.
        /// </returns>
        Pager<CreditPayment> ListCreditPayments(int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// Fetch a credit payment <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="creditPaymentId">Credit Payment ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        CreditPayment GetCreditPayment(string creditPaymentId);

        /// <summary>
        /// Fetch a credit payment <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_credit_payment">get_credit_payment api documentation</see>
        /// </summary>
        /// <param name="creditPaymentId">Credit Payment ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A credit payment.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<CreditPayment> GetCreditPaymentAsync(string creditPaymentId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's custom field definitions <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_custom_field_definitions">list_custom_field_definitions api documentation</see>
        /// </summary>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="limit">Limit number of records 1-200.</param>
        /// <param name="order">Sort order.</param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the site's custom field definitions.
        /// </returns>
        Pager<CustomFieldDefinition> ListCustomFieldDefinitions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// Fetch an custom field definition <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="customFieldDefinitionId">Custom Field Definition ID</param>
        /// <returns>
        /// An custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        CustomFieldDefinition GetCustomFieldDefinition(string customFieldDefinitionId);

        /// <summary>
        /// Fetch an custom field definition <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_custom_field_definition">get_custom_field_definition api documentation</see>
        /// </summary>
        /// <param name="customFieldDefinitionId">Custom Field Definition ID</param>
        /// <returns>
        /// An custom field definition.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<CustomFieldDefinition> GetCustomFieldDefinitionAsync(string customFieldDefinitionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's invoices <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_invoices">list_invoices api documentation</see>
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
        Pager<Invoice> ListInvoices(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null);


        /// <summary>
        /// Fetch an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice GetInvoice(string invoiceId);

        /// <summary>
        /// Fetch an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_invoice">get_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> GetInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/put_invoice">put_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice PutInvoice(string invoiceId, InvoiceUpdatable body);

        /// <summary>
        /// Update an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/put_invoice">put_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> PutInvoiceAsync(string invoiceId, InvoiceUpdatable body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice CollectInvoice(string invoiceId);

        /// <summary>
        /// Collect a pending or past due, automatic invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/collect_invoice">collect_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> CollectInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Mark an open invoice as failed <see href="https://partner-docs.recurly.com/v2018-08-09#operation/fail_invoice">fail_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice FailInvoice(string invoiceId);

        /// <summary>
        /// Mark an open invoice as failed <see href="https://partner-docs.recurly.com/v2018-08-09#operation/fail_invoice">fail_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> FailInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Mark an open invoice as successful <see href="https://partner-docs.recurly.com/v2018-08-09#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice MarkInvoiceSuccessful(string invoiceId);

        /// <summary>
        /// Mark an open invoice as successful <see href="https://partner-docs.recurly.com/v2018-08-09#operation/mark_invoice_successful">mark_invoice_successful api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> MarkInvoiceSuccessfulAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice ReopenInvoice(string invoiceId);

        /// <summary>
        /// Reopen a closed, manual invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reopen_invoice">reopen_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// The updated invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> ReopenInvoiceAsync(string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a invoice's line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_invoice_line_items">list_invoice_line_items api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
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
        Pager<LineItem> ListInvoiceLineItems(string invoiceId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null);


        /// <summary>
        /// Show the coupon redemptions applied to an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_invoice_coupon_redemptions">list_invoice_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions associated with the invoice.
        /// </returns>
        Pager<CouponRedemption> ListInvoiceCouponRedemptions(string invoiceId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// List an invoice's related credit or charge invoices <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_related_invoices">list_related_invoices api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <returns>
        /// A list of the credit or charge invoices associated with the invoice.
        /// </returns>
        Pager<Invoice> ListRelatedInvoices(string invoiceId);


        /// <summary>
        /// Refund an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Invoice RefundInvoice(string invoiceId, InvoiceRefund body);

        /// <summary>
        /// Refund an invoice <see href="https://partner-docs.recurly.com/v2018-08-09#operation/refund_invoice">refund_invoice api documentation</see>
        /// </summary>
        /// <param name="invoiceId">Invoice ID or number (use prefix: `number-`, e.g. `number-1000`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// Returns the new credit invoice.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Invoice> RefundInvoiceAsync(string invoiceId, InvoiceRefund body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_line_items">list_line_items api documentation</see>
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
        Pager<LineItem> ListLineItems(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null);


        /// <summary>
        /// Fetch a line item <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        LineItem GetLineItem(string lineItemId);

        /// <summary>
        /// Fetch a line item <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_line_item">get_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// A line item.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<LineItem> GetLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete an uninvoiced line item <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        void RemoveLineItem(string lineItemId);

        /// <summary>
        /// Delete an uninvoiced line item <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_line_item">remove_line_item api documentation</see>
        /// </summary>
        /// <param name="lineItemId">Line Item ID.</param>
        /// <returns>
        /// Line item deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<object> RemoveLineItemAsync(string lineItemId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's plans <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_plans">list_plans api documentation</see>
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
        Pager<Plan> ListPlans(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null);


        /// <summary>
        /// Create a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Plan CreatePlan(PlanCreate body);

        /// <summary>
        /// Create a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_plan">create_plan api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Plan> CreatePlanAsync(PlanCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Plan GetPlan(string planId);

        /// <summary>
        /// Fetch a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_plan">get_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Plan> GetPlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Plan UpdatePlan(string planId, PlanUpdate body);

        /// <summary>
        /// Update a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_plan">update_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A plan.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Plan> UpdatePlanAsync(string planId, PlanUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Plan RemovePlan(string planId);

        /// <summary>
        /// Remove a plan <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_plan">remove_plan api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// Plan deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Plan> RemovePlanAsync(string planId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a plan's add-ons <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_plan_add_ons">list_plan_add_ons api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
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
        Pager<AddOn> ListPlanAddOns(string planId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null);


        /// <summary>
        /// Create an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AddOn CreatePlanAddOn(string planId, AddOnCreate body);

        /// <summary>
        /// Create an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_plan_add_on">create_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AddOn> CreatePlanAddOnAsync(string planId, AddOnCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a plan's add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AddOn GetPlanAddOn(string planId, string addOnId);

        /// <summary>
        /// Fetch a plan's add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_plan_add_on">get_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AddOn> GetPlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AddOn UpdatePlanAddOn(string planId, string addOnId, AddOnUpdate body);

        /// <summary>
        /// Update an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/update_plan_add_on">update_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AddOn> UpdatePlanAddOnAsync(string planId, string addOnId, AddOnUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Remove an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AddOn RemovePlanAddOn(string planId, string addOnId);

        /// <summary>
        /// Remove an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_plan_add_on">remove_plan_add_on api documentation</see>
        /// </summary>
        /// <param name="planId">Plan ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// Add-on deleted
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AddOn> RemovePlanAddOnAsync(string planId, string addOnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's add-ons <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_add_ons">list_add_ons api documentation</see>
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
        Pager<AddOn> ListAddOns(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null);


        /// <summary>
        /// Fetch an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        AddOn GetAddOn(string addOnId);

        /// <summary>
        /// Fetch an add-on <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_add_on">get_add_on api documentation</see>
        /// </summary>
        /// <param name="addOnId">Add-on ID or code (use prefix: `code-`, e.g. `code-gold`).</param>
        /// <returns>
        /// An add-on.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<AddOn> GetAddOnAsync(string addOnId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a site's subscriptions <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_subscriptions">list_subscriptions api documentation</see>
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
        Pager<Subscription> ListSubscriptions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string state = null);


        /// <summary>
        /// Create a new subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription CreateSubscription(SubscriptionCreate body);

        /// <summary>
        /// Create a new subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_subscription">create_subscription api documentation</see>
        /// </summary>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> CreateSubscriptionAsync(SubscriptionCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription GetSubscription(string subscriptionId);

        /// <summary>
        /// Fetch a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_subscription">get_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> GetSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Modify a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/modify_subscription">modify_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription ModifySubscription(string subscriptionId, SubscriptionUpdate body);

        /// <summary>
        /// Modify a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/modify_subscription">modify_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> ModifySubscriptionAsync(string subscriptionId, SubscriptionUpdate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Terminate a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="refund">The type of refund to perform:    * `full` - Performs a full refund of the last invoice for the current subscription term.  * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.  * `none` - Terminates the subscription without a refund.    In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.    You may also terminate a subscription with no refund and then manually refund specific invoices.  </param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription TerminateSubscription(string subscriptionId, string refund = null);

        /// <summary>
        /// Terminate a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/terminate_subscription">terminate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="refund">The type of refund to perform:    * `full` - Performs a full refund of the last invoice for the current subscription term.  * `partial` - Prorates a refund based on the amount of time remaining in the current bill cycle.  * `none` - Terminates the subscription without a refund.    In the event that the most recent invoice is a $0 invoice paid entirely by credit, Recurly will apply the credit back to the customer’s account.    You may also terminate a subscription with no refund and then manually refund specific invoices.  </param>
        /// <returns>
        /// An expired subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> TerminateSubscriptionAsync(string subscriptionId, string refund = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Cancel a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription CancelSubscription(string subscriptionId);

        /// <summary>
        /// Cancel a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/cancel_subscription">cancel_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A canceled or failed subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> CancelSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Reactivate a canceled subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription ReactivateSubscription(string subscriptionId);

        /// <summary>
        /// Reactivate a canceled subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_subscription">reactivate_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// An active subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> ReactivateSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Pause subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription PauseSubscription(string subscriptionId, SubscriptionPause body);

        /// <summary>
        /// Pause subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/pause_subscription">pause_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> PauseSubscriptionAsync(string subscriptionId, SubscriptionPause body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resume subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Subscription ResumeSubscription(string subscriptionId);

        /// <summary>
        /// Resume subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/resume_subscription">resume_subscription api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Subscription> ResumeSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a subscription's pending change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        SubscriptionChange GetSubscriptionChange(string subscriptionId);

        /// <summary>
        /// Fetch a subscription's pending change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_subscription_change">get_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A subscription's pending change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<SubscriptionChange> GetSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a new subscription change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        SubscriptionChange CreateSubscriptionChange(string subscriptionId, SubscriptionChangeCreate body);

        /// <summary>
        /// Create a new subscription change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/create_subscription_change">create_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>
        /// A subscription change.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<SubscriptionChange> CreateSubscriptionChangeAsync(string subscriptionId, SubscriptionChangeCreate body, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete the pending subscription change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        void RemoveSubscriptionChange(string subscriptionId);

        /// <summary>
        /// Delete the pending subscription change <see href="https://partner-docs.recurly.com/v2018-08-09#operation/remove_subscription_change">remove_subscription_change api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// Subscription change was deleted.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<object> RemoveSubscriptionChangeAsync(string subscriptionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List a subscription's invoices <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_subscription_invoices">list_subscription_invoices api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
        Pager<Invoice> ListSubscriptionInvoices(string subscriptionId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null);


        /// <summary>
        /// List a subscription's line items <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_subscription_line_items">list_subscription_line_items api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
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
        Pager<LineItem> ListSubscriptionLineItems(string subscriptionId, string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string original = null, string state = null, string type = null);


        /// <summary>
        /// Show the coupon redemptions for a subscription <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_subscription_coupon_redemptions">list_subscription_coupon_redemptions api documentation</see>
        /// </summary>
        /// <param name="subscriptionId">Subscription ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <param name="ids">Filter results by their IDs. Up to 200 IDs can be passed at once using  commas as separators, e.g. `ids=h1at4d57xlmy,gyqgg0d3v9n1,jrsm5b4yefg6`.    **Important notes:**    * The `ids` parameter cannot be used with any other ordering or filtering    parameters (`limit`, `order`, `sort`, `begin_time`, `end_time`, etc)  * Invalid or unknown IDs will be ignored, so you should check that the    results correspond to your request.  * Records are returned in an arbitrary order. Since results are all    returned at once you can sort the records yourself.  </param>
        /// <param name="sort">Sort field. You *really* only want to sort by `updated_at` in ascending  order. In descending order updated records will move behind the cursor and could  prevent some records from being returned.  </param>
        /// <param name="beginTime">Filter by begin_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <param name="endTime">Filter by end_time when `sort=created_at` or `sort=updated_at`.  **Note:** this value is an ISO8601 timestamp. A partial timestamp that does not include a time zone will default to UTC.  </param>
        /// <returns>
        /// A list of the the coupon redemptions on a subscription.
        /// </returns>
        Pager<CouponRedemption> ListSubscriptionCouponRedemptions(string subscriptionId, string ids = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null);


        /// <summary>
        /// List a site's transactions <see href="https://partner-docs.recurly.com/v2018-08-09#operation/list_transactions">list_transactions api documentation</see>
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
        Pager<Transaction> ListTransactions(string ids = null, int? limit = null, string order = null, string sort = null, DateTime? beginTime = null, DateTime? endTime = null, string type = null, string success = null);


        /// <summary>
        /// Fetch a transaction <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="transactionId">Transaction ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Transaction GetTransaction(string transactionId);

        /// <summary>
        /// Fetch a transaction <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_transaction">get_transaction api documentation</see>
        /// </summary>
        /// <param name="transactionId">Transaction ID or UUID (use prefix: `uuid-`, e.g. `uuid-123457890`).</param>
        /// <returns>
        /// A transaction.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<Transaction> GetTransactionAsync(string transactionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fetch a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        UniqueCouponCode GetUniqueCouponCode(string uniqueCouponCodeId);

        /// <summary>
        /// Fetch a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/get_unique_coupon_code">get_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<UniqueCouponCode> GetUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deactivate a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        UniqueCouponCode DeactivateUniqueCouponCode(string uniqueCouponCodeId);

        /// <summary>
        /// Deactivate a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/deactivate_unique_coupon_code">deactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<UniqueCouponCode> DeactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restore a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        UniqueCouponCode ReactivateUniqueCouponCode(string uniqueCouponCodeId);

        /// <summary>
        /// Restore a unique coupon code <see href="https://partner-docs.recurly.com/v2018-08-09#operation/reactivate_unique_coupon_code">reactivate_unique_coupon_code api documentation</see>
        /// </summary>
        /// <param name="uniqueCouponCodeId">Unique Coupon Code ID or code (use prefix: `code-`, e.g. `code-abc-8dh2-def`).</param>
        /// <returns>
        /// A unique coupon code.
        /// </returns>
        /// <exception cref="Recurly.Errors.ApiError">Thrown when the request is invalid.</exception>
        Task<UniqueCouponCode> ReactivateUniqueCouponCodeAsync(string uniqueCouponCodeId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
