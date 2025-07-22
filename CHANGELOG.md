# Changelog

## [5.3.0](https://github.com/recurly/recurly-client-dotnet/tree/5.3.0) (2025-07-22)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/5.2.0...5.3.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#878](https://github.com/recurly/recurly-client-dotnet/pull/878) ([recurly-integrations](https://github.com/recurly-integrations))



## [5.2.0](https://github.com/recurly/recurly-client-dotnet/tree/5.2.0) (2025-07-09)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/5.1.0...5.2.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#877](https://github.com/recurly/recurly-client-dotnet/pull/877) ([recurly-integrations](https://github.com/recurly-integrations))



## [5.1.0](https://github.com/recurly/recurly-client-dotnet/tree/5.1.0) (2025-06-11)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/5.0.0...5.1.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#873](https://github.com/recurly/recurly-client-dotnet/pull/873) ([recurly-integrations](https://github.com/recurly-integrations))



## [5.0.0](https://github.com/recurly/recurly-client-dotnet/tree/5.0.0) (2025-05-16)


# Major Version Release

The 5.x major version of the client pairs with the `v2021-02-25` API version. While there are no breaking changes in the API, the client code does include breaking changes.

## Breaking Changes in the Client

- The `SubscriptionRampInterval` request class incorrectly sets the type of `UnitAmount` as `int`. This is being corrected to reflect the correct type of `decimal`.


