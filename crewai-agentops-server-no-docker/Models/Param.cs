namespace AgentopsServer.Models
{
    using Newtonsoft.Json;

    public class Param
    {
        [JsonIgnore]
        public int ParamId { get; set; }
        public string? Model { get; set; }
        public Boolean Stream { get; set; }

        [JsonIgnore]
        public Guid EventId { get; set; }
    }
}
