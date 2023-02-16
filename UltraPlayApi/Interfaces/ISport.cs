using UltraPlayApi.Models;

namespace UltraPlayApi.Interfaces
{
    public interface ISport
    {
        List<Event> Events { get; }
        int ID { get; set; }
        string Name { get; set; }
    }
}