using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rihal.challenge.Domain.Entities;
using rihal.challenge.Domain.Entities.AuthenticationAggregate;
using System;
using System.Reflection;

namespace rihal.challenge.Persistence.DbContexts
{
    public partial class rihalchallengeDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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