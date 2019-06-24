using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

    /// <summary>
    /// Represents a collection of charge and credit invoices
    /// </summary>
    public class InvoiceCollection : RecurlyEntity, IInvoiceCollection
    {
       
        /// <summary>
        /// The invoice associated with charges.
        /// </summary>
        public IInvoice ChargeInvoice { get; private set; }

        /// <summary>
        /// The invoices associated with credits.
        /// </summary>
        public IRecurlyList<IInvoice> CreditInvoices { get; private set; }

        internal InvoiceCollection()
        {
        }

        internal InvoiceCollection(XmlTextReader reader)
        {
            ReadXml(reader);
        }


        #region Read and Write XML documents

        internal override void ReadXml(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "invoice_collection" && reader.NodeType == XmlNodeType.EndElement)
                    break;

                if (reader.NodeType != XmlNodeType.Element) continue;

                switch (reader.Name)
                {
                    case "charge_invoice":
                        var invoice = new Invoice();
                        invoice.ReadXml(reader, "charge_invoice");
                        ChargeInvoice = invoice;
                        break;                    
                    case "credit_invoices":
                        var invoices = new InvoiceList();
                        invoices.ReadXml(reader, "credit_invoices", "credit_invoice");
                        CreditInvoices = invoices;
                        break;
                }
            }
        }

        internal override void WriteXml(XmlTextWriter writer)
        {
            throw new NotImplementedException();
        }

       
        #endregion


        #region Object Overrides

        public override string ToString()
        {
            return "Recurly Invoice Collection";
        }

        public override bool Equals(object obj)
        {
            var sub = obj as IInvoiceCollection;
            return sub != null && Equals(sub);
        }

        public bool Equals(IInvoiceCollection collection)
        {
            return ChargeInvoice == collection?.ChargeInvoice
                && CreditInvoices == collection?.CreditInvoices;
        }

        public override int GetHashCode()
        {
            return ChargeInvoice?.GetHashCode() ?? 0;
        }

        #endregion
    }
}
