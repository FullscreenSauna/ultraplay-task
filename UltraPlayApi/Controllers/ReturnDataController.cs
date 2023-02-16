using Microsoft.AspNetCore.Mvc;
using UltraPlayApi.Mappers;
using UltraPlayApi.Interfaces;
using UltraPlayApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using UltraPlayApi.DatabaseViews;
using System.Collections.Generic;

namespace UltraPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnDataController : ControllerBase
    {
        private readonly UltraPlayContext _context;

        public ReturnDataController(UltraPlayContext _context)
        {
            this._context = _context;
        }

        [HttpPost]
        [SwaggerResponse(200, "Success", typeof(List<AllFutureMarkets>))]
        public IActionResult GetAllFutureMatches()
        {
            var responseList = _context.AllFutureMarkets.ToList();

            return Ok(responseList);
        }
    }
}
