using UltraPlayApi.Interfaces;
using UltraPlayApi.Models;

namespace UltraPlayApi.Interfaces.Repository
{
    public interface IDatabaseRepository
    {
        void SaveDatabaseChangess(UltraPlayContext _context, IEnumerable<IEvent> events);
    }
}