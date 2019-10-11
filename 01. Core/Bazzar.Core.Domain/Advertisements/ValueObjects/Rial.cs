using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.ValueObjects
{
    public class Rial : BaseValueObject<Rial>
    {
        public long Value { get; private set; }
        public static Rial FromString(string value) => new Rial(long.Parse(value));
        public static Rial FromLong(long value) => new Rial(value);
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }
        protected Rial(long value)
        {
            Value = value;
        }
        private Rial()
        {

        }
        public override bool ObjectIsEqual(Rial otherObject)
        {
            return Value == otherObject.Value;
        }

        public Rial Add(Rial rial)
        {
            return new Rial(rial.Value + Value);
        }
        public Rial Subtract(Rial rial)
        {
            return new Rial(rial.Value + Value);
        }

        public static Rial operator +(Rial leftSide, Rial rightSide)
        {
            return leftSide.Add(rightSide);
        }
        public static Rial operator -(Rial leftSide, Rial rightSide)
        {
            return leftSide.Subtract(rightSide);
        }

        public static implicit operator long(Rial rial) => rial.Value;

    }
}
