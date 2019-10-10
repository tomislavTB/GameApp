using GameApp.Model.Users;

namespace GameApp.Api.Responses
{
    public class LoginResponse : AppResponse
    {
        public string Token { get; set; }

        public AuthUser User { get; set; }
    }
}