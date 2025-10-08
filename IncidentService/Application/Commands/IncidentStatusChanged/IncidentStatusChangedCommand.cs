namespace IncidentService.Application.Commands.IncidentStatusChanged
{
    public class IncidentStatusChangedCommand
    {
        public string IncidentId { get; set; }
        public string NewStatus { get; set; }

        public IncidentStatusChangedCommand(string incidentId, string newStatus)
        {
            IncidentId = incidentId;
            NewStatus = newStatus;
        }
    }
}
