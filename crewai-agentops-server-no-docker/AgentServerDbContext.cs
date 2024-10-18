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
        public DbSet<Prompt> Prompts { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Completion> Completions { get; set; }
    }
}
