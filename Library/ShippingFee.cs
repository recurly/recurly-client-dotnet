using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class ShippingFee : RecurlyEntity, IShippingFee
    {
        public string ShippingMethodCode { get; set; }
        public int? ShippingAmountInCents { get; set; }
        private IShippingAddress _shippingAddress;

        public IShippingAddress ShippingAddress
        {
            get { return _shippingAddress; }
            set
            {
                if (value.Id.HasValue)
                {
                    ShippingAddressId = value.Id.Value;
                }
                _shippingAddress = value;
            }
        }

        public long? ShippingAddressId { get; set; }

        #region Constructors

        public ShippingFee()
        {
        }

        internal ShippingFee(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new NotImplementedException();
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter, this);
        }

        internal void WriteEmbeddedXml(XmlTextWriter xmlWriter)
        {
            WriteEmbeddedXml(xmlWriter, this);
        }

        internal static void WriteXml(XmlTextWriter xmlWriter, IShippingFee shippingFee)
        {
            xmlWriter.WriteStartElement("shipping_fee"); // Start: shipping_fee

            xmlWriter.WriteElementString("shipping_method_code", shippingFee.ShippingMethodCode);

            if (shippingFee.ShippingAmountInCents.HasValue)
                xmlWriter.WriteElementString("shipping_amount_in_cents", shippingFee.ShippingAmountInCents.Value.AsString());

            if (shippingFee.ShippingAddressId.HasValue)
            {
                xmlWriter.WriteElementString("shipping_address_id", shippingFee.ShippingAddressId.Value.ToString());
            }
            else if (shippingFee.ShippingAddress != null)
            {
                Recurly.ShippingAddress.WriteXml(xmlWriter, shippingFee.ShippingAddress);
            }

            xmlWriter.WriteEndElement(); // End: shipping_fee
        }

        internal static void WriteEmbeddedXml(XmlTextWriter xmlWriter, IShippingFee shippingFee)
        {
            WriteXml(xmlWriter, shippingFee);
        }
        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Shipping Fee: " + ShippingMethodCode + " " + ShippingAmountInCents;
        }

        public override bool Equals(object obj)
        {
            var shippingFee = obj as IShippingFee;
            return shippingFee != null && Equals(shippingFee);
        }

        public bool Equals(IShippingFee shippingFee)
        {
            return ShippingMethodCode == shippingFee.ShippingMethodCode &&
                ShippingAmountInCents == shippingFee.ShippingAmountInCents;
        }

        public override int GetHashCode()
        {
            int? shippingMethodHashCode = ShippingMethodCode?.GetHashCode();
            int? shippingAmountHashCode = ShippingAmountInCents?.GetHashCode();

            if (shippingMethodHashCode != null && shippingAmountHashCode != null)
            {
                return (int) shippingMethodHashCode ^ (int) shippingAmountHashCode;
            }

            return 0;
        }

        #endregion
    }
}
