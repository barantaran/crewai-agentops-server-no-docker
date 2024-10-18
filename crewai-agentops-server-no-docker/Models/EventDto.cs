namespace AgentopsServer.Models
{
    public class EventDto
    {
        public string? AgentId { get; set; }
        public string? EventType { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public List<PromptDto>? Prompt { get; set; }
        public Params? Params { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
