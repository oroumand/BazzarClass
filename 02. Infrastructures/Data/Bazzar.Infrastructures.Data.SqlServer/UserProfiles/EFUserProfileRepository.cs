using Bazzar.Core.Domain.UserProfiles.Data;
using Bazzar.Core.Domain.UserProfiles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bazzar.Infrastructures.Data.SqlServer.UserProfiles
{
    public class EFUserProfileRepository : IUserProfileRepository, IDisposable
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public EFUserProfileRepository(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public void Add(UserProfile entity)
        {
            advertismentDbContext.UserProfiles.Add(entity);
        }

        public void Dispose()
        {
            advertismentDbContext.Dispose();
        }

        public bool Exists(Guid id)
        {
            return advertismentDbContext.UserProfiles.Any(c => c.Id == id);
        }

        public UserProfile Load(Guid id)
        {
            return advertismentDbContext.UserProfiles.Find(id);
        }
    }
}
