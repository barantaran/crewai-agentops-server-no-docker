namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Message
    {
        [JsonIgnore]
        public int MessageId { get; set; }
        public string? Content { get; set; }
        public string? Role { get; set; }
        public string? ToolCalls { get; set; } //TODO: Looks like could have children
        public string? FunctionCall { get; set; }
        
        [JsonIgnore]
        public int ChoiseId { get; set; }
    }
}
