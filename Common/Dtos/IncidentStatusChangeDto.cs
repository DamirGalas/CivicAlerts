namespace Common.Dtos
{
    public class IncidentStatusChangeDto
    {
        public required string IncidentId { get; set; }
        public required string NewStatus { get; set; }
    }
}
