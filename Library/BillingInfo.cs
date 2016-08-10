﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class BillingInfo : RecurlyEntity
    {
        public enum CreditCardType : short
        {
            Invalid,
            Visa,
            MasterCard,
            AmericanExpress,
            Discover,
            JCB,
            DinersClub
        }

        public enum BankAccountType : short
        {
            Checking,
            Savings
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
        /// Used to override default currency
        /// setting this to a known value may save you a verification
        /// </summary>
        public string Currency { get; set; }

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

        public string NameOnAccount { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountType AccountType { get; set; }

        public string Company { get; set; }

        /// <summary>
        /// Paypal Billing Agreement ID
        /// </summary>
        public string PaypalBillingAgreementId { get; set; }

        /// <summary>
        /// Amazon Billing Agreement ID
        /// </summary>
        public string AmazonBillingAgreementId { get; set; }

        private string _cardNumber;

        /// <summary>
        /// Credit card number
        /// </summary>
        public string CreditCardNumber
        {
            get { return _cardNumber; }
            set
            {
                _cardNumber = value;
                CreditCardType type;
                if (value.IsValidCreditCardNumber(out type))
                {
                    var digits = value.Where(char.IsDigit).AsString();
                    CardType = type;
                    FirstSix = digits.Substring(0, 6);
                    LastFour = digits.Last(4);
                }
                else
                {
                    CardType = CreditCardType.Invalid;
                    FirstSix = LastFour = null;
                }
            }
        }

        public string VerificationValue { get; set; }

        public string TokenId { get; set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/billing_info";

        internal BillingInfo(string accountCode) : this()
        {
            AccountCode = accountCode;
        }

        public BillingInfo(Account account) : this()
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

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
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
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                BillingInfoUrl(AccountCode),
                WriteXml,
                ReadXml);
        }

        private static string BillingInfoUrl(string accountCode)
        {
            return UrlPrefix + Uri.EscapeUriString(accountCode) + UrlPostfix;
        }

        internal override void ReadXml(XmlTextReader reader)
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

                    case "name_on_account":
                        NameOnAccount = reader.ReadElementContentAsString();
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
                        CardType = reader.ReadElementContentAsString().ParseAsEnum<CreditCardType>();
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

                    case "paypal_billing_agreement_id":
                        PaypalBillingAgreementId = reader.ReadElementContentAsString();
                        break;

                    case "amazon_billing_agreement_id":
                        AmazonBillingAgreementId = reader.ReadElementContentAsString();
                        break;

                    case "routing_number":
                        RoutingNumber = reader.ReadElementContentAsString();
                        break;

                    case "account_type":
                        AccountType = reader.ReadElementContentAsString().ParseAsEnum<BankAccountType>();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("billing_info"); // Start: billing_info

            //if a recurly js token is supplied we don't want to send billing info here
            if (string.IsNullOrEmpty(TokenId))
            {
                xmlWriter.WriteStringIfValid("first_name", FirstName);
                xmlWriter.WriteStringIfValid("last_name", LastName);
                xmlWriter.WriteStringIfValid("name_on_account", NameOnAccount);
                xmlWriter.WriteStringIfValid("address1", Address1);
                xmlWriter.WriteStringIfValid("address2", Address2);
                xmlWriter.WriteStringIfValid("city", City);
                xmlWriter.WriteStringIfValid("state", State);
                xmlWriter.WriteStringIfValid("zip", PostalCode);
                xmlWriter.WriteStringIfValid("country", Country);
                xmlWriter.WriteStringIfValid("phone", PhoneNumber);
                xmlWriter.WriteStringIfValid("vat_number", VatNumber);
                xmlWriter.WriteStringIfValid("currency", Currency);

                if (!IpAddress.IsNullOrEmpty())
                    xmlWriter.WriteElementString("ip_address", IpAddress);
                else
                    Debug.WriteLine("Recurly Client Library: Recording IP Address is strongly recommended.");

                if (!CreditCardNumber.IsNullOrEmpty())
                {
                    xmlWriter.WriteElementString("number", CreditCardNumber);
                    xmlWriter.WriteElementString("month", ExpirationMonth.AsString());
                    xmlWriter.WriteElementString("year", ExpirationYear.AsString());

                    xmlWriter.WriteStringIfValid("verification_value", VerificationValue);
                }

                if (!AccountNumber.IsNullOrEmpty())
                {
                    xmlWriter.WriteElementString("routing_number", RoutingNumber);
                    xmlWriter.WriteElementString("account_number", AccountNumber);
                    xmlWriter.WriteElementString("account_type", AccountType.ToString().EnumNameToTransportCase());
                }
            }

            xmlWriter.WriteStringIfValid("token_id", TokenId);

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
