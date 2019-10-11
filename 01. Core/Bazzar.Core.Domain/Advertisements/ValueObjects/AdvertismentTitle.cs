using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertismentTitle:BaseValueObject<AdvertismentTitle>
    {
        public string Value { get; private set; }
        public static AdvertismentTitle FromString(string value) => new AdvertismentTitle(value);

        private AdvertismentTitle()
        {

        }
        public AdvertismentTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای عنوان آگهی مقدار لازم است", nameof(value));
            }
            if (value.Length > 100)
            {
                throw new ArgumentOutOfRangeException("عنوان آگهی نباید بیش از 100 کاراکتر باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(AdvertismentTitle otherObject) => Value == otherObject.Value;

        public static implicit operator string(AdvertismentTitle advertismentTitle) => advertismentTitle.Value;
    }
}
