# Changelog

## [4.4.0](https://github.com/recurly/recurly-client-dotnet/tree/4.4.0) (2021-06-14)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/4.3.0...4.4.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#642](https://github.com/recurly/recurly-client-dotnet/pull/642) ([recurly-integrations](https://github.com/recurly-integrations))



## [4.3.0](https://github.com/recurly/recurly-client-dotnet/tree/4.3.0) (2021-06-04)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/4.2.0...4.3.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#640](https://github.com/recurly/recurly-client-dotnet/pull/640) ([recurly-integrations](https://github.com/recurly-integrations))



## [4.2.0](https://github.com/recurly/recurly-client-dotnet/tree/4.2.0) (2021-04-21)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/4.1.0...4.2.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 [#634](https://github.com/recurly/recurly-client-dotnet/pull/634) ([recurly-integrations](https://github.com/recurly-integrations))



## [4.1.0](https://github.com/recurly/recurly-client-dotnet/tree/4.1.0) (2021-04-15)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/4.0.1...4.1.0)


**Merged Pull Requests**

- Generated Latest Changes for v2021-02-25 (Backup Payment Method) [#631](https://github.com/recurly/recurly-client-dotnet/pull/631) ([recurly-integrations](https://github.com/recurly-integrations))
- Generated Latest Changes for v2021-02-25 [#625](https://github.com/recurly/recurly-client-dotnet/pull/625) ([recurly-integrations](https://github.com/recurly-integrations))
- Generated Latest Changes for v2021-02-25 (Usage Percentage on Tiers) [#623](https://github.com/recurly/recurly-client-dotnet/pull/623) ([recurly-integrations](https://github.com/recurly-integrations))



## [4.0.1](https://github.com/recurly/recurly-client-dotnet/tree/4.0.1) (2021-03-23)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/4.0.0...4.0.1)


**Merged Pull Requests**

- Release 4.0.1 [#622](https://github.com/recurly/recurly-client-dotnet/pull/622) ([douglasmiller](https://github.com/douglasmiller))
- Generated Latest Changes for v2021-02-25 [#621](https://github.com/recurly/recurly-client-dotnet/pull/621) ([recurly-integrations](https://github.com/recurly-integrations))
- Sync updates not ported from 3.x client [#618](https://github.com/recurly/recurly-client-dotnet/pull/618) ([douglasmiller](https://github.com/douglasmiller))



## [4.0.0](https://github.com/recurly/recurly-client-dotnet/tree/4.0.0) (2021-03-01)


# Major Version Release

The 4.x major version of the client pairs with the `v2021-02-25` API version. This version of the client and the API contain breaking changes that should be considered before upgrading your integration.

## Breaking Changes in the API
All changes to the core API are documented in the [Developer Portal changelog](https://developers.recurly.com/api/changelog.html#v2021-02-25---current-ga-version)

## Breaking Changes in Client

- Convert float to decimal [[#562](https://github.com/recurly/recurly-client-dotnet/pull/562)]
- Return the `Empty` response object over void [[#565](https://github.com/recurly/recurly-client-dotnet/pull/565)]
- Fix deserialization of unknown enum values [[#571](https://github.com/recurly/recurly-client-dotnet/pull/571)]
- Add `OptionalParams` and per-operation implementations [[#582](https://github.com/recurly/recurly-client-dotnet/pull/582)]
    ### 3.x
    ```c#
    var accounts = client.ListAccounts(limit: 200);
    ```

    ### 4.x
    ```c#
    var optionalParams = new ListAccountsParams()
    {
        Limit = 200
    };
    var accounts = client.ListAccounts(optionalParams);
    ```
- Add support for List types in optional query params instead of needing to generate a comma separated string. [[#584](https://github.com/recurly/recurly-client-dotnet/pull/584)]

    ### 3.x
    ```c#
    var accounts = client.ListAccounts(ids: "account-id-1,account-id-2,account-id-3");
    ```

    ### 4.x
    ```c#
    var optionalParams = new ListAccountsParams()
    {
        Ids = new List<string>() {
          "account-id-1",
          "account-id-2",
          "account-id-3",
        }
    };
    var accounts = client.ListAccounts(optionalParams);
    ```


