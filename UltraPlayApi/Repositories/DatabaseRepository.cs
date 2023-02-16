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
                    // get the match from dbcontext that is the same as the one in the dbcontext
                    var existingMatch = _context.Matches.FirstOrDefault(e => e.ExternalId == match.ExternalId);

                    // if the previous statement did not return anything -> the match from the feed is new
                    if (existingMatch == null)
                    {
                        // add the new match to the dbcontext
                        // reassignment is purely for readability
                        var newMatch = match;

                        _context.Matches.Add(newMatch);
                    }
                    else
                    {
                        // if the match is already in the dbcontext update the properties that can change
                        existingMatch.MatchType = match.MatchType;
                        existingMatch.StartDate = match.StartDate;
                    }

                    foreach (var bet in match.Bets)
                    {
                        foreach (var odd in bet.Odds)
                        {
                            // get the odd from dbcontext that is the same as the one in the dbcontext
                            var existingOdd = _context.Odds.FirstOrDefault(o => o.ExternalId == _event.ExternalId);

                            // if the previous statement did not return anything -> the odd from the feed is new
                            if (existingOdd == null)
                            {
                                // add the new odd to the dbcontext
                                // reassignment is purely for readability
                                var newOdd = odd;

                                _context.Odds.Add(newOdd);
                            }
                            else
                            {
                                // if the odd is already in the dbcontext update the properties that can change
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
