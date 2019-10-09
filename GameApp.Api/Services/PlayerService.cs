using System.Threading.Tasks;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Api.DB;
using GameApp.Shared.Pagination;
using System.Linq;
using GameApp.Shared.Extensions;
using GameApp.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using GameApp.Api.Services;

namespace GameApp.Api.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        private readonly GameApp.Context _context;

        public PlayerService(
            GameAppContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<PlayerResponse>> GetPageAsync(PlayerPaginationRequest request)
        {
            PagedResult<PlayerResponse> pagedResult = await _context
                .Players.AsQueryable()
                .Select(i => new PlayerResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<PlayerResponse> GetByIdAsync(long id)
        {
            return await _context
                .Players
                .Select(i => new PlayerResponse
                {
                    Id = i.Id,
                    LastName = i.LastName

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(long id)
        {
            var player = await _context
                .Students
                .FindAsync(id);

            _context.Students.Remove(player);
            return await _context.SaveChangesAsync();
        }

    }
}