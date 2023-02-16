using UltraPlayApi.Models;

namespace UltraPlayApi.Interfaces
{
    public interface IEvent
    {
        int CategoryID { get; set; }
        int Id { get; set; }
        int ExternalId { get; set; }
        bool IsLive { get; set; }
        List<Match> Matches { get; set; }
        string Name { get; set; }
    }
}