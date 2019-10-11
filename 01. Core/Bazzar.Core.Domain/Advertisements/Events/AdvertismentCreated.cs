using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentCreated : IEvent
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
    }

}
