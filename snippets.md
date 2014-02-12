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

