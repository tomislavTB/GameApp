using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameApp.Api.DB;
using GameApp.Api.Model.Users;
using GameApp.Api.Services.Contracts;

namespace GameApp.Api.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly GameAppContext Context;

        public UserService(GameAppContext context)
        {
            Context = context;
        }

        public async Task<AuthUser> getByEmailAsync(string email)
        {
            return await Context.Users
                .Where(u => u.Email == email)
                .Select(u => new AuthUser {
                    Id = u.Id,
                    Email = u.Email
                }).FirstAsync();
        }
    }
}