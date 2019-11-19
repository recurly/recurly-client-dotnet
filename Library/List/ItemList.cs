using System.Xml;

namespace Recurly
{
    public class ItemList : RecurlyList<Item>
    {
        internal ItemList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        public override RecurlyList<Item> Start
        {
            get { return HasStartPage() ? new ItemList(StartUrl) : RecurlyList.Empty<Item>(); }
        }

        public override RecurlyList<Item> Next
        {
            get { return HasNextPage() ? new ItemList(NextUrl) : RecurlyList.Empty<Item>(); }
        }

        public override RecurlyList<Item> Prev
        {
            get { return HasPrevPage() ? new ItemList(PrevUrl) : RecurlyList.Empty<Item>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "items" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
                {
                    Add(new Item(reader));
                }
            }
        }
    }
}
