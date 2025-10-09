using System;

namespace QueryService.Queries
{
    public class GetIncidentByIdQuery
    {
        public string IncidentId { get; }

        public GetIncidentByIdQuery(string incidentId)
        {
            IncidentId = incidentId;
        }
    }
}