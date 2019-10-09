using System.Linq;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Requests
{
    public class GoodGamePaginationRequest : AbstractPagingRequest<GoodGameResponse>
    {
        private const string ValidOrderByValues = "datePlayed";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string DatePlayed { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<GoodGameResponse> GetFilteredQuery(IQueryable<GoodGameResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(DatePlayed))
            {
                query = query.Where(i => i.DatePlayed.Contains(DatePlayed));
            }

            return query;
        }

        public override IQueryable<GoodGameResponse> SetUpSorting(IQueryable<GoodGameResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "datePlayed":
                        query = ApplyOrdering(query, dtc => dtc.DatePlayed, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}