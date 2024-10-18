namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Completion
    {
        [JsonIgnore]
        public int CompletionId { get; set; }
        public string? Content { get; set; }
        public string? Role { get; set; }
        
        [JsonIgnore]
        public Guid EventId { get; set; }
    }
}
