namespace Recurly
{
    public class FileSerializer
    {
        public Recurly.Resources.BinaryFile Deserialize(byte[] rawBytes)
        {
            return new Recurly.Resources.BinaryFile { Data = rawBytes };
        }
    }
}
