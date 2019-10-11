using Framework.Domain.ValueObjects;
using System;

namespace Bazzar.Core.Domain.Shared.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {

        public string Value { get; private set; }
        public static Email FromString(string value) => new Email(value);
        private Email()
        {

        }
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("برای ایمیل مقدار لازم است", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Email otherObject) => Value == otherObject.Value;

        public static implicit operator string(Email email) => email.Value;
    }
}
