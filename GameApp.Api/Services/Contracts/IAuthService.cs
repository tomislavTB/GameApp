using System.Threading.Tasks;

namespace GameApp.Api.Services.Contracts
{
    public interface IAuthService : IAppService
    {
        Task<string> SignInAsync(string email, string password);
        Task<string> RegisterAsync(string email, string password);
    }
}