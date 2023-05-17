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
        public string Id { get; private set; }
        private Plan _plan;
        public Plan Plan
        {
            get { return _plan ?? (_plan = Plans.Get(PlanCode)); }
            set
            {
                _plan = value;
                PlanCode = value.PlanCode;
            }
        }
        public string PlanCode { get; set; }
        public string Name { get; set; }
        public string ExternalObjectReference { get; private set; }
        public List<ExternalProductReference> ExternalProductReferenceList { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/external_products/";

        public ExternalProduct()
        {
        }

        internal ExternalProduct(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Create a new external product in Recurly
        /// </summary>
        public void Create()
        {
            // POST /external_products
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post, UrlPrefix, WriteXml, ReadXml);
        }

        /// <summary>
        /// Update an existing external product in Recurly
        /// </summary>
        public void Update()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Id),
                WriteUpdateXml);
        }

        /// <summary>
        /// Deletes this external product, making it inactive
        /// </summary>
        public void Delete()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete, UrlPrefix + Uri.EscapeDataString(Id));
        }

        #region External Product References

        /// <summary>
        /// Returns a specific external_product_reference for this account
        /// <param name="id"></param>
        /// </summary>
        /// <returns>ExternalProductReference object</returns>
        public ExternalProductReference GetExternalProductReference(string id)
        {
            if (id == null)
                return null;

            var externalProductReference = new ExternalProductReference();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeDataString(Id) + "/external_product_references/" + id,
                externalProductReference.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : externalProductReference;
        }

        /// <summary>
        /// Returns a list of external_product_reference for this account
        /// </summary>
        /// <returns>ExternalProductReference list</returns>
        public RecurlyList<ExternalProductReference> GetExternalProductReferences()
        {
            return new ExternalProductReferenceList(ExternalProduct.UrlPrefix + Uri.EscapeDataString(Id) + "/external_product_references");
        }

        /// <summary>
        /// Create an external_product_reference
        /// </summary>
        /// <param name="externalProductReference"></param>
        /// <returns>ExternalProductReference object</returns>
        public ExternalProductReference CreateExternalProductReference(ExternalProductReference externalProductReference)
        {
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix + Uri.EscapeDataString(Id) + "/external_product_references/",
                externalProductReference.WriteXml,
                externalProductReference.ReadXml);

            return statusCode == HttpStatusCode.Created ? externalProductReference : null;
        }


        /// <summary>
        /// Deletes an external_product_reference
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteExternalProductReference(string id)
        {
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeDataString(Id) + "/external_product_references/" + id);
        }

        #endregion

        #region Read and Write XML documents

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
                }
            }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                DateTime dateVal;

                if (reader.Name == "external_product" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;

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

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, "external_product");
        }

        internal void WriteXml(XmlTextWriter xmlWriter, string xmlName)
        {
            xmlWriter.WriteStartElement(xmlName); // Start: external_product

            xmlWriter.WriteElementString("plan_code", PlanCode);
            xmlWriter.WriteStringIfValid("name", Name);
            xmlWriter.WriteIfCollectionHasAny("external_product_references", ExternalProductReferenceList);
            xmlWriter.WriteEndElement(); // End: external_product
        }

        internal void WriteUpdateXml(XmlTextWriter xmlWriter)
        {
            WriteUpdateXml(xmlWriter, "external_product");
        }

        internal void WriteUpdateXml(XmlTextWriter xmlWriter, string xmlName)
        {
            xmlWriter.WriteStartElement(xmlName); // Start: external_product

            xmlWriter.WriteElementString("plan_code", PlanCode);
            xmlWriter.WriteEndElement(); // End: external_product
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
