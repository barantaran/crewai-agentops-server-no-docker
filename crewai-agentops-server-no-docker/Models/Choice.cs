namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Choice
    {
        [JsonIgnore]
        public int ChoiceId { get; set; }
        public string? FinishReason { get; set; }
        public int Index { get; set; }
        public Message? Message { get; set; }

        [JsonIgnore]
        public int ReturnId { get; set; }
    }
}
