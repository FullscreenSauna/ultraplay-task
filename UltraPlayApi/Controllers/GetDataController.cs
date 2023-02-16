﻿using Microsoft.AspNetCore.Mvc;
using UltraPlayApi.Mappers;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace UltraPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private readonly UltraPlayContext _context;
        private IEnumerable<IEvent> _events;
        
        public GetDataController(UltraPlayContext _context,
                                 IEnumerable<IEvent> _events)
        {
            this._context = _context;
            this._events = _events;
        }

        [HttpGet]
        public async Task GetDataAsync()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(60));

            while (await timer.WaitForNextTickAsync())
            {

                var responseMessage = new HttpResponseMessage();
                using (var client = new HttpClient())
                {
                    responseMessage = client.GetAsync("https://sports.ultraplay.net/sportsxml?clientKey=9C5E796D-4D54-42FD-A535-D7E77906541A&sportId=2357&days=7").Result;
                }

                string xml = responseMessage.Content.ReadAsStringAsync().Result;

                _events = FeedMapper.MapFromXmlString(xml);

                SaveDbChanges(_events);
            }
        }

        private void SaveDbChanges(IEnumerable<IEvent> events)
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
