using GameApp.Models;

namespace GameApp.Api.Extensions.ModelBuilder
{
    public static class ModelBuilderValidation
    {
        public static void ValidationSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            User(modelBuilder);
        }
    }
}
