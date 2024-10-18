using Newtonsoft.Json;

namespace AgentopsServer.Models
{
    public class EventDto
    {
        public string? EventType { get; set; }
        public Params? Params { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public string? AgentExtGuid { get; set; }
        public string? EventExtGuid { get; set; }
        public List<PromptDto>? Prompt { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public string? Model { get; set; }
    }
}
