# Recurly

[![Nuget](https://img.shields.io/static/v1?label=nuget&message=recurly&color=purple)](https://www.nuget.org/packages/Recurly/)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg)](CODE_OF_CONDUCT.md)

This repository houses the official dotnet client for Recurly's V3 API.

> *Note*:
> If you were looking for the V2 client, see the [v2 branch](https://github.com/recurly/recurly-client-net/tree/v2).

Documentation for the HTTP API and example code can be found
[on our Developer Portal](https://developers.recurly.com/api/v2019-10-10/).

## Getting Started

### Installing

This package is published on Nuget under the name [Recurly](https://www.nuget.org/packages/Recurly).
We recommend using Nuget to install and maintain this dependency:

```
dotnet add package Recurly --version 3.*
```

If you are specifying in your `.csproj` file:

```xml
<ItemGroup>
  <PackageReference Include="Recurly" Version="3.*" />
  <!-- ... -->
</ItemGroup>
```

> *Note*: We try to follow [semantic versioning](https://semver.org/) and will only apply breaking changes to major versions.

### Creating a client

Client instances are now explicitly created and referenced as opposed to V2's use of global, statically
initialized clients.

This makes multithreaded environments simpler and provides one location where every
operation can be found (rather than having them spread out among classes).

`new Recurly.Client(apiKey)` initializes a new client. It only requires an API key
which can be obtained on the [API Credentials Page](https://app.recurly.com/go/integrations/api_keys).

```csharp
// Add this on the top of your file
using Recurly;
using Recurly.Resources;

const apiKey = "83749879bbde395b5fe0cc1a5abf8e5";
var client = new Recurly.Client(apiKey);
var sub = client.GetSubscription("uuid-abcd123456")
```

Optional arguments can be provided through object initializers.

```csharp
var client = new Recurly.Client(apiKey) { Timeout = 5000 }
```

### Operations

The `Recurly.Client` contains every `operation` you can perform on the site as a list of methods. Each method is documented explaining
the types and descriptions for each input and return type.

### Async Operations

Each operation in the `Recurly.Client` has an async equivalent method which ends in `Async`. Async operations return `Task<Resource>`
which can be `await`ed:

```csharp
var client = new Recurly.Client(apiKey);
var sub = await client.GetSubscription("uuid-abcd123456");
```

Async operations also support cancellation tokens. Here is an example of canceling a request before it executes:

```csharp
var cancellationTokenSource = new CancellationTokenSource();
var task = await client.GetSubscription("uuid-abcd123456", cancellationTokenSource.Token);

// Cancel the request before it finishes which will throw a
// System.Threading.Tasks.TaskCanceledException
cancellationTokenSource.Cancel();

task.Wait();
var sub = task.Result;
Console.WriteLine($"Subscription: {sub.Uuid}");
```

**Warning**: Be careful cancelling requests as you have no way of knowing whether or not they were completed
by the server. We only guarantee that server state does not change on GET requests.

### Pagination

Pagination is done by the class `Recurly.Pager<T>`. All `List*` methods on the client return an instance of this class.
The pager supports the `IEnumerable` and `IEnumerator` interfaces. The easiest way to use the pager is with `foreach`.

```csharp
var accounts = client.GetAccounts();
foreach(Account account in accounts)
{
  Console.WriteLine(account.Code);
}
```

The `FetchNextPage` method provides more control over the network calls. We recommend using this
interface for writing scripts that iterate over many pages. This allows you
to catch exceptions and safely retry without double processing or missing some elements:

```csharp
var accounts = client.ListAccounts();
while(accounts.HasMore)
{
    Console.WriteLine("Fetching next page...");
    accounts.FetchNextPage();
    foreach(Account a in accounts.Data)
    {
      Console.WriteLine($"Account: {a.CreatedAt}");
    }
}
```

For async pagination, await on `FetchNextPageAsync`:

```csharp
var accounts = client.ListAccounts();
while(accounts.HasMore)
{
    Console.WriteLine("Fetching next page...");
    await accounts.FetchNextPageAsync();
    foreach(Account a in accounts.Data)
    {
      Console.WriteLine($"Account: {a.CreatedAt}");
    }
}
```

#### Query Params

Query params can be passed to `List*` methods as named arguments. These will be used
to sort and filter the resources.

```csharp
var accounts = client.ListAccounts(
    limit: 200,
    beginTime: new DateTime(2019, 1, 1)
);
```

#### Additional Pager Methods

In addition to the methods to facilitate pagination, the Pager class provides 2 helper methods:

1. First
2. Count

##### First

The Pager's `First` method can be used to fetch only the first resource from the endpoint for the given parameters.

```csharp
var beginTime = new DateTime(2020, 1, 1);
var accounts = client.ListAccounts(
    beginTime: beginTime
);
var account = accounts.First();
Console.WriteLine(account.Code);
```

##### Count

The Pager's `Count` method will return the total number of resources that are available at the requested endpoint for the given parameters.

```csharp
var beginTime = new DateTime(2020, 1, 1);
var accounts = client.ListAccounts(
    beginTime: beginTime
);
var total = accounts.Count();
Console.WriteLine($"There are {total} accounts created since {beginTime}");
```

### Creating Resources

Every `Create*` or `Update*` method on the client takes a specific Request type to form the request.
This allows you to create requests in a type-safe manner. Request types are not necessarily 1-to-1 mappings of response types.

```csharp
var accountReq = new AccountCreate()
{
  Code = "myaccountcode",
  Address = new Address() {
    FirstName = "Benjamin",
    LastName = "DuMonde",
    Street1 = "123 Canal St.",
    PostalCode = "70115",
    Region = "LA",
    City = "New Orleans",
    Country = "US"
  }
};

// CreateAccount takes an AccountCreate object and returns an Account object
Account account = client.CreateAccount(accountReq);
Console.WriteLine(account.Address.City); // "New Orleans"
```

### Error Handling

This library currently throws 2 types of exceptions. They both exist as subclasses of `Recurly.RecurlyError`.

1. `Recurly.Errors.ApiError`
2. `Recurly.Errors.NetworkError`

`ApiError`s come from the Recurly API and each endpoint in the documentation describes the types of errors it
may return. These errors generally mean that something was wrong with the request. There are a number of subclasses
to `ApiError` which are derived from the error responses `type` json key.  A common scenario might be a `Validation` error:

```csharp
try
{
  var accountReq = new AccountCreate()
  {
    Code = "myaccountcode",
  };

  Account acct = client.CreateAccount(accountReq);
}
catch (Recurly.Errors.Validation ex)
{
  // Here we have a validation error and might want to
  // pass this information back to the user to fix
  Console.WriteLine($"Validation Error: {ex.Error.Message}");
}
catch (Recurly.Errors.ApiError ex)
{
  // Use base class ApiError to catch a generic error from the API
  Console.WriteLine($"Unexpected Recurly Error: {ex.Error.Message}");
}
```

`Recurly.Errors.NetworkError`s don't come from Recurly's servers, but instead are triggered by some problem
related to the network. Depending on the context, you can often automatically retry these calls.
GETs are always safe to retry but be careful about automatically re-trying any other call that might mutate state on the server side
as we cannot guarantee that it will not be executed twice.

```csharp
try
{
  Account acct = client.GetAccount("code-my-account-code");
}
catch (Recurly.Errors.NetworkError ex)
{
  // Here you might want to determine what kind of NetworkError this is
  // The options for ExceptionStatus are defined here: https://docs.microsoft.com/en-us/dotnet/api/system.net.webexceptionstatus
  switch (ex.ExceptionStatus)
  {
    case WebException.Timeout:
      // The server timed out
      // probably safe to retry after waiting a moment
      break;
    case WebException.ConnectFailure:
      // Could not connect to Recurly's servers
      // This is hopefully a temporary problem and is safe to retry after waiting a moment
      break;
    default:
      // If we don't know what to do with it, we should
      // probably re-raise and let our web framework or logger handle it
      throw;
  }
}
```

### HTTP Metadata

Sometimes you might want to get some additional information about the underlying HTTP request and response. Instead of returning this information directly and forcing the programmer to unwrap it, we inject this metadata into the top level resource that was returned. You can access the response by calling `GetResponse()` on any Resource.

```csharp
Account account = client.GetAccount(accountId);
Response response = account.GetResponse();
response.RawResponse // String body of the API response
response.StatusCode // HTTP status code of the API response
response.RequestId // "5b7019241a21d314-ATL"
response.Headers // IList<Parameter> of all API response headers
```

Rate Limit information is also accessible on the `Response` class. These values will be `null` when the corresponding headers are absent from the response. More information can be found on the developer portal's [Rate Limits](https://developers.recurly.com/api/v2019-10-10/index.html#section/Getting-Started/Limits) section.
```csharp
response.RateLimit // 2000  
response.RateLimitRemaining // 1990
response.RateLimitReset // 1595965380
```

### A Note on Headers

In accordance with [section 4.2 of RFC 2616](https://www.ietf.org/rfc/rfc2616.txt), HTTP header fields are case-insensitive.

### Webhooks

Recurly can send webhooks to any publicly accessible server.
When an event in Recurly triggers a webhook (e.g., an account is opened),
Recurly will attempt to send this notification to the endpoint(s) you specify.
You can specify up to 10 endpoints through the application. All notifications will
be sent to all configured endpoints for your site. 

See our [product docs](https://docs.recurly.com/docs/webhooks) to learn more about webhooks
and see our [dev docs](https://developers.recurly.com/pages/webhooks.html) to learn about what payloads
are available.

Although our API is now JSON, our webhooks are currently still in XML format. This library is not responsible for webhooks, but the quickest way to handle them now is by using the [XmlDocument class](https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument). This class has helpful methods for
parsing XML and using XPath to inspect the elements. You could also look into mapping them to custom types if you want a more friendly experience. We will be supporting this in the near future.

```csharp
// XmlDocument is in System.Xml
// using System.Xml;

// This XML will arrive at the endpoint you have specified in Recurly.
// We're putting it in a string literal here for demonstration purposes
var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
+ "<new_account_notification>"
+ "<account>"
+   "<account_code>abc</account_code>"
+   "<username nil=\"true\"></username>"
+   "<email>verena@example.com</email>"
+   "<first_name>Verena</first_name>"
+   "<last_name>Example</last_name>"
+   "<company_name nil=\"true\"></company_name>"
+ "</account>"
+ "</new_account_notification>";

var doc = new XmlDocument();
doc.LoadXml(xml);

// This element will always contain the event name
// see the documentation for which events are supported
var eventName = doc.DocumentElement.Name;

// delegate to the code responsible for each event
// make sure you have a default fallback case as we may add events
// at any time.
switch (eventName) {
    case "new_account_notification":
        // handle new account notifcation
        var code = doc.DocumentElement.SelectSingleNode("//account/account_code")
        Console.WriteLine($"New Account Created in Recurly: {code.InnerText}");
        // prints "abc"
        break;
    default:
        Console.WriteLine($"Ignoring webhook with event name: {eventName}");
        break;
}
```


### Contributing

Please see our [Contributing Guide](CONTRIBUTING.md).
