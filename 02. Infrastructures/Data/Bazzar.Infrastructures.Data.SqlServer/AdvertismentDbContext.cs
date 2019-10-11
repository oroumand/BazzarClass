using Bazzar.Core.Domain.Advertisements.Entities;
using Bazzar.Core.Domain.UserProfiles.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bazzar.Infrastructures.Data.SqlServer
{
    public class AdvertismentDbContext : DbContext
    {
        public AdvertismentDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }

        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
