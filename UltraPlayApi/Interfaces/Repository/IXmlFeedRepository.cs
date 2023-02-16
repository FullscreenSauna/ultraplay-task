using UltraPlayApi.Interfaces;

namespace UltraPlayApi.Interfaces.Repository
{
    public interface IXmlFeedRepository
    {
        IEnumerable<IEvent> GetFeedData();
    }
}