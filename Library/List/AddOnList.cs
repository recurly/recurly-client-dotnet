using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;

namespace Recurly
{
    public class AddOnList : RecurlyList<AddOn>
    {

        internal override void ReadXml(XmlTextReader reader)
        {

            while (reader.Read())
            {
                if ( (reader.Name.Equals("add_ons") || reader.Name.Equals("subscription_add_ons") ) &&
                    reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("add_on") )
                {
                    this.Add(new AddOn (reader));
                }
            }

        }


    }

}