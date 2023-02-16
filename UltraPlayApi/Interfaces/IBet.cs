using UltraPlayApi.Models;

namespace UltraPlayApi.Interfaces
{
    public interface IBet
    {
        int Id { get; set; }
        bool IsLive { get; set; }
        string Name { get; set; }
        int ExternalId { get; set; }
        List<Odd> Odds { get; set; }
    }
}