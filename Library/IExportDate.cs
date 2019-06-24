using System;

namespace Recurly
{
    public interface IExportDate : IRecurlyEntity
    {
        DateTime Date { get; set; }
    }

    public interface IExportFile : IRecurlyEntity
    {
        string DownloadUrl { get; set; }
        DateTime? ExpiresAt { get; set; }
        string Md5Sum { get; set; }
        string Name { get; set; }
    }
}
