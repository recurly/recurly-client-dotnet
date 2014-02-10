using System.Xml;

namespace Recurly
{
    public class AddOnList : RecurlyList<AddOn>
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

        public override RecurlyList<AddOn> Start
        {
            get { return new AddOnList(StartUrl); }
        }

        public override RecurlyList<AddOn> Next
        {
            get { return new AddOnList(NextUrl); }
        }

        public override RecurlyList<AddOn> Prev
        {
            get { return new AddOnList(PrevUrl); }
        }
    }

}