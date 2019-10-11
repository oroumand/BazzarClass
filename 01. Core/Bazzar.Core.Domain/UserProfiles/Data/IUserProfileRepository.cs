using Bazzar.Core.Domain.UserProfiles.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.UserProfiles.Data
{
    public interface IUserProfileRepository
    {
        UserProfile Load(Guid id);
        void Add(UserProfile entity);
        bool Exists(Guid id);
    }
}
