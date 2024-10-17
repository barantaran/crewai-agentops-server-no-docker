namespace AgentopsServer.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string? EventExtGuid { get; set; }
        public string? AgentExtGuid { get; set; }
        public string? EventType { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public string? Model { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
