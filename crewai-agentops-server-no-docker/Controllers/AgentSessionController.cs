using AgentopsServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentopsServer.Controllers
{
    [ApiController]
    [Route("V1")]
    public class AgentSessionController : ControllerBase
    {
        private readonly ILogger<AgentSessionController> _logger;
        private readonly AgentServerDbContext _context;

        public AgentSessionController(ILogger<AgentSessionController> logger, AgentServerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<AgentSession>> Get()
        {
            return await _context.AgentSessions.ToListAsync();
        }
        
        [HttpPost("create_agent", Name = "create_agent")]
        public async Task<ActionResult<Agent>> CreateAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = agent.AgentId }, agent);
        }

        [HttpPost("create_session", Name = "create_session")]
        public async Task<ActionResult<AgentSession>> CreateSession(AgentSession session)
        {
            _context.AgentSessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = session.AgentSessionId }, session);
        }

        [HttpPost("update_session", Name = "update_session")]
        public async Task<ActionResult<AgentSession>> UpdateSession(AgentSession session)
        {
            _context.AgentSessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = session.AgentSessionId }, session);
        }
    }
}
