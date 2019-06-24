using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recurly.List
{
    public class ExportFileList : RecurlyList<IExportFile>
    {
        public ExportFileList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        { }
        public override IRecurlyList<IExportFile> Start { get; }
        public override IRecurlyList<IExportFile> Next { get; }
        public override IRecurlyList<IExportFile> Prev { get; }
        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "export_files" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "export_file")
                {
                    Add(new ExportFile(reader));
                }
            }
        }
    }
}
