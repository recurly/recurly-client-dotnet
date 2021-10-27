using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

  /// <summary>
  /// A Dunning Campaign in Recurly.
  /// </summary>
  public class DunningCampaign : RecurlyEntity
  {
    /// <summary>
    /// Unique ID assigned to this dunning campaign.
    /// </summary>
    public string Id { get; private set; }

    public string Name { get; private set; }

    public string Code { get; private set; }

    public string Description { get; private set; }

    public bool DefaultCampaign { get; private set; }

    private List<DunningCycle> _dunningCycles;

    public List<DunningCycle> DunningCycles
    {
        get { return _dunningCycles ?? (_dunningCycles = new List<DunningCycle>()); }
        set { _dunningCycles = value; }
    }

    public DateTime? CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime? DeletedAt { get; private set; }

    internal const string UrlPrefix = "/dunning_campaigns/";

    private List<string> PlanCodes { get; set;}

    #region Constructors

    public DunningCampaign()
    {
    }

    internal DunningCampaign(XmlTextReader xmlReader)
    {
      ReadXml(xmlReader);
    }

    #endregion

    /// <summary>
    /// Update the Dunning Campaign for multiple Plans
    /// </summary>
    public void BulkUpdate(List<string> planCodes)
    {
        PlanCodes = new List<string>();
        foreach (string planCode in planCodes)
        {
          PlanCodes.Add(planCode);
        }
        // PUT /dunning_campaigns/<id>/bulk_update
        Client.Instance.PerformRequest(Client.HttpRequestMethod.Put,
            UrlPrefix + Uri.EscapeDataString(Id.ToString()) + "/bulk_update",
            WriteBulkUpdateXml);
    }

    internal override void ReadXml(XmlTextReader reader)
    {
      while (reader.Read())
      {
        if (reader.Name == "dunning_campaign" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType != XmlNodeType.Element) continue;

        DateTime dt;

        switch (reader.Name)
        {
          case "id":
            Id = reader.ReadElementContentAsString();
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

          case "default_campaign":
            DefaultCampaign = reader.ReadElementContentAsBoolean();
            break;

          case "dunning_cycles":
            ReadXMLDunningCycles(reader);
            break;

          case "created_at":
            CreatedAt = reader.ReadElementContentAsDateTime();
            break;

          case "updated_at":
            UpdatedAt = reader.ReadElementContentAsDateTime();
            break;

          case "deleted_at":
            if (DateTime.TryParse(reader.ReadElementContentAsString(), out dt))
                DeletedAt = dt;
            break;
        }

      }
    }

    internal void ReadXMLDunningCycles(XmlTextReader reader) {
      DunningCycles.Clear();

      while (reader.Read())
      {
        if (reader.Name == "dunning_cycles" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType == XmlNodeType.Element && reader.Name == "dunning_cycle")
        {
            DunningCycles.Add(new DunningCycle(reader));
        }
      }
    }

    internal void WriteBulkUpdateXml(XmlTextWriter xmlWriter)
    {
      xmlWriter.WriteStartElement("dunning_campaign");
      xmlWriter.WriteStartElement("plan_codes");
      foreach (string planCode in PlanCodes)
      {
         xmlWriter.WriteElementString("plan_code", planCode);
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndElement();
    }

    internal override void WriteXml(XmlTextWriter xmlWriter)
    {
        throw new NotImplementedException();
    }
  }

  public sealed class DunningCampaigns
  {
    /// <summary>
    /// Retrieves a list of all active dunning campaigns
    /// </summary>
    public static RecurlyList<DunningCampaign> List()
    {
      return new DunningCampaignList("/dunning_campaigns");
    }

    /// <summary>
    /// Look up a Dunning Campaign.
    /// </summary>
    public static DunningCampaign Get(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        return null;
      }

      var dunningCampaign = new DunningCampaign();

      var statusCode = Client.Instance.PerformRequest(Client.HttpRequestMethod.Get,
        DunningCampaign.UrlPrefix + Uri.EscapeDataString(id),
        dunningCampaign.ReadXml);

      return statusCode == HttpStatusCode.NotFound ? null : dunningCampaign;
    }
  }
}
