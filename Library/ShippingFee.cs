using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class ShippingFee : RecurlyEntity
    {
        public string ShippingMethodCode { get; set; }
        public int? ShippingAmountInCents { get; set; }
        private ShippingAddress _shippingAddress;

        public ShippingAddress ShippingAddress
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
            xmlWriter.WriteStartElement("shipping_fee"); // Start: shipping_fee

            xmlWriter.WriteElementString("shipping_method_code", ShippingMethodCode);

            if (ShippingAmountInCents.HasValue)
                xmlWriter.WriteElementString("shipping_amount_in_cents", ShippingAmountInCents.Value.AsString());

            if (ShippingAddressId.HasValue)
            {
                xmlWriter.WriteElementString("shipping_address_id", ShippingAddressId.Value.ToString());
            } else if(_shippingAddress != null)
            {
                _shippingAddress.WriteXml(xmlWriter);
            }

            xmlWriter.WriteEndElement(); // End: shipping_fee
        }

        internal void WriteEmbeddedXml(XmlTextWriter xmlWriter)
        {
            WriteXml(xmlWriter);
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Shipping Fee: " + ShippingMethodCode + " " + ShippingAmountInCents;
        }

        public override bool Equals(object obj)
        {
            var shippingFee = obj as ShippingFee;
            return shippingFee != null && Equals(shippingFee);
        }

        public bool Equals(ShippingFee shippingFee)
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
