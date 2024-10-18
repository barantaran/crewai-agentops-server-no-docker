namespace AgentopsServer.Models
{
    using Newtonsoft.Json;
    public class Event
    {
        [JsonIgnore]
        public Guid EventId { get; set; }

        [JsonProperty("id")]
        public string? EventExtGuid { get; set; }

        [JsonProperty("agent_id")]
        public string? AgentExtGuid { get; set; }
        public string? EventType { get; set; }
        public DateTime InitTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public string? Model { get; set; }
        public ICollection<Prompt>? Prompts { get; set; }
        public Params? Params { get; set; }
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
    }
}
