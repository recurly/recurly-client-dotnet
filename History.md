Unreleased
===============

1.5.0 (stable) / 2017-06-07
===============

* Added account balance endpoint
* Added plan and subscription changes
* Fixing NullReferenceException in List() functions
* Fixed a probable NRE in Plans.List()
* Remove X-Records Header and RecurlyList #Capacity method

### Upgrade Notes

This release will upgrade us to API version 2.6. There are two breaking changes:

1. To speed up your listing requests we’re no longer automatically computing the record counts for each requests. For our larger sites this could halve the response time. So in this release, we are removing the `RecurlyList#Capacity` method.
to be cached for you. For more info see [PR #324](https://github.com/recurly/recurly-client-ruby/pull/324).
2. For `POST /v2/subscriptions` Sending `null` for `total_billing_cycles` attribute will now override plan `total_billing_cycles` setting and will make subscription renew forever.
Omitting the attribute will cause the setting to default to the value of plan `total_billing_cycles`.


1.4.13 (stable) / 2017-05-04
===============

* Removing `trial_requires_billing_info` from Plan (which is in api 2.6)

1.4.12 (stable) / 2017-04-06
===============

* API 2.5 additions
* Sorting and Filtering parameters
* Refactored Invoice/PreviewPendingCharges to be able to specify notes 

1.4.11 (stable) / 2017-02-16
===============

* Automated export feature #221
* Modified overridden gethashcode to work on null references #220

1.4.10 (stable) / 2017-02-06
===============

* Add missing enum values #215

1.4.9 (stable) / 2017-01-20
===============

* Write amazon_billing_agreement_id #209
* Added support for new invoice and transactions states for ACH billing #212

1.4.7 (stable) / 2017-01-11
===============

Fixes a bug in 1.4.6. Please prefer this release.

* Fix TotalBillingCycles nil value #206

1.4.6 (stable) / 2017-01-09
===============

* Fix null Datetime Xml reading for Adjustment StartDate and UpdatedAt #199 
* Parse transaction_error #200 
* Updated test project to use latest version of Xunit #202
* Add total_billing_cycles reader #203


1.4.5 (stable) / 2016-12-06
===============

* allow addresses to be null, and don't force-create one when fetching #186
* Update BillingInfo.cs (Adding PayPal) #191
* Add Invoice Create and Preview data #193
* Make PoNumber always available to write on Subscription #194

1.4.4 (stable) / 2016-11-17
===============

* fixed; Allow skip trial period by setting date in the past
* added; Add .vscode to gitignore
* added; UsageList class

1.4.3 (stable) / 2016-10-21
===============

* fixed; NetTerms null exception for manual subscriptions
* added; Subscription.SubscriptionState.Failed
* added; Support for free trial coupons

1.4.2 (stable) / 2016-10-03
==================

* added; Allow `UsageTimestamp` to be null (defaults to server time)


1.4.1 (stable) / 2016-09-21
==================

* fixed; nil parsing error on usage creation


1.4.0 (stable) / 2016-09-19
==================

This release brings us to API version 2.3

* added; `PlanCode` public reader on Subscription
* fixed; bug with updating an AddOn
* fixed; TLS preferences missing constants
* added; `cc_emails` to `Account`
* fixed; `Adjustment#Get` and related tests
* added; `Currency` attribute on `BillingInfo`
* added; Changes for API v2.2
* added; `PaymentMethod` attribute on `Transaction`
* added; new optional config loading with `SettingsManager`
* added; error case for http status code 400
* added; Usage based billing support

1.3.1 (stable) / 2015-11-19
==================

* fixed; invoice reader on `Subscription`

1.3.0 (stable) / 2015-11-18
==================

* Retargeting to .NET version 4.5 for TLS headers
* added; explicit TLS 1.2 and 1.1 settings
* fixed; `Add(planAddOnCode, quantity)` method of `SubscriptionAddOnList`

1.2.7 (stable) / 2015-11-17
==================

* added; `Open` state to `Subscription`
* fixed; Subscription Pending integration test
* fixed; referencing an `Invoice` from a `Subscription` returns the invoice

1.2.6 (stable) / 2015-11-04
==================

* Fixes bad build

1.2.5 (stable) / 2015-11-03
==================

* added; multiple redemption support `GetRedemptions` for `Invoice`
* added; description readers to `Coupon` ReadXml
* added; `PreviewChange` method for `Subscription`
* added; `Update()` and `Restore()` paths to `Coupon`
* added; Bulk and Unique Coupons support
* added; Coupon default to SingleCode


1.2.4 (stable) / 2015-09-15
==================

* added; `SetupFeeAccountingCode` to `Plan`
* added; `SubscriptionUuid` to `CouponRedemption`
* added; `AppliesToNonPlanCharges` attribute `Coupon`
* added; `Coupons` to `Subscription`
* added; `uuid` to `CouponRedemption`
* added; `GetActiveRedemptions` to `Account`
* added; `X-Api-Version` to `2.1`
* added; `RedemptionResource` to `Coupon`
* added; `MaxRedemptionsPerAccount` to `Coupon`
* fixed; `AddOn.GetHashCode()` exception
* fixed; Don't send billing info when token present


1.2.3 (stable) / 2015-08-14
==================

* added; `Duration` to `Coupon`
* added; `TemporalUnit` to `Coupon`
* added; `TemporalAmount` to `Coupon`
* fixed; Parse embedded invoice on subscription/preview

1.2.2 (stable) / 2015-07-06
==================

* added; `bulk` param to `Postpone` call on `Subscription`
* fixed; no content returning from the server will no longer throw "Root element is missing"
* added; `TaxRegion` to `Invoice`
* added; `ProductCode` to `Adjustment`
* added; ability to specify either credit or transaction priority on refunds
* added; ability to give a `Transaction` a `Description`
* added; `TaxExempt`, `TaxCode`, `AccountingCode` to `Transaction`

1.2.1 (stable) / 2015-05-26
==================

* added; `BankAccountAuthorizedAt` to `Subscription`
* added; `IpAddress` to `Transaction`

1.2.0 (stable) / 2015-04-28
==================

* added; bank account fields to `BillingInfo`
 * `AccountType` (`Checking` or `Savings`)
 * `RoutingNumber`
 * `AccountNumber`
 * `LastFour`
 * `NameOnAccount`
* added; `invoice.InvoiceNumberPrefix` and `invoice.InvoiceNumberWithPrefix()`
* added; `transaction.GetInvoice()`
* added; `invoice.GetOriginalInvoice()`
* added; `TaxType`, `TaxRate`, `TaxRegion` on Adjustment

1.1.9 (stable) / 2015-04-01
==================

* fixed; nil VatLocationValid on Account would throw a parse error
* added; `subscription.UpdateNotes` will update the subscription's notes
* added; `subscription.CustomerNotes`, `subscription.TermsAndConditions`, `subscription.VatReverseChargeNotes`
* added; `invoice.CustomerNotes`, `invoice.TermsAndConditions`, `invoice.VatReverseChargeNotes`

1.1.8 (stable) / 2015-01-26
==================

* added; invoice address on previews
* added; `invoice.OriginalInvoiceNumber`
* added; VatLocationValid to Account
* fixed; clearing subscription addons from subscription
* added; Open Amount Refunds to Invoice

1.1.7 (stable) / 2014-12-19
==================

 * added; invoice previews
 * added; subscription address on previews

1.1.6 (stable) / 2014-09-18
==================

 * added; entity use code on accounts
 * added; amazon and paypal billing agreement id support

1.1.5 (stable) / 2014-07-30
==================

 * fixed; keep add on unit amount when adding to a subscription

1.1.4 (stable) / 2014-07-23
==================

 * updated; make the List.Clear() and List.RemoveAt() methods public

1.1.3 (stable) / 2014-07-22
==================

 * fixed; change subscription to Manual if Automatic collecting when posting a Subscription
 * fixed; Subscription.postpone() now sends the correct date/time format

1.1.2 (stable) / 2014-06-26
==================

 * fixed; change subscription to Manual if Automatic collecting

1.1.1 (stable) / 2014-05-01
==================

 * fixed; SubscriptionAddOnList.Add is now public https://github.com/recurly/recurly-client-net/pull/27
 * docs; added BillingInfo TokenId example

1.1.0 (stable) / 2014-04-30
==================

 * fixed; creating accounts w/o address
 * updated; user agent
 * updated; handle more error details
 * added; support for BillingInfo tokens
 * tests; Updates UpdateBillingInfoWithToken test to expect a 404
 * tests; add missing fixtures

1.0.0 (stable) / 2014-04-22
===========================

 * docs; add NuGet instructions

1.0.0-rc1 / 2014-04-14
==================

 * removed; account.CreateAdjustment(). use account.NewAdjustment() instead
 * changed; Recurly.Exception -> Recurly.RecurlyException #21
 * changed; Invoice#Refund() now returns a new Invoice object
 * changed; Invoice.CreateAt is now nullable
 * changed; plan.CreateAddOn() -> plan.NewAddOn()
 * fixed; duplicate Coupon.Plans triggered by API response
 * fixed; missing plan error
 * fixed; Invoice.Transactions duplicates triggered by API response
 * fixed; RecurlyList.Capacity when no Items exist
 * fixed; Invoices.List() returning all invoices
 * added; more List methods to RecurlyList
 * added; Subscription#Addons.Add now supports more handy overloads
 * added; support for multiple Refunds
 * added; more flexible Refund constructors
 * added; more support for returned properties in Invoice API responses
 * added; make Now the default timeframe for Subscription#ChangeSubsciption()
 * added; Subscription.Preview() support
 * added; Invoice.TaxRate
 * added; Invoice.TaxType
 * added; Subscription.TaxType
 * added; Subscription.TaxRate
 * added; Subscription.TaxInCents
 * added; Vat and TaxExempt Account properties
 * added; permit setting Adjustment properties on the instance
 * added; account.NewAdjustment()
 * added; allow users to set Adjustment.TaxExempt
 * docs; update examples
 * docs; subscription.AddOns.Add() overloads
 * docs; fix configSection
 * tests; remove redundant test
 * tests; wait for API to respond
 * tests; added for multiple refunds
 * tests; added for Subscription#Preview()
 * tests; updating Account with tax & vat

1.0.0-beta3 / 2014-03-31
==================

 * subscription; fix total_billing_cycles retrieval
 * subscription addons; fixed Create & Update
 * tests; Subscription w/ Coupons
 * tests; subscription update improvements
 * docs; updated intellisense

1.0.0-beta2 / 2014-03-19
==================

 * changed; AddOn.UnitAmountInCents Dictionary now implicit
 * fixed; Subscription; duplicate <account> info written to xml
 * fixed; AddOn add_on_code in generated xml
 * fixed; AddOn.Create with UnitAmountInCents
 * fixed; AddOn.Create url
 * docs; updated
 * tests; added Subscription create with Plan & change

1.0.0-beta1 / 2014-03-01
========================

  * complete rewrite
  * added; API v2 support
