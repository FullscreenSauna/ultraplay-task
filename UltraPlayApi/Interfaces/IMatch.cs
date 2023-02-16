using UltraPlayApi.Models;

namespace UltraPlayApi.Interfaces
{
    public interface IMatch
    {
        List<Bet> Bets { get; set; }
        int Id { get; set; }
        string MatchType { get; set; }
        int ExternalId { get; set; }
        string Name { get; set; }
        DateTime StartDate { get; set; }
    }
}