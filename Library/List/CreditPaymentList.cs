using System.Xml;

namespace Recurly
{
    public class CreditPaymentList : RecurlyList<CreditPayment>
    {
        public override RecurlyList<CreditPayment> Start
        {
            get { return HasStartPage() ? new CreditPaymentList(StartUrl) : RecurlyList.Empty<CreditPayment>(); }
        }

        public override RecurlyList<CreditPayment> Next
        {
            get { return HasNextPage() ? new CreditPaymentList(NextUrl) : RecurlyList.Empty<CreditPayment>(); }
        }

        public override RecurlyList<CreditPayment> Prev
        {
            get { return HasPrevPage() ? new CreditPaymentList(PrevUrl) : RecurlyList.Empty<CreditPayment>(); }
        }

        public CreditPaymentList()
        {
        }

        public CreditPaymentList(string url) : base(Client.HttpRequestMethod.Get, url)
        {
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if ((reader.Name == "credit_payments") && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType == XmlNodeType.Element && reader.Name == "credit_payment")
                {
                    Add(new CreditPayment(reader));
                }
            }
        }
    }
}