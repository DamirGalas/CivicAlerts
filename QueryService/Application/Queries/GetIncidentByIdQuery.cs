using System;

namespace QueryService.Queries
{
    public class GetIncidentByIdQuery
    {
        public Guid IncidentId { get; }

        public GetIncidentByIdQuery(Guid incidentId)
        {
            IncidentId = incidentId;
        }
    }
}