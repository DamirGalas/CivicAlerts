namespace IncidentService.Application.Commands
{
    public class ReportIncidentCommand
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public ReportIncidentCommand(string title, string? description)
        {
            Title = title;
            Description = description;
        }
    }
}
