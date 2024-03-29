﻿using GameApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using GameApp.Api.Extensions;
using System;
using GameApp.Api.Extensions.ModelBuilder;
using GameApp.Models.Interfaces;
using GameApp.Api.Extensions.NewContext;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameApp.Model.Users;

namespace GameApp.Api.DB
{
    public class GameAppContext : IdentityDbContext<AuthUser, IdentityRole<int>, int>
    {
        public GameAppContext(DbContextOptions<GameAppContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GoodGame> GoodGames { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            OnBeforeOnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);




        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }




        private void OnBeforeOnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ValidationSetup();
            modelBuilder.ManyToManySetup();
            modelBuilder.Seed();
            modelBuilder.SoftDeleteSetup();


        }

        private void OnBeforeSaving()
        {
            this.UpdateBaseDateable();
            this.UpdateSoftDeletable();

        }

       
       


    }
}