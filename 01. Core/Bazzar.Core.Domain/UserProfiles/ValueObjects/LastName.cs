using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Core.Domain.UserProfiles.ValueObjects
{
    public class LastName : BaseValueObject<LastName>
    {

        public string Value { get; private set; }
        public static LastName FromString(string value) => new LastName(value);
        private LastName()
        {

        }
        public LastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای نام‌خانوادگی مقدار لازم است", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(LastName otherObject) => Value == otherObject.Value;

        public static implicit operator string(LastName lastName) => lastName.Value;
    }
}
