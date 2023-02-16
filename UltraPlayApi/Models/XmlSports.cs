using System.Composition;
using System.Xml.Serialization;
using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Models
{
    [XmlRoot("XmlSports")]
    public class XmlSports : IXmlSports
    {
        [XmlElement("Sport")]
        public List<Sport> Sports { get; set; }
    }
}
