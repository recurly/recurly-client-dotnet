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
    }
}
