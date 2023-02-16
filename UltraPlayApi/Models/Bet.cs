using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models;

public class Bet : IBet
{
    [XmlIgnore]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ID")]
    public int ExternalId { get; set; }

    [XmlAttribute("IsLive")]
    public bool IsLive { get; set; }

    [XmlElement("Odd")]
    public List<Odd> Odds { get; set; }
}