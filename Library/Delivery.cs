using System;
using System.Xml;

namespace Recurly
{
    public class Delivery : RecurlyEntity
    {
        [Flags]
        public enum DeliveryMethod : short
        {
            Email,
            Post
        }

        /// <summary>
        /// The delivery method.
        /// </summary>
        public DeliveryMethod Method { get; set; }

        /// <summary>
        /// The email address of the recipient. Required if method = email.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The first name of the recipient.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the recipient.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The name of the gifter.
        /// </summary>
        public string GifterName { get; set; }

        /// <summary>
        /// The address of the recipient.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// When the gift card should be delivered to the recipient.
        /// If null, the gift card will be delivered immediately.
        /// If a datetime is provided, the delivery will be in an hourly window,
        /// rounding down. For example, 6:23 pm will be in the 6:00 pm hourly batch.
        /// Must be at least an hour in the future and less than a year in the future
        /// </summary>
        public DateTime? DeliverAt { get; set; }

        /// <summary>
        /// The personal message from the gifter to the recipient.
        /// Max 255 characters.
        /// </summary>
        public string PersonalMessage { get; set; }

        public Delivery(DeliveryMethod method)
        {
            Method = method;
        }

        internal Delivery(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "delivery" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                DateTime dateVal;

                switch (reader.Name)
                {                
                    case "email_address":
                        EmailAddress = reader.ReadElementContentAsString();
                        break;

                    case "first_name":
                        FirstName = reader.ReadElementContentAsString();
                        break;

                    case "last_name":
                        LastName = reader.ReadElementContentAsString();
                        break;

                    case "gifter_name":
                        GifterName = reader.ReadElementContentAsString();
                        break;

                    case "deliver_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                            DeliverAt = dateVal;
                        break;
                    
                    case "method":
                        Method = reader.ReadElementContentAsString().ParseAsEnum<DeliveryMethod>();
                        break;

                    case "address":
                        Address = new Address(reader);
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("delivery"); // Start: delivery

            xmlWriter.WriteElementString("method", Method.ToString().EnumNameToTransportCase());
            xmlWriter.WriteStringIfValid("first_name", FirstName);
            xmlWriter.WriteStringIfValid("last_name", LastName);
            xmlWriter.WriteStringIfValid("email_address", EmailAddress);
            xmlWriter.WriteStringIfValid("gifter_name", GifterName);

            if (DeliverAt.HasValue)
                xmlWriter.WriteStringIfValid("deliver_at", DeliverAt.Value.ToString("s"));
            
            if (Address != null)
                Address.WriteXml(xmlWriter);

            xmlWriter.WriteEndElement(); // End: delivery
        }

        #endregion
    }
}
