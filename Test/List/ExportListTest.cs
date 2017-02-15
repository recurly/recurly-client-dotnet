using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Recurly.Test.List
{
    public class ExportListTest : BaseTest
    {
        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListDates()
        {
            var dates = Exports.ListExportDates();
            Assert.NotNull(dates);
            Assert.NotEmpty(dates);
            Assert.True(dates[0].Date != DateTime.MinValue);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void ListFiles()
        {
            var dates = Exports.ListExportDates();
            var files = Exports.ListExportFiles(dates[0].Date);
            Assert.NotNull(files);
            Assert.NotEmpty(files);
            Assert.NotNull(files[0].Name);
            Assert.NotNull(files[0].Md5Sum);
        }

        [RecurlyFact(TestEnvironment.Type.Integration)]
        public void GetFileUrl()
        {
            var dates = Exports.ListExportDates();
            var files = Exports.ListExportFiles(dates[0].Date);
            var file = Exports.DownloadExportFile(dates[0].Date, files[0].Name);
            Assert.NotNull(file);
            Assert.NotNull(file);
            Assert.NotNull(file.DownloadUrl);
            Assert.NotNull(file.ExpiresAt);
        }
    }
}
