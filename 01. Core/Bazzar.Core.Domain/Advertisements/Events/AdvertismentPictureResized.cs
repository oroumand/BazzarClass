using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class AdvertismentPictureResized: IEvent
    {
        public Guid PictureId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
