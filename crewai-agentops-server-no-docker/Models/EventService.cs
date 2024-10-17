using AgentopsServer.Models;
using AgentopsServer;

namespace AgentopsServer.Models
{
    public class EventService
    {
        private readonly AgentServerDbContext _context;
        private readonly ILogger<EventService> _logger;

        public EventService(AgentServerDbContext context, ILogger<EventService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Event>> CreateEventsAsync(EventRequest eventRequest)
        {
            var newEvents = new List<Event>();

            foreach (var ev in eventRequest.Events)
            {
                var newEvent = new Event
                {
                    AgentId = ev.AgentId,
                    EventType = ev.EventType,
                    InitTimestamp = ev.InitTimestamp,
                    EndTimestamp = ev.EndTimestamp,
                    PromptTokens = ev.PromptTokens,
                    CompletionTokens = ev.CompletionTokens,
                };

                newEvents.Add(newEvent);
            }

            _context.Events.AddRange(newEvents);
            await _context.SaveChangesAsync();

            return newEvents;
        }
    }
}
