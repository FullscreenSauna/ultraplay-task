using System.Xml.Serialization;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Models;

namespace UltraPlayApi.Mappers
{
    public static class FeedMapper
    {
        public static IEnumerable<IEvent> MapFromXmlString(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));

            var xmlParsed = new XmlSports();

            using (TextReader textReader = new StringReader(xml))
            {
                xmlParsed = (XmlSports)serializer.Deserialize(textReader);
            }

            return xmlParsed.Sports[0].Events;
        }
    }
}
