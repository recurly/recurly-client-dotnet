using System.Xml;

namespace Recurly
{
    public class AddOnList : RecurlyList<AddOn>
    {
        public string PlanCode { get; private set; }

        public AddOnList()
        {
        }

        public AddOnList(string planCode, string url) : base(Client.HttpRequestMethod.Get, url)
        {
            PlanCode = planCode;
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
                    Add(new AddOn(PlanCode, reader));
                }
            }
        }

        public override RecurlyList<AddOn> Start
        {
            get { return HasStartPage() ? new AddOnList(PlanCode, StartUrl) : RecurlyList.Empty<AddOn>(); }
        }

        public override RecurlyList<AddOn> Next
        {
            get { return HasNextPage() ? new AddOnList(PlanCode, NextUrl) : RecurlyList.Empty<AddOn>(); }
        }

        public override RecurlyList<AddOn> Prev
        {
            get { return HasPrevPage() ? new AddOnList(PlanCode, PrevUrl) : RecurlyList.Empty<AddOn>(); }
        }
    }
}