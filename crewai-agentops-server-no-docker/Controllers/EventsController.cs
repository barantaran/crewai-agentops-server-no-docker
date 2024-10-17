using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgentopsServer;
using AgentopsServer.Models;

namespace AgentopsServer.Controllers
{
    [ApiController]
    [Route("V1")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<AgentSessionController> _logger;
        private readonly AgentServerDbContext _context;
        private readonly EventService _eventService;

        public EventsController(ILogger<AgentSessionController> logger, AgentServerDbContext context, EventService eventService)
        {
            _logger = logger;
            _context = context;
            _eventService = eventService;
        }

        // GET: api/Events/5
        [HttpGet("event/{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
          if (_context.Events == null)
          {
              return NotFound();
          }
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create_events")]
        public async Task<IActionResult> PostEvent([FromBody] EventRequest eventRequest)
        {
            if (eventRequest == null || eventRequest.Events == null || !eventRequest.Events.Any())
            {
                return BadRequest("Event data is required.");
            }

            try
            {
                var newEvents = await _eventService.CreateEventsAsync(eventRequest);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create events: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the events.");
            }
        }
    }
}
