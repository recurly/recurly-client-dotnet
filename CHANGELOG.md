# Changelog

## [7.1.0](https://github.com/recurly/recurly-client-dotnet/tree/7.1.0) (2026-09-09)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/7.0.0...7.1.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#915](https://github.com/recurly/recurly-client-dotnet/pull/915) ([recurly-integrations](https://github.com/recurly-integrations))



## [7.0.0](https://github.com/recurly/recurly-client-dotnet/tree/7.0.0) (2026-09-02)


# Major Version Release

The 7.x major version of the client pairs with the `v2021-02-25` API version. While there are no breaking changes in the API, the client code does include breaking changes.

## Breaking Changes in the Client

- The data type for the `Recurly.Resources.Transaction` `GatewayResponseValues` property has been changed from `Dictionary<string, string>` to `Dictionary<string, object>` to properly handle non-string values



