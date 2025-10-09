namespace Common.Dtos
{
    public class IncidentDto
    {
        public string Id { get; set; } // unique identifier
        public string Title { get; set; } // required
        public string? Description { get; set; } // optional
        public string Category { get; set; } // e.g., Lighting, Road Damage, Pollution
        public string Location { get; set; } // coordinates or address
        public string Reporter { get; set; } // user name or ID
    }
}
