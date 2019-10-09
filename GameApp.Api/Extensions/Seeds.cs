using System;
using Microsoft.EntityFrameworkCore;
using GameApp.Models;

namespace StudentiProject.Extensions
{
    public static class Seeds
    {
        public static void Seed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            Games(modelBuilder);
            Players(modelBuilder);
            GoodGames(modelBuilder);
        }




        public static void Games(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Game>().HasData(new Game { Id = 1, GameName = "Rizik", Extensions = "DA" });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 2, GameName = "Monopoly", Extensions = "NE" });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 3, GameName = "Catan", Extensions = "DA" });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 4, GameName = "Azul", Extensions = "DA" });
            modelBuilder.Entity<Game>().HasData(new Game { Id = 5, GameName = "Bela", Extensions = "NE" });

        }

        public static void GoodGames(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)


        {

            modelBuilder.Entity<GoodGame>().HasData(new GoodGame { Id = 1, GameId = 1, PlayerId = 1, DatePlayed = "05.04.2019" });
            modelBuilder.Entity<GoodGame>().HasData(new GoodGame { Id = 2, GameId = 2, PlayerId = 2, DatePlayed = "16.05.2018" });
            modelBuilder.Entity<GoodGame>().HasData(new GoodGame { Id = 3, GameId = 1, PlayerId = 4, DatePlayed = "14.06.2019" });
            modelBuilder.Entity<GoodGame>().HasData(new GoodGame { Id = 4, GameId = 2, PlayerId = 3, DatePlayed = "05.11.2018" });
            modelBuilder.Entity<GoodGame>().HasData(new GoodGame { Id = 5, GameId = 3, PlayerId = 5, DatePlayed = "16.07.2019" });
        }


        public static void Players(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Player>().HasData(new Player { Id = 1, FirstName = "Tomislav ", LastName = "Buhovac", Wins = 1, Loses = 1 });
            modelBuilder.Entity<Player>().HasData(new Player { Id = 2, FirstName = "Marko ", LastName = "Markic", Wins = 2, Loses = 2 });
            modelBuilder.Entity<Player>().HasData(new Player { Id = 3, FirstName = "Ivan ", LastName = "Ivic", Wins = 3, Loses = 2 });
            modelBuilder.Entity<Player>().HasData(new Player { Id = 4, FirstName = "Josip ", LastName = "Nesto", Wins = 4, Loses = 2 });
            modelBuilder.Entity<Player>().HasData(new Player { Id = 5, FirstName = "Filip ", LastName = "Novi", Wins = 5, Loses = 2 });
        }

      
    }
}
