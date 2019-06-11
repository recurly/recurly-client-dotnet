using System.Xml;

namespace Recurly.Extensions
{
    internal static class RecurlyEntityExtensions
    {
        internal static void TryWriteXml(this IRecurlyEntity entity, XmlTextWriter writer)
        {
            var recurlyEntity = entity as RecurlyEntity;
            if (recurlyEntity == null)
            {
                return;
            }

            recurlyEntity.WriteXml(writer);
        }

        internal static void TryReadXml(this IRecurlyEntity entity, XmlTextReader reader)
        {
            var recurlyEntity = entity as RecurlyEntity;
            if (recurlyEntity == null)
            {
                return;
            }

            recurlyEntity.ReadXml(reader);
        }
    }
}
