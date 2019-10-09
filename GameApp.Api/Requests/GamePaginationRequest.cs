using System.Linq;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Requests
{
    public class GamePaginationRequest : AbstractPagingRequest<GameResponse>
    {
        private const string ValidOrderByValues = "gameName";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string GameName { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<GameResponse> GetFilteredQuery(IQueryable<GameResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(GameName))
            {
                query = query.Where(i => i.GameName.Contains(GameName));
            }

            return query;
        }

        public override IQueryable<GameResponse> SetUpSorting(IQueryable<GameResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "gameName":
                        query = ApplyOrdering(query, dtc => dtc.GameName, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}