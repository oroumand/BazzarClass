using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentPriceUpdated : IEvent
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }

}
