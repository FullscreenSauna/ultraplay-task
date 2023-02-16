using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models;

[XmlRoot("Event")]
public class Event : IEvent
{
    [XmlIgnore]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ID")]
    public int ExternalId { get; set; }

    [XmlAttribute("IsLive")]
    public bool IsLive { get; set; }

    [XmlAttribute("CategoryID")]
    public int CategoryID { get; set; }

    [XmlElement("Match")]
    public List<Match> Matches { get; set; }
}