using System;
using System.Xml;

namespace Recurly
{
    class OpenAmountRefund : RecurlyEntity
    {
        public int AmountInCents { get; protected set; }
        private Invoice.RefundOptions RefundOptions;

        [Obsolete("This constructor is deprecated, please use OpenAmountRefund(int, Invoice.RefundOptions).")]
        internal OpenAmountRefund(int amountInCents, Invoice.RefundMethod method = Invoice.RefundMethod.CreditFirst)
        {
            AmountInCents = amountInCents;
            RefundOptions = new Invoice.RefundOptions() {
              Method = method
            };
        }

        internal OpenAmountRefund(int amountInCents, Invoice.RefundOptions options)
        {
            AmountInCents = amountInCents;
            RefundOptions = options;
        }

        internal override void ReadXml(XmlTextReader reader)
        {
            throw new System.NotImplementedException();
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            writer.WriteStartElement("invoice");
            writer.WriteElementString("amount_in_cents", AmountInCents.AsString());
            writer.WriteElementString("refund_method", RefundOptions.Method.ToString().EnumNameToTransportCase());

            if (RefundOptions.ExternalRefund.HasValue)
              writer.WriteElementString("external_refund", RefundOptions.ExternalRefund.Value.AsString());
            if (RefundOptions.RefundedAt.HasValue)
              writer.WriteElementString("refunded_at", RefundOptions.RefundedAt.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));

            if (!RefundOptions.Description.IsNullOrEmpty())
              writer.WriteElementString("description", RefundOptions.Description);
            if (!RefundOptions.PaymentMethod.IsNullOrEmpty())
              writer.WriteElementString("payment_method", RefundOptions.PaymentMethod);
            if (!RefundOptions.CreditCustomerNotes.IsNullOrEmpty())
              writer.WriteElementString("credit_customer_notes", RefundOptions.CreditCustomerNotes);

            writer.WriteEndElement();
        }
    }
}
