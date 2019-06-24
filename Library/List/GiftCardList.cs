using System;
using System.Xml;

namespace Recurly
{
    public class GiftCardList : RecurlyList<IGiftCard>
    {
        internal GiftCardList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "gift_cards" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "gift_card")
                {
                    Add(new GiftCard(reader));
                }
            }

        }

        public override IRecurlyList<IGiftCard> Start
        {
            get { return HasStartPage() ? new GiftCardList(StartUrl) : RecurlyList.Empty<IGiftCard>(); }
        }

        public override IRecurlyList<IGiftCard> Next
        {
            get { return HasNextPage() ? new GiftCardList(NextUrl) : RecurlyList.Empty<IGiftCard>(); }
        }

        public override IRecurlyList<IGiftCard> Prev
        {
            get { return HasPrevPage() ? new GiftCardList(PrevUrl) : RecurlyList.Empty<IGiftCard>(); }
        }
    }
}