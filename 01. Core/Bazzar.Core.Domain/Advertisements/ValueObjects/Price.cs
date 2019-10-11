using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class Price : BaseValueObject<Price>
    {
        public Rial Value { get; private set; }
        public static Price FromString(string value) => new Price(Rial.FromString(value));
        public static Price FromLong(long value) => new Price(Rial.FromLong(value));
        private Price()
        {

        }
        public Price(Rial rial)
        {
            if (rial < 1)
            {
                throw new ArgumentOutOfRangeException("مقدار قیمت کمتر از 1 ریال نمی‌تواند باشد", nameof(Price));
            }
            Value = rial;
        }
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(Price otherObject)
        {
            return Value == otherObject.Value;
        }
        public static implicit operator long(Price price) => price.Value;
    }
}
