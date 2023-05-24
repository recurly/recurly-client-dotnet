using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class ExternalProductReferenceTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void CreateExternalProductReference()
        {
            var externalProduct = new ExternalProduct();
            externalProduct.Name = "External Product!";
            externalProduct.Create();

            var externalProductReference = new ExternalProductReference();
            externalProductReference.ReferenceCode = "External Product Reference!";
            externalProductReference.ExternalConnectionType = "google_play_store";
            externalProduct.CreateExternalProductReference(externalProductReference);
            externalProduct.Delete();
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void DeleteExternalProductReference()
        {
            var externalProduct = new ExternalProduct();
            externalProduct.Name = "External Product with references!";
            externalProduct.ExternalProductReferenceList = new List<ExternalProductReference>
                {
                    new ExternalProductReference()
                    {
                        ReferenceCode = "qwerty-123",
                        ExternalConnectionType = "google_play_store"
                    }
                };
            externalProduct.Create();

            var externalProductReference = externalProduct.GetExternalProductReferences()[0];
            externalProduct.DeleteExternalProductReference(externalProductReference.Id);
            externalProduct.Delete();
        }
    }
}
