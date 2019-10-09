using System.Threading.Tasks;
using GameApp.Models;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Api.Shared.Pagination;

namespace GameApp.Api.Services.Contracts
{
    public interface IPlayerService
    {
        Task<PagedResult<PlayerResponse>> GetPageAsync(PlayerPaginationRequest request);
        Task<PlayerResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);
        Task<int> PutPlayer(Player item);
        Task<Player> FindAsync(int id);
        Task<Player> PostPlayer(Player item);
    }
}