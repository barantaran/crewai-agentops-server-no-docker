namespace AgentopsServer.Models
{
    public class EventReturn
    {
        public string? EventReturnId { get; set; }
        public int EventId { get; set; }
        public string? Model { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
