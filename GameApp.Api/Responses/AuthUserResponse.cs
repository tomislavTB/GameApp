using Microsoft.AspNetCore.Identity;

namespace GameApp.Api.Responses
{
    public class AuthUserResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
    }
}