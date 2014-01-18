using System;
using System.Diagnostics;
using System.Net;
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

        internal BillingInfo(string accountCode)
            : this()
        {
            AccountCode = accountCode;
        }

        public BillingInfo(Account account)
            : this()
        {
            AccountCode = account.AccountCode;
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
            var billingInfo = new BillingInfo();

            var statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                BillingInfoUrl(accountCode),
                billingInfo.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : billingInfo;
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
                BillingInfoUrl(AccountCode),
                WriteXml,
                ReadXml);
        }

        private static string BillingInfoUrl(string accountCode)
        {
            return UrlPrefix + Uri.EscapeUriString(accountCode) + UrlPostfix;
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of billing_info element, get out of here
                if (reader.Name == "billing_info" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "account":
                        var href = reader.GetAttribute("href");
                        AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "first_name":
                        FirstName = reader.ReadElementContentAsString();
                        break;

                    case "last_name":
                        LastName = reader.ReadElementContentAsString();
                        break;

                    case "company":
                        Company = reader.ReadElementContentAsString();
                        break;

                    case "address1":
                        Address1 = reader.ReadElementContentAsString();
                        break;

                    case "address2":
                        Address2 = reader.ReadElementContentAsString();
                        break;

                    case "city":
                        City = reader.ReadElementContentAsString();
                        break;

                    case "state":
                        State = reader.ReadElementContentAsString();
                        break;

                    case "zip":
                        PostalCode = reader.ReadElementContentAsString();
                        break;

                    case "country":
                        Country = reader.ReadElementContentAsString();
                        break;

                    case "phone":
                        PhoneNumber = reader.ReadElementContentAsString();
                        break;

                    case "vat_number":
                        VatNumber = reader.ReadElementContentAsString();
                        break;

                    case "ip_address":
                        IpAddress = reader.ReadElementContentAsString();
                        break;

                    case "ip_address_country":
                        IpAddressCountry = reader.ReadElementContentAsString();
                        break;

                    case "card_type":
                        CardType = (CreditCardType)Enum.Parse(typeof(CreditCardType), reader.ReadElementContentAsString(), true);
                        break;

                    case "year":
                        ExpirationYear = reader.ReadElementContentAsInt();
                        break;
                            
                    case "month":
                        ExpirationMonth = reader.ReadElementContentAsInt();
                        break;

                    case "first_six":
                        FirstSix = reader.ReadElementContentAsString();
                        break;

                    case "last_four":
                        LastFour = reader.ReadElementContentAsString();
                        break;

                    case "billing_agreement_id":
                        BillingAgreementId = reader.ReadElementContentAsString();
                        break;
                       
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("billing_info"); // Start: billing_info
            xmlWriter.WriteStringIfValid("first_name", FirstName);
            xmlWriter.WriteStringIfValid("last_name", LastName);
            xmlWriter.WriteStringIfValid("address1", Address1);
            xmlWriter.WriteStringIfValid("address2", Address2);
            xmlWriter.WriteStringIfValid("city", City);
            xmlWriter.WriteStringIfValid("state", State);
            xmlWriter.WriteStringIfValid("zip", PostalCode);
            xmlWriter.WriteStringIfValid("country", Country);
            xmlWriter.WriteStringIfValid("phone", PhoneNumber);

            xmlWriter.WriteStringIfValid("vat_number", VatNumber);

            if (!string.IsNullOrEmpty(IpAddress))
                xmlWriter.WriteElementString("ip_address", IpAddress);
            else
                Debug.WriteLine("Recurly Client Library: Recording IP Address is strongly recommended.");

            if (!string.IsNullOrEmpty(CreditCardNumber))
            {
                xmlWriter.WriteElementString("number", CreditCardNumber);
                xmlWriter.WriteElementString("month", ExpirationMonth.AsString());
                xmlWriter.WriteElementString("year", ExpirationYear.AsString());

                xmlWriter.WriteStringIfValid("verification_value", VerificationValue);
            }


            xmlWriter.WriteEndElement(); // End: billing_info
        }


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Billing Info : " + AccountCode;
        }

        public override bool Equals(object obj)
        {
            var a = obj as BillingInfo;
            return a != null && Equals(a);
        }

        public bool Equals(BillingInfo billingInfo)
        {
            return AccountCode == billingInfo.AccountCode;
        }

        public override int GetHashCode()
        {
            return AccountCode.GetHashCode();
        }

        #endregion
    }
}
