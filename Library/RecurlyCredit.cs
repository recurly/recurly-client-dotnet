using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyCredit : Adjustment
    {
        private const string UrlPostfix = "/credits";

        #region Constructors

        internal RecurlyCredit()
        {
        }

        internal RecurlyCredit(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        public static RecurlyCredit CreditAccount(string accountCode, int amountInCents, string description)
        {
            return CreditAccount(accountCode, amountInCents, 1, description);
        }

        public static RecurlyCredit CreditAccount(string accountCode, int amountInCents, int quantity, string description)
        {
            RecurlyCredit credit = new RecurlyCredit();
            credit.AmountInCents = amountInCents;
            credit.Quantity = quantity;
            credit.StartDate = DateTime.UtcNow;
            credit.Description = description;

            /* HttpStatusCode statusCode = */
            Client.PerformRequest(Client.HttpRequestMethod.Post,
                CreditsUrl(accountCode),
                new Client.WriteXmlDelegate(credit.WriteXml),
                null);

            return credit;
        }

        internal static string CreditsUrl(string accountCode)
        {
            return Account.UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
        }


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Credit: " + this.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyCredit)
                return Equals((RecurlyCredit)obj);
            else
                return false;
        }

        public bool Equals(RecurlyCredit credit)
        {
            return this.Id == credit.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
