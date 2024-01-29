# Contributing

## Adding a new entity

If you are adding a new entity, it is usually easier to begin with an existing entity and modify it to suit your needs. Choose a "fully-featured" entity (i.e. all CRUD operations, including a `*List` class) to start as it will be easier to delete methods rather than add methods manually. As you edit, keep the following in mind:

- If a class member shouldn't be fully accessible (i.e. `public`), then specify the access modifier (i.e. `protected` or `private`) and specify the getter/setter as appropriate (e.g. `public string FirstName { get; private set; }` restricts the value to be set internally, such as when the response XML is parsed).
- If properties can be set on create but remain readonly afterward, you will likely need another `WriteXml()` method (e.g. `WriteUpdateXml()`) that you will then need to reference in your `Update()` method.
- Decide the flexibility of multiple constructors. _Every_ entity should have the empty constructor, but you may want to add additional constructors for convenience. For example, `public Account(string accountCode)` is useful for fetching an account from the API, but `public Account(string firstName, string lastName)` is not useful because you can't create an account without an account code.

### Lists

If your entity supports an index/list endpoint, then you need to create an additional model in the `Library/List/` folder. Again, it is easier to copy/paste from an existing list and modify it to suit your needs. If your endpoint supports pagination, then ensure all of the pagination methods, along with constructors that accept `filterCriteria`, are included in your new model. Additionally, if your endpoint supports filtering with custom query params, you will likely want to define an additional constructor (or two if you want the option to omit the pagination `filterCriteria`).


## Updating an existing entity

If you are updating an existing entity, the process is less intensive. Generally, you will need to add the new class member(s) to the model and modify your `ReadXml()`/`WriteXml()` methods to read/write the new fields, respectively.


## Testing

### Unit tests

You should always strive to write unit tests for your changes. If you are adding a new entity, you should use a fixture in your unit tests to ensure that the XML parsing is correct. There are a lot of tests that are actually calling out to a site in production, but that pattern should be reversed for obvious reasons.

To add your new unit test and fixture:

1. Add your fixture(s) in `Test/Fixtures/<my_new_features>`. This usually includes at least a `show-200.xml` and `index-200.xml` file.
2. Register the fixtures within the appropriate item group in `Test/Recurly.Test.csproj`.
3. Make the code aware of the new fixture(s) by registering your feature in `Test/Fixtures/FixtureImporter.cs`. Follow the existing pattern for already-registered fixtures.
4. In your unit test, load the fixture into your model to test the XML parsing (e.g. for a "get one" endpoint):
```csharp
var myFeature = new MyFeature();

var xmlFixture = FixtureImporter.Get(FixtureType.MyFeature, "show-200").Xml;
XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlFixture));
myFeature.ReadXml(reader);

myFeature.Id.Should().Be("abc123");
```
