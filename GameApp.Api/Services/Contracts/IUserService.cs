using System.Threading.Tasks;
using GameApp.Model.Users;

namespace GameApp.Api.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthUser> getByEmailAsync(string email);
    }
}