using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Infrastructures.Data.Fake.Advertisments
{
    public class FakeAdvertisementsRepository : IAdvertisementsRepository
    {
        private readonly Dictionary<Guid, Advertisment> db = new Dictionary<Guid, Advertisment>();
        public bool Exists(Guid id)
        {
            return db.ContainsKey(id);
        }

        public Advertisment Load(Guid id)
        {
            return db[id];
        }

        public void Add(Advertisment entity)
        {
            db[entity.Id] = entity;
        }
    }
}
