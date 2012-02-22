using System.Configuration;

namespace Recurly.Configuration
{
    public class RecurlyApplicationCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RecurlyApplication();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RecurlyApplication)element).Name;
        }

        public new RecurlyApplication this[string appName]
        {
            get { return this.BaseGet(appName) as RecurlyApplication; }
        }
    }
}
