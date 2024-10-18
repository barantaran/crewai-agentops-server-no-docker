namespace AgentopsServer.Models
{
    using Newtonsoft.Json;
    public class Event
    {
        [JsonIgnore]
        public Guid EventId { get; set; }
        public string? EventType { get; set; }
        public Params? Params { get; set; }
        public Return? Returns { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }

        [JsonProperty("agent_id")]
        public string? AgentExtGuid { get; set; }

        [JsonProperty("id")]
        public string? EventExtGuid { get; set; }
        public ICollection<Prompt>? Prompt { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public string? Model { get; set; }
    }
}
