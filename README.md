# Recurly .NET Client

**The majority of the Recurly API v2 objects are supported, however there may be a
few that are still in progress or were missed. Please report any questions or issues via Github.**

The Official .NET [Recurly API](https://dev.recurly.com/docs/getting-started) client library.

Compatible with Recurly API v2.

Versions >= 1.3.0 of this library are targeted against .NET v4.5.
Versions < 1.3.0 are targeted against .NET v3.5.

## Installation

If you use [NuGet](http://www.nuget.org/), simply run the following:

```sh
PM> Install-Package recurly-api-client
```

You may also visit our [Releases](https://github.com/recurly/recurly-client-net/releases) page to
download the latest version. Then add the `Recurly.dll` as a
[reference](http://msdn.microsoft.com/en-us/library/hh708954.aspx) to your solution.

Alternatively, you can use use [git](http://git-scm.com/) to work with the latest changes in **development**.

```sh
git clone git://github.com/recurly/recurly-client-net.git C:\path\to\recurly
```

For more information about getting started with git, please check out the
[Github Guide for Windows](http://github.com/guides/using-git-and-github-for-the-windows-for-newbies).

## Configuration

Specify your [API Key, site subdomain](https://app.recurly.com/go/developer/api_access), and (optionally) page size
setting in your `app.config` or `web.config` file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="recurly" type="Recurly.Configuration.Section,Recurly"/>
  </configSections>

  <recurly
    apiKey="123456789012345678901234567890ab"
    subdomain="company"
	pageSize="50" /> <!-- optional. 50 is the default -->

</configuration>
```

## Client Documentation

The API documentation is available on our [developer docs site](https://dev.recurly.com/docs/getting-started)
You can find .NET examples there but we have some examples in [examples.md](./examples.md).

## Overview Usage

### Creating Resources

To create a resource, initialize it, set the desired parameters, then call `Create()`.
The instance will be auto-updated with the new details from the server. Here is an
example of creating an [Account](https://dev.recurly.com/docs/create-an-account):

```c#
var account = new Account("123")
{
  FirstName = "John",
  LastName = "Smith"
};
account.Create();
Console.WriteLine(account.CreatedAt);
```

### Fetching Resources

All resources have some kind of identifier. The API docs site should help you understand how to reference
the resource you want. In the case of the `Account`, we can reference it by `AccountCode`. Call `Get` on a
resource class to fetch the resource with the given identifier.

```c#
var account = Accounts.Get("123");
```

### Pagination

Sometimes, if you wish to enumerate many resources on the server, you will need to make multiple HTTP calls to the server.
This is called pagination. Pagination in this library is handled by the `RecurlyList` class. An instance of this class can be
created by calling `List()` on the plural-named resource class (e.g. `Account` -> `Accounts`). For example, suppose we wish to
iterate over every account on our site:

```c#
// returns a RecurlyList instance
var accounts = Accounts.List();

// while the server still has accounts to give
while (accounts.Any())
{
  // iterate through each account in this "page"
  foreach (var account in accounts)
    Console.WriteLine(account);

  // fetch the next "page" of accounts
  accounts = accounts.Next;
}
```

It's also possible to sort and/or filter this stream of resources by passing in parameters to the `List()` method and
using the `FilterCriteria` class. Here is an example of sorting and filtering accounts:

```c#
var filter = FilterCriteria.Instance               // create the instance
        .WithOrder(FilterCriteria.Order.Desc)      // order the results in "descending" order
        .WithSort(FilterCriteria.Sort.UpdatedAt)   // sort by the `UpdatedAt` property
        .WithBeginTime(new DateTime(2017, 1, 1))   // filter out any accounts updated before January 1st, 2017
        .WithEndTime(DateTime.UtcNow);             // filter accounts updated to this moment (could be any date after `BeginTime`)

// The first parameter of Accounts.List allows you to filter by the `State` of the account.
// In this case, let's only look at `Active` accounts.
var accounts = Accounts.List(Account.AccountState.Active, filter);
foreach (var account in accounts)
{
    Console.Write(account.AccountCode + ": ");
    Console.WriteLine(account.UpdatedAt);
}
```

Every `List()` method takes a `FilterCriteria` as the final parameter, but differs in the endpoint specific filters.
The best way to learn about this is by looking at the source code or the code docs.

## Support

Looking for help? Please contact [support@recurly.com](mailto:support@recurly.com) or visit
[support.recurly.com](https://support.recurly.com).

It's also acceptable to post a question, problem, or request as a GitHub issue on this repository and the developers
will try to get back to you in a timely manner.
