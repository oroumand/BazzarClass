using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.UserProfiles.Events
{
    public class UserDisplayNameUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
