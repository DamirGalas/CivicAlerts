using Common.Dtos;

namespace QueryService.Queries
{
    public class GetIncidentsQuery
    {
        public string? Status { get; }

        public GetIncidentsQuery(string? status = null)
        {
            Status = status;
        }
    }
}