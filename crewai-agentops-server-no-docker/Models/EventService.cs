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
                /* Save Event */
                var newEvent = new Event
                {
                    EventType = eventData.EventType,
                    InitTimestamp = eventData.InitTimestamp,
                    EndTimestamp = eventData.EndTimestamp,
                    AgentExtGuid = eventData.AgentExtGuid,
                    EventExtGuid = eventData.EventExtGuid,
                    PromptTokens = eventData.PromptTokens,
                    CompletionTokens = eventData.CompletionTokens,
                    Model = eventData.Model
                };

                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();

                /* Save Param */
                var newParams = new Param
                {
                    Model = eventData.Params.Model,
                    Stream = eventData.Params.Stream,
                    EventId = newEvent.EventId
                };
                _context.Params.Add(newParams);

                #region Save Event.Returns
                var newReturns = new Return {
                    ReturnExternalId = eventData.Returns.ReturnExternalId,
                    Created = eventData.Returns.Created,
                    Model = eventData.Returns.Model,
                    Object = eventData.Returns.Object,
                    ServiceTier = eventData.Returns.ServiceTier,
                    EventId = newEvent.EventId,
                };
                _context.Returns.Add(newReturns);
                await _context.SaveChangesAsync();

                /* Save Event.Returns.Choices */
                foreach (var choice in eventData.Returns.Choices)
                {
                    var newChoice = new Choice
                    {
                        FinishReason = choice.FinishReason,
                        Index = choice.Index,
                        ReturnId = newReturns.ReturnId
                    };

                    _context.Choices.Add(newChoice);
                    await _context.SaveChangesAsync();

                    var newMessage = new Message
                    {
                        Content = choice.Message.Content,
                        Role = choice.Message.Role,
                        ToolCalls = choice.Message.ToolCalls,
                        FunctionCall = choice.Message.FunctionCall,
                        ChoiseId = newChoice.ChoiceId
                    };
                    _context.Messages.Add(newMessage);
                }
                /* End Save Event.Returns.Choices */

                /* Save Event.Returns.Usage */
                var newUsage = new Usage
                {
                    CompletionTokens = eventData.Returns.Usage.CompletionTokens,
                    PromptTokens = eventData.Returns.Usage.PromptTokens,
                    TotalTokens = eventData.Returns.Usage.TotalTokens,
                    ReasoningTokens = eventData.Returns.Usage.ReasoningTokens,
                    CachedTokens = eventData.Returns.Usage.CachedTokens,
                    ReturnId = newReturns.ReturnId
                };
                _context.Add(newUsage);
                /* End Save Event.Returns.Usage */

                #endregion

                #region Save Event.Propmpt
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
                #endregion

                /* Save Event.Completion */
                var newCompletion = new Completion
                {
                    Content = eventData.Completion.Content,
                    Role = eventData.Completion.Role,
                    EventId = newEvent.EventId
                };
                _context.Completions.Add(newCompletion);
                /* End Save Event.Completion */

                await _context.SaveChangesAsync();

                createdEvents.Add(newEvent);
            }

            return createdEvents;
        }
    }
}
