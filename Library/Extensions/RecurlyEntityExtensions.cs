using System.Xml;

namespace Recurly.Extensions
{
    internal static class RecurlyEntityExtensions
    {
        internal static void TryWriteXml(this IRecurlyEntity entity, XmlTextWriter writer)
        {
            RecurlyEntity.WriteXml(writer, entity);
        }

        internal static void TryReadXml(this IRecurlyEntity entity, XmlTextReader reader)
        {
            RecurlyEntity.ReadXml(reader, entity);
        }
    }
}
