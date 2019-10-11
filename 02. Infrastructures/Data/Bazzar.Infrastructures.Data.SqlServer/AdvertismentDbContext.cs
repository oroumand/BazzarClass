using Bazzar.Core.Domain.Advertisements.Entities;
using Framework.Domain.Data;
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

    }

    public class AdvertismentUnitOfWork : IUnitOfWork
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public AdvertismentUnitOfWork(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public int Commit()
        {
            return advertismentDbContext.SaveChanges();
        }
    }
}
