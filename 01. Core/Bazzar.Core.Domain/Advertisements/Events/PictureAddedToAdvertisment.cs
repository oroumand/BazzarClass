using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Events
{
    public class PictureAddedToAdvertisment:IEvent
    {
        public Guid ClassifiedAdId { get; set; }
        public Guid PictureId { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
