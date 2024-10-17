using AgentopsServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgentopsServer.Controllers
{
    [ApiController]
    [Route("V1")]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentSessionController> _logger;
        private readonly AgentServerDbContext _context;

        public AgentsController(ILogger<AgentSessionController> logger, AgentServerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("agentsAll")]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            return await _context.Agents.ToListAsync();
        }

        [HttpGet("agent/{id}")]
        public async Task<ActionResult<Agent>> GetAgent(int id)
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents.FindAsync(id);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        [HttpPost("create_agent")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Agent))]
        public async Task<ActionResult<Agent>> PostAgent(Agent agent)
        {
            if (_context.Agents == null)
            {
                return Problem("Entity set 'AgentServerDbContext.Agents'  is null.");
            }
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { id = agent.AgentId }, agent);
        }
    }
}
