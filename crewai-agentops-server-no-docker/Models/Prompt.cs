namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Prompt
    {
        [JsonIgnore]
        public int PromptId { get; set; }
        public string? Role { get; set; }
        public string? Content { get; set; }
        
        [JsonIgnore]
        public Guid EventId { get; set; }
    }
}
