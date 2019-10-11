using Bazzar.Core.Domain.Advertisements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementsRepository
    {
        bool Exists(Guid id);

        Advertisment Load(Guid id);

        void Add(Advertisment entity);
    }
}
