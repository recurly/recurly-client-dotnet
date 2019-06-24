using System.Xml;

namespace Recurly
{
    public class CreditPaymentList : RecurlyList<ICreditPayment>
    {
        public override IRecurlyList<ICreditPayment> Start
        {
            get { return HasStartPage() ? new CreditPaymentList(StartUrl) : RecurlyList.Empty<ICreditPayment>(); }
        }

        public override IRecurlyList<ICreditPayment> Next
        {
            get { return HasNextPage() ? new CreditPaymentList(NextUrl) : RecurlyList.Empty<ICreditPayment>(); }
        }

        public override IRecurlyList<ICreditPayment> Prev
        {
            get { return HasPrevPage() ? new CreditPaymentList(PrevUrl) : RecurlyList.Empty<ICreditPayment>(); }
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