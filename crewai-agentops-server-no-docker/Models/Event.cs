namespace AgentopsServer.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int AgentId { get; set; }
        public string? EventType { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public string? Model { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
