using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentSentForReview : IEvent
    {
        public Guid Id { get; set; }
    }
}
