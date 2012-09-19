using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    public class Transaction
    {

        // The currently valid Transaction States
        public enum TransactionState : short
        {
            all = 0,
            unknown,
            success,
            failed,
            voided,
            declined
        }

        public enum TransactionType : short
        {
            all = 0,
            unknown,
            authorization,
            purchase,
            refund
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
            get
            {
                if (null == _account)
                {
                    _account = Account.Get(this.AccountCode);
                }

                return _account;
            }
            set
            {
                _account = value;
                this.AccountCode = value.AccountCode;
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
            this.Account = account;
            this.AmountInCents = amountInCents;
            this.Currency = currency;
        }

        /// <summary>
        /// Creates a new transaction
        /// </summary>
        /// <param name="accountCode"></param>
        /// <param name="amountInCents"></param>
        /// <param name="currency"></param>
        public Transaction(string accountCode, int amountInCents, string currency)
        {
            this.AccountCode = accountCode;
            this.AmountInCents = amountInCents;
            this.Currency = currency;
        }


        private const string UrlPrefix = "/transactions/";

        public static Transaction Get(string transactionId)
        {
            Transaction transaction = new Transaction();

            HttpStatusCode statusCode = Client.PerformRequest(Client.HttpRequestMethod.Get,
                UrlPrefix + System.Uri.EscapeUriString(transactionId),
                new Client.ReadXmlDelegate(transaction.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return transaction;
        }

        /// <summary>
        /// Creates an invoice, charge, and optionally account
        /// </summary>
        public void Create()
        {
             Client.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                new Client.WriteXmlDelegate(this.WriteXml),
                new Client.ReadXmlDelegate(this.ReadXml));
        }


        /// <summary>
        /// Refunds a transaction
        /// 
        /// </summary>
        /// <param name="refund">If present, the amount to refund. Otherwise it is a full refund.</param>
        public void Refund(int? refund = null)
        {
            Client.PerformRequest(Client.HttpRequestMethod.Delete,
                UrlPrefix + System.Uri.EscapeUriString(this.Uuid)
                + (refund.HasValue ? "?amount_in_cents=" + refund.Value.ToString() : "")
                , new Client.ReadXmlDelegate(this.ReadXml));
        }


        #region Read and Write XML documents

        internal void ReadXml(XmlTextReader reader)
        {
            string href;
            int amount;
            while (reader.Read())
            {
                // End of account element, get out of here
                if ((reader.Name == "transaction") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                   
                    switch (reader.Name)
                    {
                        case "account":
                            href = reader.GetAttribute("href");
                            if (null != href)
                                this.AccountCode = Uri.UnescapeDataString(href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "invoice":
                            href = reader.GetAttribute("href");
                            if (null != href)
                                this.Invoice = int.Parse(href.Substring(href.LastIndexOf("/") + 1));
                            break;

                        case "uuid":
                            this.Uuid = reader.ReadElementContentAsString();
                            break;

                        case "action":
                            this.Action = (TransactionType)Enum.Parse(typeof(TransactionType), reader.ReadElementContentAsString(), true);
                            break;

                        case "amount_in_cents":
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                                this.AmountInCents = amount;
                            break;

                        case "tax_in_cents":
                            if (Int32.TryParse(reader.ReadElementContentAsString(), out amount))
                                this.AmountInCents = amount;
                            break;

                        case "currency":
                            this.Currency = reader.ReadElementContentAsString();
                            break;

                        case "status":
                            string state = reader.ReadElementContentAsString();
                            if ("void" == state)
                                this.Status = TransactionState.voided;
                            else
                                this.Status = (TransactionState)Enum.Parse(typeof(TransactionState),state , true);
                            break;

                        case "reference":
                            this.Reference = reader.ReadElementContentAsString();
                            break;

                        case "test":
                            this.Test = reader.ReadElementContentAsBoolean();
                            break;

                        case "voidable":
                            this.Voidable =  reader.ReadElementContentAsBoolean();
                            break;

                        case "refundable":
                            this.Refundable =  reader.ReadElementContentAsBoolean();
                            break;

                        case "ccv_result":
                            this.CCVResult = reader.ReadElementContentAsString();
                            break;

                        case "avs_result":
                            this.AvsResult = reader.ReadElementContentAsString();
                            break;

                        case "avs_result_street":
                            this.AvsResultStreet = reader.ReadElementContentAsString();
                            break;

                        case "avs_result_postal":
                            this.AvsResultPostal = reader.ReadElementContentAsString();
                            break;

                        case "created_at":
                            DateTime date;
                            if (DateTime.TryParse(reader.ReadElementContentAsString(), out date))
                                this.CreatedAt = date;
                            break;

                       
                        case "details":
                            // API docs say not to load details into objects
                            break;

                        
                    }
                }
            }
        }

        internal void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("transaction");

            xmlWriter.WriteElementString("amount_in_cents", this.AmountInCents.ToString());
            xmlWriter.WriteElementString("currency", this.Currency);


            if (this.Account != null)
            {
                this.Account.WriteXml(xmlWriter);
            }
            xmlWriter.WriteEndElement(); 
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Transaction: " + this.Uuid;
        }

        public override bool Equals(object obj)
        {
            if (obj is Transaction)
                return Equals((Transaction)obj);
            else
                return false;
        }

        public bool Equals(Transaction transaction)
        {
            return this.Uuid == transaction.Uuid;
        }

        public override int GetHashCode()
        {
            return this.Uuid.GetHashCode();
        }

        #endregion
    }
}
