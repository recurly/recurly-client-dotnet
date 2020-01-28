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

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void UpdateItem()
    {      
      var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
      item.Description = "A test description";
      item.Create();
      item.Description = "A new description";
      item.Update();

      Assert.Equal(item.Description, "A new description");
    }

    [RecurlyFact(TestEnvironment.Type.Integration)]
    public void DeactivateItem()
    {
      var item = new Item(GetMockItemCode(), GetMockItemName()) {Description = "Test Lookup"};
      item.Description = "A test description";

      item.Create();
      item.Deactivate();

      Assert.Equal(item.State, null);
    }
  }
}
