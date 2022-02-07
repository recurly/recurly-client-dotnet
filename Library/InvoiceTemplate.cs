using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

  /// <summary>
  /// A Invoice Template in Recurly.
  /// </summary>
  public class InvoiceTemplate : RecurlyEntity
  {
    /// <summary>
    /// Unique ID assigned to this dunning campaign.
    /// </summary>
    public string Uuid { get; private set; }

    public string Name { get; private set; }

    public string Code { get; private set; }

    public string Description { get; private set; }

    public DateTime? CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    internal const string UrlPrefix = "/invoice_templates/";

    #region Constructors

    public InvoiceTemplate()
    {
    }

    internal InvoiceTemplate(XmlTextReader xmlReader)
    {
      ReadXml(xmlReader);
    }

    public RecurlyList<Account> GetAccounts()
    {
      return new AccountList(UrlPrefix + Uuid + "/accounts/");
    }

    #endregion

    internal override void ReadXml(XmlTextReader reader)
    {
      while (reader.Read())
      {
        if (reader.Name == "invoice_template" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType != XmlNodeType.Element) continue;

        DateTime dt;

        switch (reader.Name)
        {
          case "uuid":
            Uuid = reader.ReadElementContentAsString();
            break;

          case "name":
            Name = reader.ReadElementContentAsString();
            break;

          case "code":
            Code = reader.ReadElementContentAsString();
            break;

          case "description":
            Description = reader.ReadElementContentAsString();
            break;

          case "created_at":
            CreatedAt = reader.ReadElementContentAsDateTime();
            break;

          case "updated_at":
            UpdatedAt = reader.ReadElementContentAsDateTime();
            break;
        }

      }
    }

    internal override void WriteXml(XmlTextWriter xmlWriter)
    {
        throw new NotImplementedException();
    }

    #region Object Overrides

    public override string ToString()
    {
        return "Recurly Invoice Template: " + Uuid;
    }

    public override bool Equals(object obj)
    {
        var invoiceTemplate = obj as InvoiceTemplate;
        return invoiceTemplate != null && Equals(invoiceTemplate);
    }

    public bool Equals(InvoiceTemplate invoiceTemplate)
    {
        return Uuid == invoiceTemplate.Uuid;
    }

    public override int GetHashCode()
    {
        return Uuid?.GetHashCode() ?? 0;
    }

    #endregion
  }

  public sealed class InvoiceTemplates
  {
    /// <summary>
    /// Retrieves a list of all invoice templates
    /// </summary>
    public static RecurlyList<InvoiceTemplate> List()
    {
      return new InvoiceTemplateList("/invoice_templates");
    }

    /// <summary>
    /// Look up a Invoice Template.
    /// </summary>
    public static InvoiceTemplate Get(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        return null;
      }

      var invoiceTemplate = new InvoiceTemplate();

      var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
        InvoiceTemplate.UrlPrefix + Uri.EscapeDataString(id),
        invoiceTemplate.ReadXml);

      return statusCode == HttpStatusCode.NotFound ? null : invoiceTemplate;
    }
  }
}
