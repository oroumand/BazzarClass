using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bazzar.Infrastructures.Data.SqlServer.Advertisments
{
    public class EfAdvertisementsRepository : IAdvertisementsRepository, IDisposable
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public EfAdvertisementsRepository(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }

        public void Dispose()
        {
            advertismentDbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return advertismentDbContext.Advertisments.Any(c => c.Id == id);
        }

        public Advertisment Load(Guid id)
        {
            return advertismentDbContext.Advertisments.Find(id);
        }

        public void Add(Advertisment entity)
        {
            advertismentDbContext.Advertisments.Add(entity);

        }
    }
}
