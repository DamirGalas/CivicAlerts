namespace Common.Events
{
    public class IncidentStatusChangedEvent
    {
        public string IncidentId { get; set; } = default!;
        public string NewStatus { get; set; } = default!;
        public DateTime ChangedAt { get; set; }
    }
}