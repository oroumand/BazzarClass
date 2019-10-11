using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Tools.Enums
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum @enum)
        {

            Type genericEnumType = @enum.GetType();
            System.Reflection.MemberInfo[] memberInfo =
                        genericEnumType.GetMember(@enum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {

                var Attribs = memberInfo[0].GetCustomAttributes
                      (typeof(System.ComponentModel.DescriptionAttribute), false);
                if (Attribs != null && Attribs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)Attribs[0]).Description;
                }
            }

            return @enum.ToString();
        }
    }
}
