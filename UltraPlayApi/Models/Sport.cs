using System.Composition;
using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models
{
    [XmlRoot("Sport")]
    public class Sport : ISport
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute()]
        public int ID { get; set; }

        [XmlElement("Event")]
        public List<Event> Events { get; } = new List<Event>();
    }
}
