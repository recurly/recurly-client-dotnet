//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Xml;
//using System.Text;

//namespace Recurly
//{
//    public class RecurlyCharge : Adjustment
//    {
//        private const string UrlPostfix = "/charges";

//        #region Constructors

//        internal RecurlyCharge()
//        {
//        }

//        internal RecurlyCharge(XmlTextReader xmlReader)
//        {
//            ReadXml(xmlReader);
//        }

//        #endregion

//        public static RecurlyCharge ChargeAccount(string accountCode, int amountInCents, string description)
//        {
//            RecurlyCharge charge = new RecurlyCharge();
//            charge.AmountInCents = amountInCents;
//            charge.StartDate = DateTime.UtcNow;
//            charge.Description = description;

//            /* HttpStatusCode statusCode = */
//            Client.PerformRequest(Client.HttpRequestMethod.Post,
//                ChargesUrl(accountCode),
//                new Client.WriteXmlDelegate(charge.WriteXml),
//                null);

//            return charge;
//        }

//        internal static string ChargesUrl(string accountCode)
//        {
//            return Account.UrlPrefix + System.Web.HttpUtility.UrlEncode(accountCode) + UrlPostfix;
//        }

//        #region Read and Write XML documents

       

//        #endregion

//        #region Object Overrides

//        public override string ToString()
//        {
//            return "Recurly Charge: " + this.Id;
//        }

//        public override bool Equals(object obj)
//        {
//            if (obj is RecurlyCharge)
//                return Equals((RecurlyCharge)obj);
//            else
//                return false;
//        }

//        public bool Equals(RecurlyCharge charge)
//        {
//            return this.Id == charge.Id;
//        }

//        public override int GetHashCode()
//        {
//            return this.Id.GetHashCode();
//        }

//        #endregion
//    }
//}
