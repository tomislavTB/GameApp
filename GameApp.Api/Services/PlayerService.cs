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
    public class PlayerService : BaseService, IPlayerService
    {
        private readonly GameAppContext _context;

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

        public async Task<PlayerResponse> GetByIdAsync(int id)
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

        public async Task<int> DeleteByIdAsync(int id)
        {
            var player = await _context
                .Players
                .FindAsync(id);

            _context.Players.Remove(player);
            return await _context.SaveChangesAsync();
        }

        public async Task<Player> FindAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<int> PutPlayer(Player item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<Player> PostPlayer(Player item)
        {
            _context.Players.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}