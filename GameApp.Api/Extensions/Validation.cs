using GameApp.Models;

namespace GameApp.Api.Extensions.ModelBuilder
{
    public static class ModelBuilderValidation
    {
        public static void ValidationSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            User(modelBuilder);
        }

        private static void User(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                 .HasIndex(p => new { p.FirstName, p.LastName })
                .IsUnique(true);


        }
    }
}
