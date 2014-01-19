using System.Globalization;
using System.Xml;
using AccountState = Recurly.Account.AccountState;
using SubscriptionState = Recurly.Subscription.SubscriptionState;

namespace Recurly
{
    public static class EnumExtensions
    {
        public static bool Is(this AccountState source, AccountState target)
        {
            return (source & target) == target;
        }

        public static AccountState Remove(this AccountState source, AccountState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        public static AccountState Add(this AccountState source, AccountState target)
        {
            return source | target;
        }

        public static bool Is(this SubscriptionState source, SubscriptionState target)
        {
            return (source & target) == target;
        }

        public static SubscriptionState Remove(this SubscriptionState source, SubscriptionState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        public static SubscriptionState Add(this SubscriptionState source, SubscriptionState target)
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

    public static class IntExtensions
    {
        public static string AsString(this int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
