#Accounts

##List Accounts
```c#
var accounts = Accounts.List();
while(accounts.Any())
{
	foreach(var account in accounts)
		Console.WriteLine(account);
	accounts = accounts.Next;
}
```

##Get Account
```c#
try
{
	var account = Accounts.Get("1");
	Console.WriteLine("Account " + account);
}
catch(NotFoundException e)
{
	Console.WriteLine("Account not found.");
}
```
**Please note**: the client library will raise an exception if the account is not found.

##Create Account
```c#
var account = new Account("1")
{
	Email = "verena@example.com",
	FirstName = "Verena",
	LastName = "Example"
};
account.Create();
```

##Close Account
```c#
var account = Accounts.Get("1");
account.Close();
```

##Reopen Account
```c#
var account = Accounts.Get("1");
account.Reopen();
```
##List Account Notes
```c#
var account = Accounts.Get("1");
var notes = account.GetNotes();
while(notes.Any())
{
	foreach(var note in notes)
		Console.WriteLine("Note: " + note.Message);
	notes = notes.Next;
}
```

#Adjustments
##List and account's adjustments
```c#
var account = Accounts.Get("1");
var adjustments = account.GetAdjustments();
while(adjustments.Any())
{
	foreach(var adjustment in adjustments)
		Console.WriteLine("Adjustment: " + adjustment);
	adjustments = adjustments.Next;
}
```

##Get an adjustment

```c#
var adjustment = Adjustments.Get("123456789");
Console.WriteLine("Adjustment: " + adjustment);
```

##Create a charge or credit
```c#
var account = Accounts.Get("1");
var adjustment = account.CreateAdjustment(
	"Charge for extra bandwidth", // description
	5000, // unit_amount_in_cents
	"USD", // currency
	1, // quantity
	"bandwidth", // accounting_code
	false); // tax_exempt
adjustment.Create();
```

##Delete an adjustment
```c#
var adjustment = Adjustments.Get("123456789");
adjustment.Delete()
```

#BillingInfo
##Lookup an account's billing info
```c#
var account = Accounts.Get("1");
var info = account.BillingInfo;
```

##Update an account's billing info
```c#
var account = Accounts.Get("1");
var info = account.BillingInfo;
info.FirstName = "Verana";
info.LastName = "Example";
info.PhoneNumber = "111-111-1111";
info.VerificationValue = "123";
info.ExpirationMonth = 11;
info.ExpirationYear = 2015;
info.Update();
```

##Clear an account's billing info
```c#
var account = Accounts.Get("1");
account.ClearBillingInfo();
```

#Coupon

##List active coupons
```c#
var coupons = Coupons.List();
while(coupons.Any())
{
	foreach(var coupon in coupons)
		Console.WriteLine("Coupon: " + coupon);
	coupons = coupons.Next;
}
```

##Lookup a coupon
```c#
var coupon = Coupons.Get("special");
```

##Create coupon
```c#
// $2 off...
var coupon = new Coupon("special", "Special $2 off coupon", new Dictionary<string, int> {{"USD", 200}});

// ...or 10% off
var coupon = new Coupon("special", "Special $2 off coupon", 10);

// Other properties
coupon.RedeemByDate = new DateTime(2014, 1, 1);
coupon.SingleUse = true;

// Limit to gold and platinum plans only.
coupon.AppliesToAllPlans = false;
coupon.Plans.Add("gold");
coupon.Plans.Add("silver");

coupon.Create();
```

##Deactivate coupon
```c#
var coupon = Coupons.Get("special");
coupon.Deactivate();
```

#Coupon Redemptions

##Redeem a coupon before or after a subscription
```c#
var account = Accounts.Get("1");
var redemption = account.Redeem("special", "USD");
```

##Lookup a coupon redemption on an account
```c#
var account = Accounts.Get("1");
var redemption = account.GetActiveCoupon();
```

##Remove a coupon from an account
```c#
var account = Accounts.Get("1");
var redemption = account.GetActiveCoupon();
redemption.Delete();
```

##Lookup a coupon redemption on an invoice
```c#
var invoice = Invoices.Get(1);
var redemption = invoice.GetCoupon();
```

#Invoices

##List invoices
```c#
var invoices = Invoices.List();
while(invoices.Any())
{
	foreach(var invoice in invoices)
		Console.WriteLine("Invoice: " + invoice);
	invoices = invoices.Next;
}
```

##List an account's invoices
```c#
var invoices = Invoices.List("1"); // account code
while(invoices.Any())
{
	foreach(var invoice in invoices)
		Console.WriteLine("Invoice: " + invoice);
	invoices = invoices.Next;
}
```

##Lookup invoice details
```c#
var invoice = Invoices.Get(1005);
```

