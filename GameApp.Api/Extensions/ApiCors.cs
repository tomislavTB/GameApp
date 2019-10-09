using Microsoft.Extensions.DependencyInjection;

namespace GameApp.Api.Extensions
{
    public static class ApiCors
    {
        public static void AddApiCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }
    }
}