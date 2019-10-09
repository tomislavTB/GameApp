using System.Linq;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Requests
{
    public class PlayerPaginationRequest : AbstractPagingRequest<PlayerResponse>
    {
        private const string ValidOrderByValues = "lastName";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string LastName { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<PlayerResponse> GetFilteredQuery(IQueryable<PlayerResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                query = query.Where(i => i.LastName.Contains(LastName));
            }

            return query;
        }

        public override IQueryable<PlayerResponse> SetUpSorting(IQueryable<PlayerResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "lastName":
                        query = ApplyOrdering(query, dtc => dtc.LastName, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}