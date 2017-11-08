using System;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;

namespace Recurly
{
    public class Transaction : RecurlyEntity
    {
        // The currently valid Transaction States
        public enum TransactionState : short
        {
            All = 0,
            Unknown,
            Success,
            Failed,
            Voided,
            Declined,
            Scheduled,
            Pending,
            Processing,
            Error,
            Chargeback
        }

        public enum TransactionType : short
        {
            All = 0,
            Unknown,
            Authorization,
            Purchase,
            Refund,
            Verify,
            Capture
        }

        public string Uuid { get; private set; }
        public TransactionType Action { get; set; }
        public int AmountInCents { get; set; }
        public int TaxInCents { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }

        public TransactionState Status { get; private set; }

        public string Reference { get; set; }

        public bool Test { get; private set; }
        public bool Voidable { get; private set; }
        public bool Refundable { get; private set; }

        public string IpAddress { get; private set; }

        public string CCVResult { get; private set; }
        public string AvsResult { get; private set; }
        public string AvsResultStreet { get; private set; }
        public string AvsResultPostal { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Account _account;

        public string AccountCode { get; private set; }

        public Boolean TaxExempt { get; set; }
        public string TaxCode { get; set; }
        public string AccountingCode { get; set; }
        public string GatewayType { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public string ApprovalCode { get; set; }
        public DateTime CollectedAt { get; set; }

        public Account Account
        {
            get { return _account ?? (_account = Accounts.Get(AccountCode)); }
            set
            {
                _account = value;
                AccountCode = value.AccountCode;
            }
        }
        public int? Invoice { get; private set; }
        public string InvoicePrefix { get; private set; }


        public string InvoiceNumberWithPrefix()
        {
            return InvoicePrefix + Convert.ToString(Invoice);
        }

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

        internal const string UrlPrefix = "/transactions/";

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
                UrlPrefix + Uri.EscapeDataString(Uuid) + (refund.HasValue ? "?amount_in_cents=" + refund.Value : ""),
                ReadXml);
        }

        public Invoice GetInvoice()
        {
            return Invoices.Get(InvoiceNumberWithPrefix());
        }


        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
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
                        {
                            string invoiceNumber = href.Substring(href.LastIndexOf("/") + 1);
                            MatchCollection matches = Regex.Matches(invoiceNumber, "([^\\d]{2})(\\d+)");

                            if (matches.Count == 1)
                            {
                                InvoicePrefix = matches[0].Groups[1].Value;
                                Invoice = int.Parse(matches[0].Groups[2].Value);
                            }
                            else
                            {
                                Invoice = int.Parse(invoiceNumber);
                            }
                        }
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
                            TaxInCents = amount;
                        break;

                    case "currency":
                        Currency = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "payment_method":
                        PaymentMethod = reader.ReadElementContentAsString();
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
                        Voidable = reader.ReadElementContentAsBoolean();
                        break;

                    case "refundable":
                        Refundable = reader.ReadElementContentAsBoolean();
                        break;

                    case "ip_address":
                        IpAddress = reader.ReadElementContentAsString();
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
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "details":
                        // API docs say not to load details into objects
                        break;

                    case "gateway_type":
                        GatewayType = reader.ReadElementContentAsString();
                        break;

                    case "origin":
                        Origin = reader.ReadElementContentAsString();
                        break;
                    case "message":
                        Message = reader.ReadElementContentAsString();
                        break;
                    case "approval_code":
                        ApprovalCode = reader.ReadElementContentAsString();
                        break;
                    case "collected_at":
                        DateTime d;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out d))
                        {
                            CollectedAt = d;
                        }
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("transaction");

            xmlWriter.WriteElementString("amount_in_cents", AmountInCents.AsString());
            xmlWriter.WriteElementString("currency", Currency);
            xmlWriter.WriteStringIfValid("description", Description);
            xmlWriter.WriteStringIfValid("payment_method", PaymentMethod);

            xmlWriter.WriteElementString("tax_exempt", TaxExempt.AsString().ToLower());
            xmlWriter.WriteStringIfValid("tax_code", TaxCode);
            xmlWriter.WriteStringIfValid("accounting_code", AccountingCode);

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
            return Uuid?.GetHashCode() ?? 0;
        }

        #endregion
    }

    public sealed class Transactions
    {
        private static readonly QueryStringBuilder Build = new QueryStringBuilder();
        /// <summary>
        /// Lists transactions by state and type. Defaults to all.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static RecurlyList<Transaction> List(TransactionList.TransactionState state = TransactionList.TransactionState.All,
            TransactionList.TransactionType type = TransactionList.TransactionType.All)
        {
            return List(state, type, null);
        }

        /// <summary>
        /// Lists transactions by state and type. Defaults to all.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<Transaction> List(TransactionList.TransactionState state,
            TransactionList.TransactionType type,
            FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            if (state != TransactionList.TransactionState.All)
            {
                parameters["state"] = state.ToString().EnumNameToTransportCase();
            }
            if (type != TransactionList.TransactionType.All)
            {
                parameters["type"] = type.ToString().EnumNameToTransportCase();
            }

            return new TransactionList(Transaction.UrlPrefix + "?" + parameters.ToString());
        }

        public static Transaction Get(string transactionId)
        {
            var transaction = new Transaction();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                Transaction.UrlPrefix + Uri.EscapeDataString(transactionId),
                transaction.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : transaction;
        }
    }
}
