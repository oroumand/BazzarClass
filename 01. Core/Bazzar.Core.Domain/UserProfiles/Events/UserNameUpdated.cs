using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.UserProfiles.Events
{
    public class UserNameUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
