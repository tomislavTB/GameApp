using GameApp.Models;
using System.Reflection;

namespace GameApp.Api.Extensions
{
    public static class SoftDeleteSetupExtension
    {
        public static void SoftDeleteSetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            SetupQueryFilter<Game>(modelBuilder);
            SetupQueryFilter<Player>(modelBuilder);
            SetupQueryFilter<GoodGame>(modelBuilder);
        }

        private static void SetupQueryFilter<TEntity>(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
            where TEntity : BaseModel
        {
            if (typeof(BaseModel).GetTypeInfo().IsAssignableFrom(typeof(TEntity).Ge‌​tTypeInfo()))
            {
                modelBuilder.Entity<TEntity>().HasQueryFilter(temp => !temp.IsDeleted);
            }
        }
    }
} 