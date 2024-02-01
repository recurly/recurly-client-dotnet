using System.Xml;

namespace Recurly
{
    public abstract class RevRecEntity : RecurlyEntity
    {
        public string LiabilityGlAccountId = "";
        public string RevenueGlAccountId = "";
        public string PerformanceObligationId { get; set; }

        internal protected void ReadRevRecNode(XmlTextReader reader)
        {
            switch (reader.Name)
            {
                case "liability_gl_account_id":
                    LiabilityGlAccountId = reader.ReadElementContentAsString();
                    break;

                case "revenue_gl_account_id":
                    RevenueGlAccountId = reader.ReadElementContentAsString();
                    break;

                case "performance_obligation_id":
                    PerformanceObligationId = reader.ReadElementContentAsString();
                    break;
            };
        }

        internal protected void WriteRevRecNodes(XmlTextWriter writer)
        {
            writer.WriteValidStringOrNil("liability_gl_account_id", LiabilityGlAccountId);
            writer.WriteValidStringOrNil("revenue_gl_account_id", RevenueGlAccountId);
            writer.WriteStringIfValid("performance_obligation_id", PerformanceObligationId);
        }
    }
}
