using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    public class Entitlement : RecurlyEntity
    {
        public string AccountCode { get; private set; }

        public CustomerPermission CustomerPermission { get; private set; }

        public GrantedBy GrantedBy { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private const string UrlPrefix = "/accounts/";
        private const string UrlPostfix = "/entitlements";

        internal Entitlement(string accountCode) : this()
        {
            AccountCode = accountCode;
        }

        public Entitlement(Account account) : this()
        {
            AccountCode = account.AccountCode;
        }

        internal Entitlement(XmlTextReader xmlReader)
        {
            ReadXml(xmlReader);
        }

        public Entitlement() { }

        /// <summary>
        /// Lookup a Recurly account's entitlements
        /// </summary>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public static Entitlement Get(string accountCode)
        {
            if (string.IsNullOrWhiteSpace(accountCode))
            {
                return null;
            }

            var entitlement = new Entitlement();

            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                EntitlementUrl(accountCode),
                entitlement.ReadXml);

            return statusCode == HttpStatusCode.NotFound ? null : entitlement;
        }

        private static string EntitlementUrl(string accountCode)
        {
            return UrlPrefix + Uri.EscapeDataString(accountCode) + UrlPostfix;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "entitlement" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "entitlement":
                        // The element's opening tag - nothing to do
                        break;

                    case "customer_permission":
                        CustomerPermission = new CustomerPermission(reader);
                        break;

                    case "granted_by":
                        //ReadXMLGrantedBys(reader);
                        GrantedBy = new GrantedBy(reader);
                        break;

                    case "created_at":
                        CreatedAt = reader.ReadElementContentAsDateTime();
                        break;

                    case "updated_at":
                        UpdatedAt = reader.ReadElementContentAsDateTime();
                        break;
                }
            }
        }


        // TODO: remove this from here
        //internal void ReadXMLGrantedBys(XmlTextReader reader)
        //{
        //    GrantedBys = new List<GrantedBy>();

        //    while (reader.Read())
        //    {
        //        if (reader.Name == "granted_by" && reader.NodeType == XmlNodeType.EndElement)
        //            break;

        //        if (reader.NodeType != XmlNodeType.Element) continue;


        //        if (reader.NodeType == XmlNodeType.Element && reader.Name == "subscription")
        //        {
        //            var subscriptionHref = reader.GetAttribute("href");
        //            string thing1 = subscriptionHref.Substring(subscriptionHref.LastIndexOf("/") + 1);
        //           // string thing = Uri.UnescapeDataString(subscriptionHref.Substring(subscriptionHref.LastIndexOf("/") + 1));

        //            SubscriptionIds.Add(thing1);
                    
        //        //    break;
        //         //   GrantedBys.Add(new GrantedBy(reader));
        //        }

        //        if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_subscription")
        //        {
        //            GrantedBys.Add(new GrantedBy(reader));
        //        }

        //        if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
        //        {
        //            GrantedBys.Add(new GrantedBy(reader));
        //        }
        //    }
        //}

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
