using System.Xml;

namespace Recurly
{
    public class AddOnList : RecurlyList<IAddOn>
    {
        public AddOnList()
        {
        }

        public AddOnList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name =="add_ons" || reader.Name == "subscription_add_ons") &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "add_on")
                {
                    Add(new AddOn(reader));
                }
            }
        }

        public override IRecurlyList<IAddOn> Start
        {
            get { return HasStartPage() ? new AddOnList(StartUrl) : RecurlyList.Empty<IAddOn>(); }
        }

        public override IRecurlyList<IAddOn> Next
        {
            get { return HasNextPage() ? new AddOnList(NextUrl) : RecurlyList.Empty<IAddOn>(); }
        }

        public override IRecurlyList<IAddOn> Prev
        {
            get { return HasPrevPage() ? new AddOnList(PrevUrl) : RecurlyList.Empty<IAddOn>(); }
        }
    }
}