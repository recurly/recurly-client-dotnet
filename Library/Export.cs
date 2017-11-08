using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Recurly.List;

namespace Recurly
{
    public class ExportDate : RecurlyEntity
    {
        internal const string UrlPrefix = "/export_dates";
        public DateTime Date { get; set; }

        internal ExportDate(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "export_date" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "date":
                        DateTime d;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out d))
                            Date = d;

                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    public class ExportFile : RecurlyEntity
    {
        internal const string FilesUrlPrefix = "/export_dates/{0}/export_files/";
        internal const string FileUrlPrefix = FilesUrlPrefix + "{1}";
        public string DownloadUrl { get; set; }
        public string Name { get; set; }
        public string Md5Sum { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public ExportFile() { }
        internal ExportFile(XmlTextReader reader)
        {
            ReadXml(reader);
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "export_file" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "name":
                        Name = reader.ReadElementContentAsString();
                        break;
                    case "expires_at":
                        DateTime d;
                        if (DateTime.TryParse(reader.ReadElementContentAsString(), out d))
                            ExpiresAt = d;
                        break;
                    case "download_url":
                        DownloadUrl = reader.ReadElementContentAsString();
                        break;
                    case "md5sum":
                        Md5Sum = reader.ReadElementContentAsString();
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class Exports
    {
        public static RecurlyList<ExportDate> ListExportDates()
        {
            return new ExportDateList(ExportDate.UrlPrefix);
        }

        public static RecurlyList<ExportFile> ListExportFiles(DateTime date)
        {
            return new ExportFileList(string.Format(ExportFile.FilesUrlPrefix, date.ToString("yyyy-MM-dd")));
        }

        public static ExportFile DownloadExportFile(DateTime date, string fileName)
        {
            var exportFile = new ExportFile();
            var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
                string.Format(ExportFile.FileUrlPrefix, date.ToString("yyyy-MM-dd"), Uri.EscapeDataString(fileName)),
                exportFile.ReadXml);

            return statusCode != HttpStatusCode.NotFound ? exportFile : null;
        }
    }
}
