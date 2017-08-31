using System;
using System.Xml;

namespace Recurly
{
    public class GiftCardList : RecurlyList<GiftCard>
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

        public override RecurlyList<GiftCard> Start
        {
            get { return HasStartPage() ? new GiftCardList(StartUrl) : RecurlyList.Empty<GiftCard>(); }
        }

        public override RecurlyList<GiftCard> Next
        {
            get { return HasNextPage() ? new GiftCardList(NextUrl) : RecurlyList.Empty<GiftCard>(); }
        }

        public override RecurlyList<GiftCard> Prev
        {
            get { return HasPrevPage() ? new GiftCardList(PrevUrl) : RecurlyList.Empty<GiftCard>(); }
        }
    }
}