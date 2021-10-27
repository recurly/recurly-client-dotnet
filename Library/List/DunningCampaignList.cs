using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Xml;

namespace Recurly
{
    public class DunningCampaignList : RecurlyList<DunningCampaign>
    {
        internal DunningCampaignList()
        {
        }

        internal DunningCampaignList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<DunningCampaign> Start
        {
            get { return HasStartPage() ? new DunningCampaignList(StartUrl) : RecurlyList.Empty<DunningCampaign>(); }
        }

        public override RecurlyList<DunningCampaign> Next
        {
            get { return HasNextPage() ? new DunningCampaignList(NextUrl) : RecurlyList.Empty<DunningCampaign>(); }
        }

        public override RecurlyList<DunningCampaign> Prev
        {
            get { return HasPrevPage() ? new DunningCampaignList(PrevUrl) : RecurlyList.Empty<DunningCampaign>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "dunning_campaigns" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "dunning_campaign")
                {
                    Add(new DunningCampaign(reader));
                }
            }
        }
    }
}
