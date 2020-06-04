using System;
using RestSharp;
using RestSharp.Deserializers;

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
