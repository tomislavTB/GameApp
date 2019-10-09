using System.Threading.Tasks;
using GameApp.Models;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Services.Contracts
{
    public interface IGoodGameService
    {
        Task<PagedResult<GoodGameResponse>> GetPageAsync(GoodGamePaginationRequest request);
        Task<GoodGameResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<GoodGame> PostGoodGame(GoodGame item);
        Task<int> PutGoodGame(GoodGame item);
        Task<GoodGame> FindAsync(int id);
    }
}