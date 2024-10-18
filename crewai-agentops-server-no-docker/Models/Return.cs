namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Return
    {
        [JsonIgnore]
        public int ReturnId { get; set; }

        [JsonProperty("id")]
        public string? ReturnExternalId { get; set; }
        public ICollection<Choice>? Choices { get; set; }
        public int Created { get; set; }
        public string? Model { get; set; }
        public string? Object { get; set; }
        public Usage? Usage { get; set; }
        public string? ServiceTier { get; set; }

        [JsonIgnore]
        public Guid EventId { get; set; }
    }
}
