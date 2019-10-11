using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Core.Domain.UserProfiles.ValueObjects
{
    public class DisplayName : BaseValueObject<DisplayName>
    {

        public string Value { get; private set; }
        public static DisplayName FromString(string value) => new DisplayName(value);
        private DisplayName()
        {

        }
        public DisplayName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای نام نمایشی مقدار لازم است", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(DisplayName otherObject) => Value == otherObject.Value;

        public static implicit operator string(DisplayName displayName) => displayName.Value;
    }
}
