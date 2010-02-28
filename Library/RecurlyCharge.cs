using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyCharge : RecurlyLineItem
    {
        private const string UrlPostfix = "/charges";

        #region Constructors

        internal RecurlyCharge()
        {
        }

        internal RecurlyCharge(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        #endregion

        public static RecurlyCharge ChargeAccount(string accountCode, int amountInCents, string description)
        {
            RecurlyCharge charge = new RecurlyCharge();
            charge.AmountInCents = amountInCents;
            charge.StartDate = DateTime.UtcNow;
            charge.Description = description;

            /* HttpStatusCode statusCode = */
            RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Post,
                ChargesUrl(accountCode),
                new RecurlyClient.WriteXmlDelegate(charge.WriteXml),
                null);

            return charge;
        }

        internal static string ChargesUrl(string accountCode)
        {
            return RecurlyAccount.UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
        }

        #region Read and Write XML documents

        /// <summary>
        /// XML root node name. Override for "credit".
        /// </summary>
        protected override string XmlRootNodeName { get { return "charge"; } }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Charge: " + this.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyCharge)
                return Equals((RecurlyCharge)obj);
            else
                return false;
        }

        public bool Equals(RecurlyCharge charge)
        {
            return this.Id == charge.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}