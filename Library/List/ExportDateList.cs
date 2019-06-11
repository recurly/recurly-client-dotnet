using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly.List
{
    public class ExportDateList : RecurlyList<ExportDate>
    {
        public ExportDateList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        { }
        public override IRecurlyList<ExportDate> Start
        {
            get { return HasStartPage() ? new ExportDateList(StartUrl) : RecurlyList.Empty<ExportDate>(); }
        }

        public override IRecurlyList<ExportDate> Next
        {
            get { return HasNextPage() ? new ExportDateList(NextUrl) : RecurlyList.Empty<ExportDate>(); }
        }

        public override IRecurlyList<ExportDate> Prev
        {
            get { return HasPrevPage() ? new ExportDateList(PrevUrl) : RecurlyList.Empty<ExportDate>(); }
        }
        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "export_dates" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "export_date")
                {
                    Add(new ExportDate(reader));
                }
            }
        }
    }
}
