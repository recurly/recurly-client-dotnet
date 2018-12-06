# Recurly

This package is the dotnet client for Recurly's V3 API (or "partner api"). It's currently Beta software
and is not yet an official release. Documentation for the API can be [found here](https://partner-docs.recurly.com).

## Getting Started

### Installing

This library is not yet published. We will start publishing pre-releases to nuget soon.

### Creating a client

Client instances are now explicitly created and referenced as opposed to V2's use of global, statically
initialized clients.

This makes multithreaded environments simpler and provides one location where every
operation can be found (rather than having them spread out among classes).

`new Recurly.Client(siteId, apiKey)` initializes a new client. It requires an API key and a site id:

```csharp
using Recurly;

const apiKey = "83749879bbde395b5fe0cc1a5abf8e5";
const subdomain = "mysubdomain";
const siteId = $"subdomain-{subdomain}"; // You could also use the site's reference id ex: "dqzlv9shi7wa"
var client = new Recurly.Client(siteId, apiKey);
var sub = client.GetSubscription("uuid-abcd123456")
```

### Operations

The `Recurly.Client` contains every `operation` you can perform on the site as a list of methods. Each method is documented explaining
the types and descriptions for each input and return type.

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

This library currently throws 1 type of exception `Recurly.ApiError`.

```csharp
try
{
  var account = client.GetAccount("code-idontexist");
}
catch (Recurly.ApiError ex)
{
  if (ex.Error.Type == Recurly.ApiErrorType.NotFound)
  {
    Console.WriteLine("404 Account could not be found");
  }
  else
  {
    Console.WriteLine("Something else wrong happened");
  }
}
```

## Development

### Dependencies

If you are on macos, you can use the `check-deps` or `install-deps` scripts to setup your development
dependencies. We only support doing this on macos at the moment.

```bash
./scripts/install-deps
```

### Testing

The tests can be found in `Recurly.Tests`. To run the tests, use the test script. This
will run the tests as well as the code coverage reporter.

```bash
./scripts/test
```
