using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class RecurlyTransaction : RecurlyClient
    {
        public string Id { get; private set; }
        public int AmountInCents { get; private set; }
        public DateTime Date { get; private set; }
        

        private const string UrlPrefix = "/transactions/";

        public static RecurlyTransaction Get(string transactionId)
        {
            RecurlyTransaction transaction = new RecurlyTransaction();

            HttpStatusCode statusCode = PerformRequest(HttpRequestMethod.Get,
                UrlPrefix + System.Web.HttpUtility.UrlEncode(transactionId),
                new ReadXmlDelegate(transaction.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return transaction;
        }

        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if (reader.Name == "transaction" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "id":
                            this.Id = reader.ReadElementContentAsString();
                            break;

                        case "date":
                            DateTime date;
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.Date = date;
                            break;

                        case "amount_in_cents":
                            int amount;
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                                this.AmountInCents = amount;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Transaction: " + this.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecurlyTransaction)
                return Equals((RecurlyTransaction)obj);
            else
                return false;
        }

        public bool Equals(RecurlyTransaction transaction)
        {
            return this.Id == transaction.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
