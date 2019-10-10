# Recurly

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

### Contributing

Please see our [Contributing Guide](CONTRIBUTING.md).
