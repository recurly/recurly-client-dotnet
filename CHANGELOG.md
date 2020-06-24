# Changelog

## [3.7.1](https://github.com/recurly/recurly-client-dotnet/tree/3.7.1) (2020-06-24)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.7.0...3.7.1)

**Fixed bugs:**

- Ambiguous methods introduced in v3.7.0 [\#536](https://github.com/recurly/recurly-client-dotnet/issues/536)

**Merged pull requests:**

- Release 3.7.1 [\#538](https://github.com/recurly/recurly-client-dotnet/pull/538) ([douglasmiller](https://github.com/douglasmiller))
- Removing overloaded Async operation methods [\#537](https://github.com/recurly/recurly-client-dotnet/pull/537) ([douglasmiller](https://github.com/douglasmiller))

## [3.7.0](https://github.com/recurly/recurly-client-dotnet/tree/3.7.0) (2020-06-23)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.6.1...3.7.0)

**Fixed bugs:**

- ListAccountSubscriptions returning expired subscriptions when specifying state="live" [\#531](https://github.com/recurly/recurly-client-dotnet/issues/531)
- Fixing query parameter handling in the Pager class [\#532](https://github.com/recurly/recurly-client-dotnet/pull/532) ([douglasmiller](https://github.com/douglasmiller))

**Merged pull requests:**

- Release 3.7.0 [\#533](https://github.com/recurly/recurly-client-dotnet/pull/533) ([bhelx](https://github.com/bhelx))
- Document a way to handle webhooks [\#526](https://github.com/recurly/recurly-client-dotnet/pull/526) ([bhelx](https://github.com/bhelx))
- Adding RequestOptions to facilitate passing custom request headers [\#524](https://github.com/recurly/recurly-client-dotnet/pull/524) ([douglasmiller](https://github.com/douglasmiller))

## [3.6.1](https://github.com/recurly/recurly-client-dotnet/tree/3.6.1) (2020-06-04)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.6.0...3.6.1)

**Implemented enhancements:**

- Updating internal scripts to use globally installed dotnet-format [\#517](https://github.com/recurly/recurly-client-dotnet/pull/517) ([douglasmiller](https://github.com/douglasmiller))

**Fixed bugs:**

- Applying query params to url before creating the request [\#521](https://github.com/recurly/recurly-client-dotnet/pull/521) ([douglasmiller](https://github.com/douglasmiller))

**Merged pull requests:**

- Release 3.6.1 [\#523](https://github.com/recurly/recurly-client-dotnet/pull/523) ([bhelx](https://github.com/bhelx))
- Adding MockClient and refactoring tests to use it [\#522](https://github.com/recurly/recurly-client-dotnet/pull/522) ([douglasmiller](https://github.com/douglasmiller))

## [3.6.0](https://github.com/recurly/recurly-client-dotnet/tree/3.6.0) (2020-06-01)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.5.1...3.6.0)

**Implemented enhancements:**

- Latest Features [\#518](https://github.com/recurly/recurly-client-dotnet/pull/518) ([bhelx](https://github.com/bhelx))

**Fixed bugs:**

- Setting Next in Pager.Build to fix async pager requests [\#519](https://github.com/recurly/recurly-client-dotnet/pull/519) ([douglasmiller](https://github.com/douglasmiller))

**Merged pull requests:**

- Release 3.6.0 [\#520](https://github.com/recurly/recurly-client-dotnet/pull/520) ([bhelx](https://github.com/bhelx))

## [3.5.1](https://github.com/recurly/recurly-client-dotnet/tree/3.5.1) (2020-05-14)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.5.0...3.5.1)

## Potential Breaking Change Included

This release contains a bugfix which may result in a breaking change. If you are using the `GatewayResponseValues` property on the `Transaction` resource, the type has been changed from `Dictionary<string, string>` to `Dictionary<string, object>`. Look out for situations where the compiler may not help you understand that something may be wrong, example:

```csharp
// This may silently fail now that this is an object and not a string
// casting to the expected type from `object` is the appropriate way to handle values
if (transaction.GatewayResponseValues["key"] == "value") {
  // take some action
}
```

See [#512](https://github.com/recurly/recurly-client-dotnet/pull/512) for more information.

**Fixed bugs:**

- Bugfix: Unexpected character encountered while parsing value: "{" [\#512](https://github.com/recurly/recurly-client-dotnet/pull/512) ([bhelx](https://github.com/bhelx))

**Merged pull requests:**

- Release 3.5.1 [\#513](https://github.com/recurly/recurly-client-dotnet/pull/513) ([bhelx](https://github.com/bhelx))
- Upgrade test deps [\#511](https://github.com/recurly/recurly-client-dotnet/pull/511) ([bhelx](https://github.com/bhelx))
- Encode forward slashes in URL parameters [\#510](https://github.com/recurly/recurly-client-dotnet/pull/510) ([douglasmiller](https://github.com/douglasmiller))
- Ensure that path parameters are not empty strings [\#509](https://github.com/recurly/recurly-client-dotnet/pull/509) ([douglasmiller](https://github.com/douglasmiller))

## [3.5.0](https://github.com/recurly/recurly-client-dotnet/tree/3.5.0) (2020-04-20)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.4.1...3.5.0)

**Implemented enhancements:**

- Tue Apr 14 20:22:18 UTC 2020 Upgrade API version v2019-10-10 [\#505](https://github.com/recurly/recurly-client-dotnet/pull/505) ([bhelx](https://github.com/bhelx))
- Adding \#First and \#Count methods to Pager [\#491](https://github.com/recurly/recurly-client-dotnet/pull/491) ([douglasmiller](https://github.com/douglasmiller))

**Fixed bugs:**

- CreateAccountAsync\(\) does not permit first\_name, last\_name [\#402](https://github.com/recurly/recurly-client-dotnet/issues/402)

**Merged pull requests:**

- Release 3.5.0 [\#508](https://github.com/recurly/recurly-client-dotnet/pull/508) ([douglasmiller](https://github.com/douglasmiller))
- Included the to-be released changes in the changelog [\#504](https://github.com/recurly/recurly-client-dotnet/pull/504) ([douglasmiller](https://github.com/douglasmiller))
- Updating release script to be uniform across all clients [\#502](https://github.com/recurly/recurly-client-dotnet/pull/502) ([douglasmiller](https://github.com/douglasmiller))
- Thu Mar 26 20:42:11 UTC 2020 Upgrade API version v2019-10-10 [\#498](https://github.com/recurly/recurly-client-dotnet/pull/498) ([bhelx](https://github.com/bhelx))

## [3.4.1](https://github.com/recurly/recurly-client-dotnet/tree/3.4.1) (2020-03-20)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.4.0...3.4.1)

**Merged pull requests:**

- Release 3.4.1 [\#495](https://github.com/recurly/recurly-client-dotnet/pull/495) ([douglasmiller](https://github.com/douglasmiller))
- Adding changelog and updated release scripts [\#494](https://github.com/recurly/recurly-client-dotnet/pull/494) ([douglasmiller](https://github.com/douglasmiller))
- Fri Mar 20 17:39:58 UTC 2020 Upgrade API version v2019-10-10 [\#493](https://github.com/recurly/recurly-client-dotnet/pull/493) ([douglasmiller](https://github.com/douglasmiller))
- Add request for stack trace in issue report [\#487](https://github.com/recurly/recurly-client-dotnet/pull/487) ([bhelx](https://github.com/bhelx))

## [3.4.0](https://github.com/recurly/recurly-client-dotnet/tree/3.4.0) (2020-02-20)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.2.1...3.4.0)

**Merged pull requests:**

- Release 3.4.0 [\#485](https://github.com/recurly/recurly-client-dotnet/pull/485) ([bhelx](https://github.com/bhelx))
- Latest generated changes for v2019-10-10 [\#484](https://github.com/recurly/recurly-client-dotnet/pull/484) ([bhelx](https://github.com/bhelx))
- Fix a DateTime Unit Tests when not in UTC [\#482](https://github.com/recurly/recurly-client-dotnet/pull/482) ([jamesbar2](https://github.com/jamesbar2))
- Latest v2019-10-10 Changes [\#479](https://github.com/recurly/recurly-client-dotnet/pull/479) ([bhelx](https://github.com/bhelx))
- Cleanup unused imports [\#478](https://github.com/recurly/recurly-client-dotnet/pull/478) ([bhelx](https://github.com/bhelx))
- Fixing error factory bug [\#473](https://github.com/recurly/recurly-client-dotnet/pull/473) ([douglasmiller](https://github.com/douglasmiller))
- Initial addition of code to support enum types [\#471](https://github.com/recurly/recurly-client-dotnet/pull/471) ([douglasmiller](https://github.com/douglasmiller))

## [3.2.1](https://github.com/recurly/recurly-client-dotnet/tree/3.2.1) (2019-12-12)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.3.0...3.2.1)

## [3.3.0](https://github.com/recurly/recurly-client-dotnet/tree/3.3.0) (2019-12-12)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.2.0...3.3.0)

**Implemented enhancements:**

- Synchronize latest V3 Changes [\#470](https://github.com/recurly/recurly-client-dotnet/pull/470) ([bhelx](https://github.com/bhelx))

## [3.2.0](https://github.com/recurly/recurly-client-dotnet/tree/3.2.0) (2019-12-03)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.1.1...3.2.0)

**Merged pull requests:**

- Release 3.2.0 [\#469](https://github.com/recurly/recurly-client-dotnet/pull/469) ([bhelx](https://github.com/bhelx))
- Allow object attributes [\#468](https://github.com/recurly/recurly-client-dotnet/pull/468) ([bhelx](https://github.com/bhelx))

## [3.1.1](https://github.com/recurly/recurly-client-dotnet/tree/3.1.1) (2019-11-26)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.1.0...3.1.1)

**Merged pull requests:**

- Release 3.1.1 [\#466](https://github.com/recurly/recurly-client-dotnet/pull/466) ([bhelx](https://github.com/bhelx))
- Properly handle TransactionErrors [\#465](https://github.com/recurly/recurly-client-dotnet/pull/465) ([bhelx](https://github.com/bhelx))

## [3.1.0](https://github.com/recurly/recurly-client-dotnet/tree/3.1.0) (2019-11-18)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0...3.1.0)

**Merged pull requests:**

- Release 3.1.0 [\#460](https://github.com/recurly/recurly-client-dotnet/pull/460) ([bhelx](https://github.com/bhelx))
- Generated Updates for API version v2019-10-10 [\#459](https://github.com/recurly/recurly-client-dotnet/pull/459) ([douglasmiller](https://github.com/douglasmiller))
- Generated Updates for API version v2019-10-10 [\#458](https://github.com/recurly/recurly-client-dotnet/pull/458) ([bhelx](https://github.com/bhelx))

## [3.0.0](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0) (2019-10-07)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.7...3.0.0)

**Merged pull requests:**

- Release 3.0.0 [\#451](https://github.com/recurly/recurly-client-dotnet/pull/451) ([bhelx](https://github.com/bhelx))
- Upgrade API version v2019-10-10 [\#450](https://github.com/recurly/recurly-client-dotnet/pull/450) ([bhelx](https://github.com/bhelx))
- Change base url to v3.recurly.com [\#449](https://github.com/recurly/recurly-client-dotnet/pull/449) ([bhelx](https://github.com/bhelx))
- Properly cast bool params and add tests [\#435](https://github.com/recurly/recurly-client-dotnet/pull/435) ([bhelx](https://github.com/bhelx))

## [3.0.0-beta.7](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0-beta.7) (2019-09-20)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.6...3.0.0-beta.7)

**Merged pull requests:**

- Release 3.0.0-beta.7 [\#447](https://github.com/recurly/recurly-client-dotnet/pull/447) ([bhelx](https://github.com/bhelx))

## [3.0.0-beta.6](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0-beta.6) (2019-09-20)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.5...3.0.0-beta.6)

**Fixed bugs:**

- Fix Pager empty page bug [\#432](https://github.com/recurly/recurly-client-dotnet/pull/432) ([bhelx](https://github.com/bhelx))

**Merged pull requests:**

- 3.0.0-beta.6 Release [\#446](https://github.com/recurly/recurly-client-dotnet/pull/446) ([bhelx](https://github.com/bhelx))
- Implement bump script [\#443](https://github.com/recurly/recurly-client-dotnet/pull/443) ([bhelx](https://github.com/bhelx))
- Remove the site-id constraint from Client [\#440](https://github.com/recurly/recurly-client-dotnet/pull/440) ([bhelx](https://github.com/bhelx))
- Latest v2018-08-09 Updates [\#439](https://github.com/recurly/recurly-client-dotnet/pull/439) ([bhelx](https://github.com/bhelx))
- Document pagination params [\#434](https://github.com/recurly/recurly-client-dotnet/pull/434) ([bhelx](https://github.com/bhelx))
- Add CONTRIBUTING.md [\#430](https://github.com/recurly/recurly-client-dotnet/pull/430) ([bhelx](https://github.com/bhelx))
- Bump 3.0.0-beta.6 [\#429](https://github.com/recurly/recurly-client-dotnet/pull/429) ([bhelx](https://github.com/bhelx))
- Latest v2018-08-09 Changes [\#428](https://github.com/recurly/recurly-client-dotnet/pull/428) ([bhelx](https://github.com/bhelx))

## [3.0.0-beta.5](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0-beta.5) (2019-06-28)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.4...3.0.0-beta.5)

**Merged pull requests:**

- 3.0.0.beta.5 [\#425](https://github.com/recurly/recurly-client-dotnet/pull/425) ([bhelx](https://github.com/bhelx))
- Latest v2018-08-09 Changes [\#424](https://github.com/recurly/recurly-client-dotnet/pull/424) ([bhelx](https://github.com/bhelx))
- Remove dep scripts from readme [\#412](https://github.com/recurly/recurly-client-dotnet/pull/412) ([bhelx](https://github.com/bhelx))
- Update pagination doc [\#410](https://github.com/recurly/recurly-client-dotnet/pull/410) ([bhelx](https://github.com/bhelx))
- Make Error parsing more robust and support STRICT\_MODE [\#407](https://github.com/recurly/recurly-client-dotnet/pull/407) ([bhelx](https://github.com/bhelx))

## [3.0.0-beta.4](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0-beta.4) (2019-06-07)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.3...3.0.0-beta.4)

**Merged pull requests:**

- Bump to 3.0.0-beta.4 [\#409](https://github.com/recurly/recurly-client-dotnet/pull/409) ([bhelx](https://github.com/bhelx))
- Latest v2018-08-09 Updates [\#408](https://github.com/recurly/recurly-client-dotnet/pull/408) ([bhelx](https://github.com/bhelx))
- Implement formatter script [\#406](https://github.com/recurly/recurly-client-dotnet/pull/406) ([bhelx](https://github.com/bhelx))
- No longer need dep scripts [\#405](https://github.com/recurly/recurly-client-dotnet/pull/405) ([bhelx](https://github.com/bhelx))
- Implement pagination params [\#403](https://github.com/recurly/recurly-client-dotnet/pull/403) ([bhelx](https://github.com/bhelx))

## [3.0.0-beta.3](https://github.com/recurly/recurly-client-dotnet/tree/3.0.0-beta.3) (2019-05-22)

[Full Changelog](https://github.com/recurly/recurly-client-dotnet/compare/3.0.0-beta.2...3.0.0-beta.3)

**Merged pull requests:**

- Merge latest 2018-08-09 changes into 3\_0\_0\_beta [\#401](https://github.com/recurly/recurly-client-dotnet/pull/401) ([bhelx](https://github.com/bhelx))
- Dotnet Async Operations [\#392](https://github.com/recurly/recurly-client-dotnet/pull/392) ([bhelx](https://github.com/bhelx))
- Allow targeting individual exceptions [\#391](https://github.com/recurly/recurly-client-dotnet/pull/391) ([bhelx](https://github.com/bhelx))
- Allow configurable api url [\#390](https://github.com/recurly/recurly-client-dotnet/pull/390) ([bhelx](https://github.com/bhelx))



\* *This Changelog was automatically generated by [github_changelog_generator](https://github.com/github-changelog-generator/github-changelog-generator)*
