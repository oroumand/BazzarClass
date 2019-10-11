using Bazzar.Core.Domain.Advertisements.Events;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.Entieis;
using Framework.Domain.Events;
using System;

namespace Bazzar.Core.Domain.Advertisements.Entities
{
    public class Picture : BaseEntity<Guid>
    {
        #region Fields
        public PictureSize Size { get; private set; }
        public PictureUrl Location { get; private set; }
        public int Order { get; private set; }
        #endregion

        #region Constructors
        private Picture()
        {

        }
        public Picture(Action<IEvent> applier) : base(applier)
        {
        }
        #endregion

        #region Methods
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case PictureAddedToAdvertisment e:
                    Id = e.PictureId;
                    Location = PictureUrl.FromString(e.Url);
                    Size = new PictureSize(e.Height, e.Width);
                    Order = e.Order;
                    break;
                case AdvertismentPictureResized e:
                    Size = new PictureSize(e.Height, e.Width);
                    break;
            }
        }
        public void Resize(PictureSize newSize)
        {
            SetStateByEvent(new AdvertismentPictureResized
            {
                PictureId = Id,
                Height = newSize.Width,
                Width = newSize.Width
            });
        }
        #endregion
    }
}
