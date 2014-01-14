using System.Xml;

namespace Recurly
{
    public static class EnumExtensions
    {
        public static bool Is(this Account.AccountState source, Account.AccountState target)
        {
            return (source & target) == target;
        }

        public static Account.AccountState Remove(this Account.AccountState source, Account.AccountState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        public static Account.AccountState Add(this Account.AccountState source, Account.AccountState target)
        {
            return source | target;
        }
    }

    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }
    }

    public static class XmlWriterExtensions
    {
        public static void WriteStringIfValid(this XmlWriter writer, string localName, string value)
        {
            if (!value.IsNullOrEmpty())
                writer.WriteElementString(localName, value);
        }
    }
}
