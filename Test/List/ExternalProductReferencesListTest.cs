using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalProductReferencesListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListExternalProductReferences()
        {
            var externalProduct = new ExternalProduct();
            externalProduct.Name = "External Product with references";
            externalProduct.ExternalProductReferenceList = new List<ExternalProductReference>
                {
                    new ExternalProductReference()
                    {
                        ReferenceCode = "abc-123",
                        ExternalConnectionType = "google_play_store"
                    }
                };
            externalProduct.Create();
            var externalProductReferences = externalProduct.GetExternalProductReferences();
            externalProductReferences.Should().NotBeEmpty();

            externalProduct.Delete();
        }
    }
}
