namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Usage
    {
        [JsonIgnore]
        public int UsageId { get; set; }
        public int CompletionTokens { get; set; }
        public int PromptTokens { get; set; }
        public int TotalTokens { get; set; }
        public int ReasoningTokens { get; set; }
        public int CachedTokens { get; set; }

        [JsonIgnore]
        public int ReturnId { get; set; }
    }
}
