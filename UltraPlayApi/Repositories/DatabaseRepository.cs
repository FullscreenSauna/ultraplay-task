using System.Xml.Serialization;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Interfaces.Repository;
using UltraPlayApi.Models;

namespace UltraPlayApi.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public void SaveDatabaseChangess(UltraPlayContext _context, IEnumerable<IEvent> events)
        {
            foreach (var _event in events)
            {
                foreach (var match in _event.Matches)
                {
                    var existingMatch = _context.Matches.FirstOrDefault(e => e.ExternalId == match.ExternalId);

                    if (existingMatch == null)
                    {
                        var newMatch = match;

                        _context.Matches.Add(newMatch);
                    }
                    else
                    {
                        existingMatch.MatchType = match.MatchType;
                        existingMatch.StartDate = match.StartDate;
                    }

                    foreach (var bet in match.Bets)
                    {
                        foreach (var odd in bet.Odds)
                        {
                            var existingOdd = _context.Odds.FirstOrDefault(o => o.ExternalId == _event.ExternalId);

                            if (existingOdd == null)
                            {
                                var newOdd = odd;
                            }
                            else
                            {
                                existingOdd.Value = odd.Value;
                            }
                        }
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}
