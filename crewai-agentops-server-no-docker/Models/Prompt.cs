namespace AgentopsServer.Models
{
    public class Prompt
    {
        public int PromptId { get; set; }
        public string? Role { get; set; }
        public string? Content { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}
