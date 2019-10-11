using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.UserProfiles.Events
{
    public class UserEmailUpdated : IEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
