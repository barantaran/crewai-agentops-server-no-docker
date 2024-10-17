namespace AgentopsServer.Models
{
    public class Event
    {
        public string? EventId { get; set; }
        public string? AgentId { get; set; }
        public string? EventType { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public string? Model { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
