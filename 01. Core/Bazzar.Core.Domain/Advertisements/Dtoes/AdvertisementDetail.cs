using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Dtoes
{
    public class AdvertisementDetail
    {
        public Guid AdvertisementId { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public string Text { get; set; }
        public string SellersDisplayName { get; set; }
        public string PhotoUrls { get; set; }
    }
}
