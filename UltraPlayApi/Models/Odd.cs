using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models;

public class Odd : IOdd
{
    [XmlIgnore]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ID")]
    public int ExternalId { get; set; }

    [XmlAttribute("Value")]
    public decimal Value { get; set; }

    [XmlAttribute("SpecialBetValue")]
    public string? SpecialBetValue { get; set; }
}