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
            var createdEvents = new List<Event>();

            foreach (var eventData in eventRequest.Events)
            {
                var newEvent = new Event
                {
                    EventType = eventData.EventType,
                };

                // Save event to get the EventId
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();

                // Now store the associated prompts
                foreach (var prompt in eventData.Prompt)
                {
                    var newPrompt = new Prompt
                    {
                        Role = prompt.Role,
                        Content = prompt.Content,
                        EventId = newEvent.EventId
                    };

                    _context.Prompts.Add(newPrompt);
                }

                var newParams = new Params
                {
                    Model = eventData.Params.Model,
                    Stream = eventData.Params.Stream,
                    EventId = newEvent.EventId
                };

                _context.Params.Add(newParams);

                await _context.SaveChangesAsync();

                createdEvents.Add(newEvent);
            }

            return createdEvents;
        }
    }
}
