# Changelog

## [6.1.0](https://github.com/recurly/recurly-client-dotnet/tree/6.1.0) (2026-07-02)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/6.0.0...6.1.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#910](https://github.com/recurly/recurly-client-dotnet/pull/910) ([recurly-integrations](https://github.com/recurly-integrations))



## [6.0.0](https://github.com/recurly/recurly-client-dotnet/tree/6.0.0) (2026-06-22)


# Major Version Release

The 6.x major version of the client pairs with the `v2021-02-25` API version. While there are no breaking changes in the API, the client code does include breaking changes.

## Breaking Changes in the Client

- A new `DeactivateAccountParams optionalParams` has been added to the `DeactivateAccount` and `DeactivateAccountAsync` methods.
- The return type for the `ListEntitlements` has been renamed from `Pager<Entitlements>` to `Pager<Entitlement>` to address a bug in prior versions.


