using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace Recurly.Test.Fixtures
{
    public class FixtureImporter
    {
        public static string GetFixtureTypeDescription(FixtureType type)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])type
           .GetType()
           .GetField(type.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        public static FixtureResponse Get(FixtureType type, string name)
        {
            if (name.IsNullOrEmpty())
                throw new ArgumentNullException("name");

            if (!Enum.IsDefined(typeof(FixtureType), type))
                throw new InvalidEnumArgumentException("type", (int)type, typeof(FixtureType));

            var fixturePath = string.Format("Fixtures/{0}/{1}.xml", GetFixtureTypeDescription(type), name);
            Console.WriteLine("Loading fixture for test: {0}", fixturePath);

            if (!File.Exists(fixturePath))
                throw new FileNotFoundException("Could not locate the fixture response file!", fixturePath);

            var contents = new List<string>();
            using (var reader = new StreamReader(File.OpenRead(fixturePath)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    contents.Add(line);
            }

            var response = new FixtureResponse();
            var count = 0;
            for (; count < contents.Count; ++count)
            {
                var line = contents[count];
                if (line.IsNullOrWhiteSpace()) continue;

                if (line.StartsWith("HTTP"))
                    response.StatusCode = ParseStatusCode(line);
                else if (line.StartsWith("<"))
                    break;
                else
                    response.AddHeader(ParseHeader(line));
            }

            var remainder = contents.Count - count;
            response.Xml = string.Join(Environment.NewLine, contents.ToArray(), count, remainder);

            return response;
        }

        private static HttpStatusCode ParseStatusCode(string line)
        {
            var split = line.Split(' ');
            var code = int.Parse(split[1]);
            return code.ParseAsEnum<HttpStatusCode>();
        }

        private static KeyValuePair<string, string> ParseHeader(string line)
        {
            var split = line.Split(':');
            return new KeyValuePair<string, string>(split[0].SafeTrim(), split[1].SafeTrim());
        }
    }

    public enum FixtureType
    {
        [Description("accounts")]
        Accounts,
        [Description("addons")]
        AddOns,
        [Description("business_entities")]
        BusinessEntities,
        [Description("external_payment_phases")]
        ExternalPaymentPhases,
        [Description("external_invoices")]
        ExternalInvoices,
        [Description("general_ledger_accounts")]
        GeneralLedgerAccounts,
        [Description("gift_cards")]
        GiftCards,
        [Description("items")]
        Items,
        [Description("performance_obligations")]
        PerformanceObligations,
        [Description("plans")]
        Plans,
        [Description("shipping_methods")]
        ShippingMethods,
    }
}
