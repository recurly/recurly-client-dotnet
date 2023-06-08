using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    /// <summary>
    /// Represents a business entity associated with a Recurly site
    /// </summary>
    public class BusinessEntity : RecurlyEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public InvoiceDisplayAddress InvoiceDisplayAddress { get; set; }
        public TaxAddress TaxAddress { get; set; }
        public string DefaultVatNumber { get; set; }
        public string DefaultRegistrationNumber { get; set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private List<string> _subscriberLocationCountries;
        public List<string> SubscriberLocationCountries
        {
            get { return _subscriberLocationCountries ?? (_subscriberLocationCountries = new List<string>()); }
            set { _subscriberLocationCountries = value; }
        }

        /// <summary>
        /// Returns a list of invoices for this business entity
        /// </summary>
        /// <returns></returns>
        public RecurlyList<Invoice> GetInvoices()
        {
            return new InvoiceList(BusinessEntity.UrlPrefix + Uri.EscapeDataString(Id) + "/invoices");
        }

        public BusinessEntity() { }

        internal BusinessEntity(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal const string UrlPrefix = "/business_entities/";

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "business_entity" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element)
                    continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;
                    case "code":
                        Code = reader.ReadElementContentAsString();
                        break;
                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;
                    case "invoice_display_address":
                        InvoiceDisplayAddress = new InvoiceDisplayAddress(reader);
                        break;
                    case "tax_address":
                        TaxAddress = new TaxAddress(reader);
                        break;
                    case "subscriber_location_countries":
                        while (reader.Read())
                        {
                            if (reader.Name == "subscriber_location_countries" && reader.NodeType == XmlNodeType.EndElement)
                                break;

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "subscriber_location_country")
                                SubscriberLocationCountries.Add(reader.ReadElementContentAsString());
                        }
                        break;
                    case "default_vat_number":
                        DefaultVatNumber = reader.ReadElementContentAsString();
                        break;
                    case "default_registration_number":
                        DefaultRegistrationNumber = reader.ReadElementContentAsString();
                        break;
                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;
                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class BusinessEntities
    {
        /// <summary>
        /// Returns a list of recurly business_entities
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<BusinessEntity> List()
        {
            return List(null);
        }

        /// <summary>
        /// Returns a list of recurly business_entities
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<BusinessEntity> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();

            return new BusinessEntityList(BusinessEntity.UrlPrefix + "?" + parameters.ToString());
        }

        /// <summary>
        /// Returns a recurly business_entity
        /// </summary>
        /// <param name="uuid">The uuid of the business entity to fetch</param>
        /// <returns></returns>
        public static BusinessEntity Get(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid))
            {
                return null;
            }

            var businessEntity = new BusinessEntity();
            var statusCode = Client.Instance.PerformRequest(
                Client.HttpRequestMethod.Get,
                BusinessEntity.UrlPrefix + Uri.EscapeDataString(uuid),
                businessEntity.ReadXml
            );

            return statusCode == HttpStatusCode.NotFound ? null : businessEntity;
        }
    }
}
