using Microsoft.AspNetCore.Identity;

namespace GameApp.Api.Responses
{
    public class RegisterResponse : AppResponse
    {
        public string Token { get; set; }
        public AuthUserResponse User { get; set; }
    }
}