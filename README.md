# Recurly .NET Client

The Recurly .NET Client library is an open source library to interact with Recurly's subscription management from your .NET application. The library interacts with Recurly's [REST API](https://docs.recurly.com/api). This library works with .NET 3.5 and greater and targets v2 of the Recurly API.

## Installation

The easiest way to get the source code is to click the **Download Source** button at the top of this page. Alternatively, you can use git.
With git installed, the easiest way to download the Recurly .NET Client is with the git command:

    git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly

If you do not have git and have some interest in learning about a wonderful source control tool, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration

Your API Key, site subdomain, private key, and (optionally) page size setting can be specified in your **app.config** or **web.config** file:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="recurly" type="Recurly.Configuration.RecurlySection,Recurly"/>
      </configSections>
      
      <recurly 
        apiKey="123456789012345678901234567890ab"
        privateKey="123456789012345678901234567890cd"
        subdomain="company"
		pageSize="50" /> <!-- 50 is the default -->
      
    </configuration>

## Getting Started
Add the Recurly project from the Library folder to your solution and reference it in the projects that will make calls to the Recurly service. Add your settings to your config file and you can start interacting with Recurly!

## Example usage
To create a new Recurly account with account code and name:

```c#
var account = new Account("123")
{
	FirstName = "John",
	LastName = "Smith"
}
account.Create();
```

To get a Recurly account with account code "123":

```c#
var account = Accounts.Get("123");
```

List all available accounts and print their account codes:

```c#
var accounts = Accounts.List();
foreach(var account in accounts)
	Console.WriteLine(account.AccountCode);
```

Get an account's billing information:

```c#
var account = Accounts.Get("123");
var info = account.BillingInfo;
```

Create a coupon with code **WINTER**, name, and with a 10% discount:

```c#
var coupon = new Coupon("WINTER", "Winter discount", 10);
coupon.Create();
```

Redeem that coupon on an account that uses US dollars, getting a CouponRedemption object:

```c#
var redemption = account.RedeemCoupon("WINTER", "USD");
```

All the major sections of the API (Accounts, Invoices, Transactions, etc.) have static references for getting or listing their types, and concrete implementations for manipulating concrete objects.


## To Do
* Final review against API specs


## API Documentation

Please see the [Recurly API](https://docs.recurly.com/api) for more information.