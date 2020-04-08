using System;
using System.Collections.Generic;
using System.Xml;

namespace Recurly 
{
  /// <summary>
  /// Represents add-on tiers
  /// </summary>
  public class Tier : RecurlyEntity
  {
    public int? EndingQuantity { get; set; }

    private Dictionary<string, int> _unitAmountInCents;

    /// <summary>
    /// A dictionary of currencies and values for the tier unit amount
    /// </summary>
    public Dictionary<string, int> UnitAmountInCents{
      get { return _unitAmountInCents ?? (_unitAmountInCents = new Dictionary<string, int>()); }
    }

    #region Constructors

    public Tier() {
    }

    internal Tier(XmlTextReader xmlReader){
      ReadXml(xmlReader);
    }

    #endregion

    #region Read and Write XML documents

    internal void ReadXmlUnitAmount(XmlTextReader reader){
      while (reader.Read()){
        if (reader.Name == "unit_amount_in_cents" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType == XmlNodeType.Element){
          UnitAmountInCents.Remove(reader.Name);
          UnitAmountInCents.Add(reader.Name, reader.ReadElementContentAsInt());
        }
      }
    }

    internal override void ReadXml(XmlTextReader reader)
    {
      UnitAmountInCents.Clear();

      while (reader.Read())
      {
        if (reader.Name == "tier" && reader.NodeType == XmlNodeType.EndElement)
          break;

        if (reader.NodeType != XmlNodeType.Element) continue;
        switch (reader.Name){
          case "unit_amount_in_cents":
            ReadXmlUnitAmount(reader);
            break;

          case "ending_quantity":
            EndingQuantity = reader.ReadElementContentAsInt();
            break;
        }
      }
    }

    internal override void WriteXml(XmlTextWriter xmlWriter){
      WriteXml(xmlWriter, false);
    }

    internal void WriteEmbeddedXml(XmlTextWriter xmlWriter){
      WriteXml(xmlWriter, true);
    }

    internal void WriteXml(XmlTextWriter xmlWriter, bool embedded = false){
      xmlWriter.WriteStartElement("tier");

      xmlWriter.WriteIfCollectionHasAny("unit_amount_in_cents", UnitAmountInCents, pair => pair.Key,
        pair => pair.Value.AsString());

      if (EndingQuantity.HasValue)
        xmlWriter.WriteElementString("ending_quantity", EndingQuantity.Value.AsString());

      xmlWriter.WriteEndElement();
    }

    #endregion
  }
}
