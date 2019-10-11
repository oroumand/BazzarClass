using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class AdvertismentText : BaseValueObject<AdvertismentText>
    {

        public string Value { get; private set; }
        public static AdvertismentText FromString(string value) => new AdvertismentText(value);
        private AdvertismentText()
        {

        }
        public AdvertismentText(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای متن آگهی مقدار لازم است", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(AdvertismentText otherObject) => Value == otherObject.Value;

        public static implicit operator string(AdvertismentText advertismentText) => advertismentText.Value;
    }
}
