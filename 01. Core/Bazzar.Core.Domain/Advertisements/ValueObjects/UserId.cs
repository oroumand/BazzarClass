using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class UserId : BaseValueObject<UserId>
    {
        public Guid Value { get; private set; }
        private UserId()
        {

        }
        public static UserId FromString(string value) => new UserId(Guid.Parse(value));
        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentException("شناسه کاربر نمی‌تواند خالی باشد", nameof(value));
            Value = value;
        }
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(UserId otherObject)
        {
            return Value == otherObject.Value;
        }
        public static implicit operator Guid(UserId userId) => userId.Value;
    }
}
