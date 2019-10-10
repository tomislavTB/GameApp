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
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.Api.Services
{
    public class GameService : BaseService, IGameService
    {
        private readonly GameAppContext _context;

        public GameService(
            GameAppContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<GameResponse>> GetPageAsync(GamePaginationRequest request)
        {
            PagedResult<GameResponse> pagedResult = await _context
                .Games.AsQueryable()
                .Select(i => new GameResponse
                {
                    Id = i.Id,
                    GameName = i.GameName

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<GameResponse> GetByIdAsync(int id)
        {
            return await _context
                .Games
                .Select(i => new GameResponse
                {
                    Id = i.Id,
                    GameName = i.GameName

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var game = await _context
                .Games
                .FindAsync(id);

            _context.Games.Remove(game);
            return await _context.SaveChangesAsync();
        }

        public async Task<Game> FindAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<int> PutGame(Game item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<Game> PostGame(Game item)
        {
            _context.Games.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
