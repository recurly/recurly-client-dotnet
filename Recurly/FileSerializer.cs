using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using RestSharp.Serializers;
using RestSharp.Deserializers;
using RestSharp;
using System.IO;

namespace Recurly
{
    public class FileSerializer : IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            var binaryFile = new Recurly.Resources.BinaryFile();
            binaryFile.Data = response.RawBytes;
            return (T)Convert.ChangeType(binaryFile, typeof(T));
        }
    }
}
