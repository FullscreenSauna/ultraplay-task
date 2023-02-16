using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models;

public class Match : IMatch
{
    [XmlIgnore]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ID")]
    public int ExternalId { get; set; }

    [XmlAttribute("StartDate")]
    public DateTime StartDate { get; set; }

    [XmlAttribute("MatchType")]
    public string MatchType { get; set; }

    [XmlElement("Bet")]
    public List<Bet> Bets { get; set; }
}