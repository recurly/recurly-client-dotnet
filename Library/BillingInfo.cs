using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Recurly
{
    public class BillingInfo
    {

        public enum CreditCardType : short
        {
            Visa,
            MasterCard,
            AmericanExpress,
            Discover,
            JCB
        }


        /// <summary>
        /// Account Code or unique ID for the account in Recurly
        /// </summary>
        public string AccountCode { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        /// <summary>
        /// 2-letter state or province preferred
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 2-letter ISO country code
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Zip code or Postal code
        /// </summary>
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// VAT Numbers
        /// </summary>
        public string VatNumber { get; set; }
        public string IpAddress { get; set; }
        public string IpAddressCountry { get; private set; }

        /// <summary>
        /// Credit Card Number, first six digits
        /// </summary>
        public string FirstSix { get; set; }

        /// <summary>
        /// Credit Card Number, last four digits
        /// </summary>
        public string LastFour { get; set; }

        public CreditCardType CardType { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }


        public string Company { get; set; }

        /// <summary>
        /// Paypal Billing Agreement ID
        /// </summary>
        public string BillingAgreementId { get; set; }


        /// <summary>
        /// Credit card number
        /// </summary>
        public string CreditCardNumber { get; set; }
        public string VerificationValue { get; set; }


        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/billing_info";

        public BillingInfo(string accountCode)
            : this()
        {
            this.AccountCode = accountCode;
        }

        public BillingInfo(Account account)
            : this()
        {
            this.AccountCode = account.AccountCode;
        }

        private BillingInfo()
        {
            
        }

        /// <summary>
        /// Lookup a Recurly account's billing info
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static BillingInfo Get(string accountCode)
        {
            BillingInfo billingInfo = new BillingInfo();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                BillingInfoUrl(accountCode),
                new Client.ReadXmlDelegate(billingInfo.ReadXml)).StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return billingInfo;
        }

        /// <summary>
        /// Update an account's billing info in Recurly
        /// </summary>
        public void Create()
        {
            Update();
        }

        /// <summary>
        /// Update an account's billing info in Recurly
        /// </summary>
        public void Update()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Put,
                BillingInfoUrl(this.AccountCode),
                new Client.WriteXmlDelegate(this.WriteXml),
                new Client.ReadXmlDelegate(this.ReadXml));
        }

        /// <summary>
        /// Delete an account's billing info.
        /// </summary>
        public void Delete()
        {
            Client.PerformRequest(Client.HttpRequestMethod.Delete,
                BillingInfoUrl(this.AccountCode));
        }

        private static string BillingInfoUrl(string accountCode)
        {
            return UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of billing_info element, get out of here
                if (reader.Name == "billing_info" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "account":
                            string href = reader.GetAttribute("href");
                            this.AccountCode = href.Substring(href.LastIndexOf("/") + 1);
                            break;

                        case "first_name":
                            this.FirstName = reader.ReadElementContentAsString();
                            break;

                        case "last_name":
                            this.LastName = reader.ReadElementContentAsString();
                            break;

                        case "company":
                            this.Company = reader.ReadElementContentAsString();
                            break;

                        case "address1":
                            this.Address1 = reader.ReadElementContentAsString();
                            break;

                        case "address2":
                            this.Address2 = reader.ReadElementContentAsString();
                            break;

                        case "city":
                            this.City = reader.ReadElementContentAsString();
                            break;

                        case "state":
                            this.State = reader.ReadElementContentAsString();
                            break;

                        case "zip":
                            this.PostalCode = reader.ReadElementContentAsString();
                            break;

                        case "country":
                            this.Country = reader.ReadElementContentAsString();
                            break;

                        case "phone":
                            this.PhoneNumber = reader.ReadElementContentAsString();
                            break;

                        case "vat_number":
                            this.VatNumber = reader.ReadElementContentAsString();
                            break;

                        case "ip_address":
                            this.IpAddress = reader.ReadElementContentAsString();
                            break;

                        case "ip_address_country":
                            this.IpAddressCountry = reader.ReadElementContentAsString();
                            break;

                        case "card_type":
                            this.CardType = (CreditCardType)Enum.Parse(typeof(CreditCardType), reader.ReadElementContentAsString(), true);
                            break;

                        case "year":
                            this.ExpirationYear = reader.ReadElementContentAsInt();
                            break;
                            
                        case "month":
                            this.ExpirationMonth = reader.ReadElementContentAsInt();
                            break;

                        case "first_six":
                            this.FirstSix = reader.ReadElementContentAsString();
                            break;

                        case "last_four":
                            this.LastFour = reader.ReadElementContentAsString();
                            break;

                        case "billing_agreement_id":
                            this.BillingAgreementId = reader.ReadElementContentAsString();
                            break;
                       
                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("billing_info"); // Start: billing_info

            xmlWriter.WriteElementString("first_name", this.FirstName);
            xmlWriter.WriteElementString("last_name", this.LastName);
            xmlWriter.WriteElementString("address1", this.Address1);
            xmlWriter.WriteElementString("address2", this.Address2);
            xmlWriter.WriteElementString("city", this.City);
            xmlWriter.WriteElementString("state", this.State);
            xmlWriter.WriteElementString("zip", this.PostalCode);
            xmlWriter.WriteElementString("country", this.Country);
            xmlWriter.WriteElementString("phone", this.PhoneNumber);

            if (!String.IsNullOrEmpty(this.VatNumber))
                xmlWriter.WriteElementString("vat_number", this.VatNumber);

            if (!String.IsNullOrEmpty(this.IpAddress))
                xmlWriter.WriteElementString("ip_address", this.IpAddress);
            else
                System.Diagnostics.Debug.WriteLine("Recurly Client Library: Recording IP Address is strongly recommended.");

            if (!String.IsNullOrEmpty(this.CreditCardNumber))
            {
                xmlWriter.WriteElementString("number", this.CreditCardNumber);
                xmlWriter.WriteElementString("month", this.ExpirationMonth.ToString());
                xmlWriter.WriteElementString("year", this.ExpirationYear.ToString());

                if (!String.IsNullOrEmpty(this.VerificationValue))
                    xmlWriter.WriteElementString("verification_value", this.VerificationValue);
            }
            

            xmlWriter.WriteEndElement(); // End: billing_info
        }
    }
}
