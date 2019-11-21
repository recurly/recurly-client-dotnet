using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;


namespace Recurly.Test
{
  public class ItemTest : BaseTest
  {
    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void LookupItem()
    {
      var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
      item.Description = "A test description";
      item.Create();

      item.CreatedAt.Should().NotBe(default(DateTime));
      item.Description.Should().Be("A test description");
    }

    public void UpdateItem()
    {
      var customFields = new List<CustomField>();
      customFields.Add(new CustomField("size", "medium"));

      var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
      item.Description = "A test description";
      item.Create();

      item.CustomFields = customFields;

      item.Update();

      // item = Items.Get(item.ItemCode);
      Assert.Equal(item.CustomFields, customFields);
      Assert.Equal(item.CustomFields[0].Name, "size");
      Assert.Equal(item.CustomFields[0].Value, "medium");
    }

    public void DeactivateItem()
    {
      var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
      item.Description = "A test description";
      item.Create();
      item.Deactivate();

      Action get = () => Items.Get(item.ItemCode);
      get.ShouldThrow<NotFoundException>();
    }

  }

}
