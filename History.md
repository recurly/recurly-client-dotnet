Unreleased
==================

* added; `applies_to_non_plan_charges` attribute `Coupon`
* added; `Coupons` to `Subscription`
* added; `uuid` to `CouponRedemption`
* added; `GetActiveRedemptions` to `Account`
* added; `X-Api-Version` to `2.1`

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

