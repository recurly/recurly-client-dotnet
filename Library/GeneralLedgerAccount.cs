using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// A general ledger account in Recurly.
    ///
    /// </summary>
    public class GeneralLedgerAccount : RecurlyEntity
    {
        public GeneralLedgerAccountType AccountType { get; private set; }

        public string Id { get; private set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        internal const string UrlPrefix = "/general_ledger_accounts/";

        #region Constructors

        public GeneralLedgerAccount()
        {
        }

        internal GeneralLedgerAccount(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        public GeneralLedgerAccount(string code, GeneralLedgerAccountType accountType)
        {
            Code = code;
            AccountType = accountType;
        }

        /// <summary>
        /// Allows for selecting an account type by its string value (e.g. "liability").
        /// </summary>
        private GeneralLedgerAccountType ParseAccountType(string accountType)
        {
            var aType = char.ToUpper(accountType[0]) + accountType.Substring(1);
            return (GeneralLedgerAccountType)Enum.Parse(typeof(GeneralLedgerAccountType), aType);
        }

        #endregion

        /// <summary>
        /// Create a new general ledger account in Recurly.
        /// </summary>
        public void Create()
        {
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Post,
                UrlPrefix,
                WriteXml,
                ReadXml);
        }

        /// <summary>
        /// Update an existing general ledger account in Recurly.
        /// </summary>
        public void Update()
        {
            // PUT /general_ledger_accounts/<general_ledger_account_id>
            Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
                UrlPrefix + Uri.EscapeDataString(Id),
                WriteUpdateXml);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                DateTime dateVal;

                if (reader.Name == "general_ledger_account" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "id":
                        Id = reader.ReadElementContentAsString();
                        break;

                    case "account_type":
                        AccountType = ParseAccountType(reader.ReadElementContentAsString());
                        break;

                    case "code":
                        Code = reader.ReadElementContentAsString();
                        break;

                    case "description":
                        Description = reader.ReadElementContentAsString();
                        break;

                    case "created_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                        {
                            CreatedAt = dateVal;
                        }
                        break;

                    case "updated_at":
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out dateVal))
                        {
                            UpdatedAt = dateVal;
                        }
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("general_ledger_account");

            xmlWriter.WriteElementString("account_type", AccountType.ToString().EnumNameToTransportCase());
            xmlWriter.WriteElementString("code", Code);
            xmlWriter.WriteStringIfValid("description", Description);

            xmlWriter.WriteEndElement();
        }

        internal void WriteUpdateXml(XmlTextWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("general_ledger_account");

            xmlWriter.WriteElementString("code", Code);
            xmlWriter.WriteStringIfValid("description", Description);

            xmlWriter.WriteEndElement();
        }
    }

    public sealed class GeneralLedgerAccounts
    {
        internal const string UrlPrefix = "/general_ledger_accounts/";

        /// <summary>
        /// Retrieves a list of all general ledger accounts.
        /// </summary>
        /// <returns></returns>
        public static RecurlyList<GeneralLedgerAccount> List()
        {
            return List(null);
        }

        public static RecurlyList<GeneralLedgerAccount> List(FilterCriteria filter)
        {
            filter = filter == null ? FilterCriteria.Instance : filter;
            return new GeneralLedgerAccountList(GeneralLedgerAccount.UrlPrefix + "?" + filter.ToNamedValueCollection().ToString());
        }

        /// <summary>
        /// Lists general ledger accounts, limited to state
        /// </summary>
        /// <param name="account_type">Retrieve GLAs of a particular type</param>
        /// <returns></returns>
        public static RecurlyList<GeneralLedgerAccount> List(GeneralLedgerAccountType accountType)
        {
            return List(accountType, null);
        }

        /// <summary>
        /// Lists general ledger accounts, limited to state
        /// </summary>
        /// <param name="account_type">Retrieve GLAs of a particular type</param>
        /// <param name="filter">FilterCriteria used to apply server side sorting and filtering</param>
        /// <returns></returns>
        public static RecurlyList<GeneralLedgerAccount> List(GeneralLedgerAccountType accountType,
                                                             FilterCriteria filter)
        {
            filter = filter ?? FilterCriteria.Instance;
            var parameters = filter.ToNamedValueCollection();
            parameters["account_type"] = accountType.ToString().EnumNameToTransportCase();
            return new GeneralLedgerAccountList(GeneralLedgerAccount.UrlPrefix + "?" + parameters.ToString());
        }

        public static GeneralLedgerAccount Get(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            var generalLedgerAccount = new GeneralLedgerAccount();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
              UrlPrefix + Uri.EscapeDataString(code),
              generalLedgerAccount.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : generalLedgerAccount;
        }

    }

}
