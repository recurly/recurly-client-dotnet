using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class ShippingMethod : RecurlyEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string AccountingCode { get; set; }
        public string TaxCode { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/shipping_methods/";

        private string memberUrl()
        {
            return UrlPrefix + Code;
        }

        #region Constructors

        internal ShippingMethod()
        {
        }

        internal ShippingMethod(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of shipping_method element, get out of here
                if (reader.Name == "shipping_method" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "code":
                        Code = reader.ReadElementContentAsString();
                        break;

                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;

                    case "accounting_code":
                        AccountingCode = reader.ReadElementContentAsString();
                        break;

                    case "tax_code":
                        TaxCode = reader.ReadElementContentAsString();
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

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("shipping_method"); // Start: shipping_method

            xmlWriter.WriteElementString("code", Code);
            xmlWriter.WriteElementString("name", Name);
            xmlWriter.WriteElementString("accounting_code", AccountingCode);
            xmlWriter.WriteElementString("tax_code", TaxCode);

            xmlWriter.WriteEndElement(); // End: shipping_method
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Shipping Method: " + Code;
        }

        public override bool Equals(object obj)
        {
            var shippingMethod = obj as ShippingMethod;
            return shippingMethod != null && Equals(shippingMethod);
        }

        public bool Equals(ShippingMethod shippingMethod)
        {
            return Code == shippingMethod.Code;
        }

        public override int GetHashCode()
        {
            return Code?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class ShippingMethods
    {
        /// <summary>
        /// Look up a shipping method
        /// </summary>
        /// <param name="shippingMethod">Shipping method code</param>
        /// <returns></returns>
        public static ShippingMethod Get(string Code)
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                return null;
            }

            var shippingMethod = new ShippingMethod();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                ShippingMethod.UrlPrefix + Uri.EscapeDataString(Code),
                shippingMethod.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : shippingMethod;
        }

        /// <summary>
        /// Lists shipping methods
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<ShippingMethod> List()
        {
            return new ShippingMethodList(ShippingMethod.UrlPrefix);
        }

        /// <summary>
        /// Lists shipping methods
        /// </summary>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<ShippingMethod> List(FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();

            return new ShippingMethodList(ShippingMethod.UrlPrefix + "?" + parameters.ToString());
        }
    }
}
