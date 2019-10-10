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
    public class GoodGameService : BaseService, IGoodGameService
    {
        private readonly GameAppContext _context;

        public GoodGameService(
            GameAppContext context
        )
        {
            _context = context;
        }

        public async Task<PagedResult<GoodGameResponse>> GetPageAsync(GoodGamePaginationRequest request)
        {
            PagedResult<GoodGameResponse> pagedResult = await _context
                .GoodGames.AsQueryable()
                .Select(i => new GoodGameResponse
                {
                    Id = i.Id,
                    DatePlayed = i.DatePlayed

                })
                .ToPagedResultAsync(request);

            return pagedResult;
        }

        public async Task<GoodGameResponse> GetByIdAsync(int id)
        {
            return await _context
                .GoodGames
                .Select(i => new GoodGameResponse
                {
                    Id = i.Id,
                    DatePlayed = i.DatePlayed

                })
                .FirstAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var GoodGame = await _context
                .GoodGames
                .FindAsync(id);

            _context.GoodGames.Remove(GoodGame);
            return await _context.SaveChangesAsync();
        }

        public async Task<GoodGame> FindAsync(int id)
        {
            return await _context.GoodGames.FindAsync(id);
        }

        public async Task<int> PutGoodGame(GoodGame item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }


        public async Task<GoodGame> PostGoodGame(GoodGame item)
        {
            _context.GoodGames.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}