##Retrieve a PDF invoice
```c#
var invoice = Invoices.Get(1005);
byte[] pdf = invoice.GetPdf();
```

##Post an invoice: invoice pending charges on an account
```c#
var account = Accounts.Get("1");
var invoice = account.InvoicePendingCharges()
```

##Mark an invoice as paid successfully
```c#
var invoice = Invoices.Get(1005);
invoice.MarkSuccessful();
```

##Mark an invoice as failed collection
```c#
var invoice = Invoices.Get(1005);
invoice.MarkFailed();
```

##Line item refunds
```c#
var invoice = Invoices.Get(1005);
var adjustment = invoice.Adjustments.First(x => x.Uuid == "e1234245132465");
invoice = invoice.Refund(adjustment, false, 1); // adjustment, prorate, quantity
```

#Plans
##List plans
```c#
var plans = Plans.List();
while(plans.Any())
{
	foreach(var plan in plans)
		Console.WriteLine("Plan: " + plan);
	plans = plans.Next;
}
```

##Lookup plan details
```c#
var plan = Plans.Get("gold");
```

##Create plan
```c#
var plan = new Plan("gold", "Gold plan"); // plan code, name
plan.UnitAmountInCents.Add("USD", 1000);
plan.UnitAmountInCents.Add("EUR", 800);
plan.SetupFeeInCents.Add("USD", 6000);
plan.SetupFeeInCents.Add("EUR", 4500);
plan.PlanIntervalLength = 1;
plan.PlanIntervalUnit = Plan.IntervalUnit.Month;
plan.TaxExempt = false;
plan.Create();
```

##Update Plan
```c#
var plan = Plans.Get("gold");
plan.SetupFeeInCents["EUR"] = 5000;
plan.Update();
```

##Delete Plan
```c#
var plan = Plans.Get("gold");
plan.Deactivate();
```

#Plan Addons

##List add-ons for a plan
```c#
var plan = Plans.Get("gold");
var addons = plan.AddOns;
while(addons.Any())
{
	foreach(var addon in addons)
		Console.WriteLine("Addon: " + addon);
	addons = addons.Next;
}
```

##Lookup an add-on
```c#
var plan = Plans.Get("gold");
var addon = plan.GetAddOn("addOnCode");
```

##Create an add-on
```c#
var plan = Plans.Get("gold");
var addon = plan.CreateAddOn("ipaddresses", "Extra IP Addresses"); // add-on code, name
addon.UnitAmountInCents.Add("USD", 200);
addon.Create();
```

##Update an add-on
```c#
var plan = Plans.Get("gold");
var addon = plan.GetAddOn("ipaddresses");
addon.UnitAmountInCents["USD"] = 200;
addon.Update();
```

##Delete an add-on
```c#
var plan = Plans.Get("gold");
var addon = plan.GetAddOn("ipaddresses");
addon.Deactivate();
```

#Subscriptions

##List Subscriptions
```c#
var subscriptions = Subscriptions.List();
while(subscriptions.Any())
{
	foreach(var plan in subscriptions)
		Console.WriteLine("Subscription: " + subscription);
	subscriptions = subscriptions.Next;
}
```

##List an account's subscriptions
```c#
var account = Accounts.Get("1");
var subscriptions = account.GetSubscriptions();
while(subscriptions.Any())
{
	foreach(var plan in subscriptions)
		Console.WriteLine("Subscription: " + subscription);
	subscriptions = subscriptions.Next;
}
```

##Lookup subscription details
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
```

##Create Subscription
```c#
var account = Accounts.Get("1");
var plan = Plans.Get("gold");
var subscription = new Subscription(account, plan, "USD"); // account, plan, currency
subscription.Create();
```

##Update subscription
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
subscription.Plan = Plans.Get("silver");
subscription.Quantity = 2;
subscription.ChangeSubscription(Subscription.ChangeTimeframe.Now); // performs the update operation
```

##Cancel a subscription
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
subscription.Cancel();
```

##Reactivating a canceled subscription
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
subscription.Reactivate();
```

##Terminate a subscription
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
subscription.Terminate(Subscription.RefundType.Full);
//subscription.Terminate(Subscription.RefundType.Partial);
//subscription.Terminate(Subscription.RefundType.None);
```

##Postpone a subscription
```c#
var subscription = Subscriptions.Get("44f83d7cba354d5b84812419f923ea96");
subscription.Postpone(new DateTime(2012, 12, 31));
```

##Preview a subscription
```c#
var account = Accounts.Get("1");
var plan = Plans.Get("gold");
var subscription = new Subscription(account, plan, "USD"); // account, plan, currency
subscription.Preview();
```