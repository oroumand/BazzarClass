using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentTitleChanged : IEvent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
