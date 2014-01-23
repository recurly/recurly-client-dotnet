using System;
using System.Net;
using System.Xml;

namespace Recurly
{
    public class Transaction
    {

        // The currently valid Transaction States
        public enum TransactionState : short
        {
            All = 0,
            Unknown,
            Success,
            Failed,
            Voided,
            Declined
        }

        public enum TransactionType : short
        {
            All = 0,
            Unknown,
            Authorization,
            Purchase,
            Refund,
            Verify
        }


        public string Uuid { get; private set; }
        public TransactionType Action { get; set; }
        public int AmountInCents { get; set; }
        public int TaxInCents { get; set; }
        public string Currency { get; set; }

        public TransactionState Status { get; private set; }

        public string Reference { get; set; }

        public bool Test { get; private set; }
        public bool Voidable { get; private set; }
        public bool Refundable { get; private set; }

        public string CCVResult { get; private set; }
        public string AvsResult { get; private set; }
        public string AvsResultStreet { get; private set; }
        public string AvsResultPostal { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private Account _account;

        public string AccountCode { get; private set; }

        public Account Account
        {
            get { return _account ?? (_account = Account.Get(AccountCode)); }
            set
            {
                _account = value;
                AccountCode = value.AccountCode;
            }
        }
        public int? Invoice { get; private set; }
       

        internal Transaction()
        { }

        internal Transaction(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amountInCents"></param>
        /// <param name="currency"></param>
        public Transaction(Account account, int amountInCents, string currency)
        {
            Account = account;
            AmountInCents = amountInCents;
            Currency = currency;
        }

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="amountInCents"></param>
        /// <param name="currency"></param>
        public Transaction(string accountCode, int amountInCents, string currency)
        {
            AccountCode = accountCode;
            AmountInCents = amountInCents;
            Currency = currency;
        }


        private const string UrlPrefix = "/transactions/";

        public static Transaction Get(string transactionId)
        {
            var transaction = new Transaction();

            HttpStatusCode statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + Uri.EscapeUriString(transactionId),
                transaction.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : transaction;
        }

        /// <summary>
        /// Creates an invoice, charge, and optionally account
        /// </summary>
        public void Create()
        {
             Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml,
                ReadXml);
        }


        /// <summary>
        /// Refunds a transaction
        /// 
        /// </summary>
        /// <param name="refund">If present, the amount to refund. Otherwise it is a full refund.</param>
        public void Refund(int? refund = null)
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + Uri.EscapeUriString(Uuid) + (refund.HasValue ? "?amount_in_cents=" + refund.Value : ""),
                ReadXml);
        }


        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if ((reader.Name == "transaction") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                string href;
                int amount;
                switch (reader.Name)
                {
                    case "account":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "invoice":
                        href = reader.GetAttribute("href");
                        if (null != href)
                            Invoice = int.Parse(href.Substring(href.LastIndexOf("/") + 1));
                        break;

                    case "uuid":
                        Uuid = reader.ReadElementContentAsString();
                        break;

                    case "action":
                        Action = reader.ReadElementContentAsString().ParseAsEnum<TransactionType>();
                        break;

                    case "amount_in_cents":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                            AmountInCents = amount;
                        break;

                    case "tax_in_cents":
                        if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                            AmountInCents = amount;
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "status":
                        var state = reader.ReadElementContentAsString();
                        Status = "void" == state ? TransactionState.Voided : state.ParseAsEnum<TransactionState>();
                        break;

                    case "reference":
                        Reference = reader.ReadElementContentAsString();
                        break;

                    case "test":
                        Test = reader.ReadElementContentAsBoolean();
                        break;

                    case "voidable":
                        Voidable =  reader.ReadElementContentAsBoolean();
                        break;

                    case "refundable":
                        Refundable =  reader.ReadElementContentAsBoolean();
                        break;

                    case "ccv_result":
                        CCVResult = reader.ReadElementContentAsString();
                        break;

                    case "avs_result":
                        AvsResult = reader.ReadElementContentAsString();
                        break;

                    case "avs_result_street":
                        AvsResultStreet = reader.ReadElementContentAsString();
                        break;

                    case "avs_result_postal":
                        AvsResultPostal = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        DateTime date;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                            CreatedAt = date;
                        break;

                       
                    case "details":
                        // API docs say not to load details into objects
                        break;

                        
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("transaction");

            xmlWriter.WriteElementString("amount_in_cents", AmountInCents.ToString());
            xmlWriter.WriteElementString("currency", Currency);


            if (Account != null)
            {
                Account.WriteXml(xmlWriter);
            }
            xmlWriter.WriteEndElement(); 
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Transaction: " + Uuid;
        }

        public override bool Equals(object obj)
        {
            var transaction = obj as Transaction;
            return transaction != null && Equals(transaction);
        }

        public bool Equals(Transaction transaction)
        {
            return Uuid == transaction.Uuid;
        }

        public override int GetHashCode()
        {
            return Uuid.GetHashCode();
        }

        #endregion
    }
}
