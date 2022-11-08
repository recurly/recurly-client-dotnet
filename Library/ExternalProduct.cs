using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents external_products for accounts
    /// </summary>
    public class ExternalProduct : RecurlyEntity
    {



        public string Name { get; private set; }
        public string PlanName { get; private set; }
        public string PlanCode { get; private set; }
        public string ExternalObjectReference { get; private set; }
        public List<ExternalProductReference> ExternalProductReferenceList { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/external_products/";

        internal ExternalProduct()
        {
        }

        internal ExternalProduct(XmlTextReader reader)
        {
            ReadXml(reader);
        }


        #region Read and Write XML documents

        internal void ReadExternalResourceXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_resource" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "external_object_reference":
                        ExternalObjectReference = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal void ReadExternalProductReferenceXml(XmlTextReader reader)
        {
            ExternalProductReferenceList = new List<ExternalProductReference>();
            while (reader.Read())
            {
                if (reader.Name == "external_product_references" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_product_reference")
                {
                    var epr = new ExternalProductReference(reader);
                    ExternalProductReferenceList.Add(epr);
                }
            }
        }

        internal void ReadPlanXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "plan" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "plan_code":
                        PlanCode = reader.ReadElementContentAsString();
                        break;
                    case "plan_name":
                        PlanName = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                string href;
                DateTime dateVal;

                if (reader.Name == "external_product" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "plan":
                        ReadPlanXml(reader);
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "external_product_references":
                        ReadExternalProductReferenceXml(reader);
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            UpdatedAt = dateVal; ;
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            CreatedAt = dateVal; ;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public sealed class ExternalProducts
    {
        /// <summary>
        /// Returns a list of recurly external_products
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<ExternalProduct> List()
        {
            return List(null);
        }

        /// <summary>
        /// Returns a list of recurly external_products
        ///
        /// A external_product will belong to more than one state.
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<ExternalProduct> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            return new ExternalProductList(ExternalProduct.UrlPrefix + "?" + parameters.ToString());
        }

        public static ExternalProduct Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }
            var s = new ExternalProduct();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                ExternalProduct.UrlPrefix + Uri.EscapeDataString(uuid),
                s.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : s;
        }
    }
}
