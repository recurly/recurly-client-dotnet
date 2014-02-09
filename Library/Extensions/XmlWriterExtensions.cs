using System.Xml;

namespace Recurly
{
    public static class XmlWriterExtensions
    {
        /// <summary>
        /// Convenience implementation of <see cref="T:System.Xml.XmlWriter.WriteElementString(string, string)"/> that guards it with
        /// a check if <paramref name="value"/> is null or empty, writing the value if it is not null or empty.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> that will be written to.</param>
        /// <param name="localName"></param>
        /// <param name="value"></param>
        public static void WriteStringIfValid(this XmlWriter writer, string localName, string value)
        {
            if (!value.IsNullOrEmpty())
                writer.WriteElementString(localName, value);
        }
    }
}