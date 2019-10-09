using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameApp.Models;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Services.Contracts
{
    public interface IGameService
    {
        Task<PagedResult<GameResponse>> GetPageAsync(GamePaginationRequest request);
        Task<GameResponse> GetByIdAsync(int id);

        Task<int> DeleteByIdAsync(int id);

        Task<Game> FindAsync(int id);
        Task<int> PutGame(Game item);
        Task<Game> PostGame(Game item);
    }
}