using Microsoft.AspNetCore.Mvc;
using UltraPlayApi.Mappers;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UltraPlayApi.Repositories;
using UltraPlayApi.Interfaces.Repository;

namespace UltraPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        private readonly UltraPlayContext _context;
        private IEnumerable<IEvent> _events;
        private readonly IDatabaseRepository databaseRepository;
        private readonly IXmlFeedRepository xmlFeedRepository;

        public GetDataController(UltraPlayContext _context,
                                 IEnumerable<IEvent> _events,
                                 IDatabaseRepository databaseRepository,
                                 IXmlFeedRepository xmlFeedRepository)
        {
            this._context = _context;
            this._events = _events;
            this.databaseRepository = databaseRepository;
            this.xmlFeedRepository = xmlFeedRepository;
        }

        [HttpGet]
        public async Task GetDataAsync()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync())
            {
                _events = xmlFeedRepository.GetFeedData();

                databaseRepository.SaveDatabaseChangess(_context, _events);
            }
        }
    }
}
