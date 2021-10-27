using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace Recurly
{

  /// <summary>
    /// A Dunning Cycle in Recurly.
    ///
    /// </summary>
  public class DunningCycle : RecurlyEntity
  {

    public string Type { get; private set; }

    public bool AppliesToManualTrial { get; private set; }

    public int FirstCommunicationInterval { get; private set; }

    public bool SendImmediatelyOnHardDecline { get; private set; }

    public bool ExpireSubscription { get; private set; }

    public bool FailInvoice { get; private set; }

    public List<DunningInterval> DunningIntervals { get; private set;}

    public int TotalDunningDays { get; private set; }

    public int TotalRecyclingDays { get; private set; }

    public int Version { get; private set; }

    public DateTime? CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    internal DunningCycle()
    {
    }

    internal DunningCycle(XmlTextReader reader) : this()
    {
        ReadXml(reader);
    }

    internal override void ReadXml(XmlTextReader reader)
    {
        while (reader.Read())
        {
            if (reader.Name == "dunning_cycle" && reader.NodeType == XmlNodeType.EndElement)
                break;

            if (reader.NodeType != XmlNodeType.Element) continue;

            switch (reader.Name)
            {
                case "type":
                    Type = reader.ReadElementContentAsString();
                    break;
                case "applies_to_manual_trial":
                    AppliesToManualTrial = reader.ReadElementContentAsBoolean();
                    break;
                case "first_communication_interval":
                    FirstCommunicationInterval = reader.ReadElementContentAsInt();
                    break;
                case "send_immediately_on_hard_decline":
                    SendImmediatelyOnHardDecline = reader.ReadElementContentAsBoolean();
                    break;
                case "expire_subscription":
                    ExpireSubscription = reader.ReadElementContentAsBoolean();
                    break;
                case "fail_invoice":
                    FailInvoice = reader.ReadElementContentAsBoolean();
                    break;
                case "intervals":
                    ReadXMLDunningIntervals(reader);
                    break;
                case "total_dunning_days":
                    TotalDunningDays = reader.ReadElementContentAsInt();
                    break;
                case "total_recycling_days":
                    TotalRecyclingDays = reader.ReadElementContentAsInt();
                    break;
                case "version":
                    Version = reader.ReadElementContentAsInt();
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

    internal void ReadXMLDunningIntervals(XmlTextReader reader) {
      DunningIntervals = new List<DunningInterval>();

      while (reader.Read())
      {
        if (reader.Name == "intervals" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType == XmlNodeType.Element && reader.Name == "interval")
        {
            DunningIntervals.Add(new DunningInterval(reader));
        }
      }
    }

    internal override void WriteXml(XmlTextWriter writer)
    {
        throw new NotImplementedException();
    }
  }
}
