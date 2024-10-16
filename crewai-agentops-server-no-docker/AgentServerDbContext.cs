namespace AgentopsServer
{
    using AgentopsServer.Models;
    using Microsoft.EntityFrameworkCore;

    public class AgentServerDbContext : DbContext
    {
        public AgentServerDbContext(DbContextOptions<AgentServerDbContext> options) : base(options) { }

        public DbSet<AgentSession> AgentSessions { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventReturn> EventReturns { get; set; }
    }
}
