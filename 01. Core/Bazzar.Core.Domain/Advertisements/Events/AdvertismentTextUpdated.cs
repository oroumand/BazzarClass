using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentTextUpdated : IEvent
    {
        public Guid Id { get; set; }
        public string AdvertismentText { get; set; }
    }

}
