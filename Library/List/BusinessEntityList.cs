using System;
using System.Xml;

namespace Recurly
{
    public class BusinessEntityList : RecurlyList<BusinessEntity>
    {
        internal BusinessEntityList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }
        public override RecurlyList<BusinessEntity> Start
        {
            get { return HasStartPage() ? new BusinessEntityList(StartUrl) : RecurlyList.Empty<BusinessEntity>(); }
        }

        public override RecurlyList<BusinessEntity> Next
        {
            get { return HasNextPage() ? new BusinessEntityList(NextUrl) : RecurlyList.Empty<BusinessEntity>(); }
        }

        public override RecurlyList<BusinessEntity> Prev
        {
            get { return HasPrevPage() ? new BusinessEntityList(PrevUrl) : RecurlyList.Empty<BusinessEntity>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "business_entities" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "business_entity")
                    Add(new BusinessEntity(reader));
            }
        }
    }
}
