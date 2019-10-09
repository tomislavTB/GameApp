
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameApp.Models;

namespace GameApp.Api.Extensions
{
    public static class ManyToMany
    {

        public static void ManyToManySetup(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            GoodGame(modelBuilder);
        }



        private static void GoodGame(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<GoodGame>()
                    .HasOne<Player>(sc => sc.Player)
                    .WithMany(s => s.GoodGames)
                    .HasForeignKey(sc => sc.PlayerId);


            modelBuilder.Entity<GoodGame>()
                    .HasOne<Game>(sc => sc.Game)
                    .WithMany(s => s.GoodGames)
                    .HasForeignKey(sc => sc.GameId);
        }
    }
}
