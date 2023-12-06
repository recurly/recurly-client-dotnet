using System.Xml;

namespace Recurly
{
    public class ExternalPaymentPhaseList : RecurlyList<ExternalPaymentPhase>
    {
        internal ExternalPaymentPhaseList(string baseUrl) : base(Client.HttpRequestMethod.Get, baseUrl)
        {
        }

        internal ExternalPaymentPhaseList()
        {
        }
        public override RecurlyList<ExternalPaymentPhase> Start
        {
            get { return HasStartPage() ? new ExternalPaymentPhaseList(StartUrl) : RecurlyList.Empty<ExternalPaymentPhase>(); }
        }

        public override RecurlyList<ExternalPaymentPhase> Next
        {
            get { return HasNextPage() ? new ExternalPaymentPhaseList(NextUrl) : RecurlyList.Empty<ExternalPaymentPhase>(); }
        }

        public override RecurlyList<ExternalPaymentPhase> Prev
        {
            get { return HasPrevPage() ? new ExternalPaymentPhaseList(PrevUrl) : RecurlyList.Empty<ExternalPaymentPhase>(); }
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "external_payment_phases" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "external_payment_phase")
                {
                    Add(new ExternalPaymentPhase(reader));
                }
            }
        }
    }
}