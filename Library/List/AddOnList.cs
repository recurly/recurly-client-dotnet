using System;
using System.Xml;

namespace Recurly
{
    public class AddOnList : RecurlyList<AddOn>
    {
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
            get { throw new NotImplementedException(); }
        }

        public override RecurlyList<AddOn> Next
        {
            get { throw new NotImplementedException(); }
        }

        public override RecurlyList<AddOn> Prev
        {
            get { throw new NotImplementedException(); }
        }
    }

}