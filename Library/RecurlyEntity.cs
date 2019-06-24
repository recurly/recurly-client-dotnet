using System.Xml;

namespace Recurly
{
    public abstract class RecurlyEntity : IRecurlyEntity
    {
        internal QueryStringBuilder Build { get; set; }

        protected RecurlyEntity()
        {
            Build = new QueryStringBuilder();
        }

        internal abstract void ReadXml(XmlTextReader reader);
        internal abstract void WriteXml(XmlTextWriter writer);

        internal static void ReadXml(XmlTextReader reader, IRecurlyEntity entity)
        {
            var recurlyEntity = entity as RecurlyEntity;
            if (recurlyEntity != null)
                recurlyEntity.ReadXml(reader);
        }

        internal static void WriteXml(XmlTextWriter writer, IRecurlyEntity entity)
        {
            var recurlyEntity = entity as RecurlyEntity;
            if (recurlyEntity != null)
                recurlyEntity.WriteXml(writer);
        }
    }
}
