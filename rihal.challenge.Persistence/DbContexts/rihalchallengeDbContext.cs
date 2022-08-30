using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rihal.challenge.Domain.Entities;
using System;
using System.Reflection;

namespace rihal.challenge.Persistence.DbContexts
{
    public partial class rihalchallengeDbContext : DbContext
    {
        public rihalchallengeDbContext(DbContextOptions<rihalchallengeDbContext> options)
        : base(options) { }


      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}