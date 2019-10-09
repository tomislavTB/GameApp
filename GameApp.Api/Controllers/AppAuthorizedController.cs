using Microsoft.AspNetCore.Authorization;

namespace GameApp.Api.Controllers
{
    [Authorize]
    public class AppAuthorizedController : AppController
    {
        
    }
}