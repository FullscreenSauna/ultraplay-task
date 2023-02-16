using System.Xml.Serialization;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Interfaces.Repository;
using UltraPlayApi.Models;
using UltraPlayApi.Utils;

namespace UltraPlayApi.Repositories
{
    public class XmlFeedRepository : IXmlFeedRepository
    {
        private string SendRequest()
        {
            var responseMessage = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                responseMessage = client.GetAsync(SettingsReader.XmlFeedUrl()).Result;
            }

            return responseMessage.Content.ReadAsStringAsync().Result;
        }

        private IEnumerable<IEvent> MapFromXmlString(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));

            var xmlParsed = new XmlSports();

            using (TextReader textReader = new StringReader(xml))
            {
                xmlParsed = (XmlSports)serializer.Deserialize(textReader);
            }

            return xmlParsed.Sports[0].Events;
        }

        public IEnumerable<IEvent> GetFeedData()
        {
            var xml = SendRequest();

            return MapFromXmlString(xml);
        }
    }
}
