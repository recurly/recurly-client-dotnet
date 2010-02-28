using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Text;

namespace Recurly
{
    /// <summary>
    /// Internal class to help get a list of charges on an account.
    /// </summary>
    public class RecurlyLineItemList : List<RecurlyLineItem>
    {
        internal RecurlyLineItemList()
        { }

        public static RecurlyLineItem[] GetCharges(string accountCode)
        {
            RecurlyLineItemList chargeList = new RecurlyLineItemList();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                RecurlyCharge.ChargesUrl(accountCode),
                new RecurlyClient.ReadXmlDelegate(chargeList.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return chargeList.ToArray();
        }

        public static RecurlyLineItem[] GetCredits(string accountCode)
        {
            RecurlyLineItemList creditList = new RecurlyLineItemList();

            HttpStatusCode statusCode = RecurlyClient.PerformRequest(RecurlyClient.HttpRequestMethod.Get,
                RecurlyCredit.CreditsUrl(accountCode),
                new RecurlyClient.ReadXmlDelegate(creditList.ReadXml));

            if (statusCode == HttpStatusCode.NotFound)
                return null;

            return creditList.ToArray();
        }

        internal void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                // End of account element, get out of here
                if ((reader.Name == "charges" || reader.Name == "credits" || reader.Name == "line_items") && 
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "charge":
                            this.Add(new RecurlyCharge(reader));
                            break;
                        case "credit":
                            this.Add(new RecurlyCredit(reader));
                            break;
                        case "line_item":
                            // TODO: Fix this to parse correctly for credits
                            this.Add(new RecurlyCharge(reader));
                            break;
                    }
                }
            }
        }
    }
}