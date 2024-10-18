namespace AgentopsServer.Models
{
    using System.Text.Json.Serialization;

    public class Params
    {
        [JsonIgnore]
        public int ParamsId { get; set; }
        public string? Model { get; set; }
        public Boolean Stream { get; set; }

        [JsonIgnore]
        public Guid EventId { get; set; }
    }
}
