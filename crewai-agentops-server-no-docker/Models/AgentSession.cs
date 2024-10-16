namespace AgentopsServer.Models
{
    public class AgentSession
    {
        public int AgentSessionId { get; set; }
        public int AgentId { get; set; }
        public DateTime? InitTimestamp { get; set; }
        public DateTime? EndTimestamp { get; set; }
        public string? EndState { get; set; }
        public string? EndStateReason { get; set; }
    }
}
