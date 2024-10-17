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

        public EventsController(ILogger<AgentSessionController> logger, AgentServerDbContext context)
        {
            _logger = logger;
            _context = context;
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
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
          if (_context.Events == null)
          {
              return Problem("Entity set 'AgentServerDbContext.Events'  is null.");
          }
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }
    }
}
