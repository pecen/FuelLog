using System;
using System.Reflection;

namespace FuelLog.Core.Extensions {
  public static class EnumExtensions {
    /// <summary>
    /// Gets an attribute on an enum field value.
    /// </summary>
    /// <typeparam name="T">The type of the attribute you want to retrieve.</typeparam>
    /// <param name="enumAttr">The enum attribute.</param>
    /// <returns>The attribute of type T that exists on the enum value.</returns>
    /// <example>string desc = myEnumVariable.GetAttributeOfType<![CDATA[<DescriptionAttribute>]]>().Description;</example>
    public static T GetEnumAttributeValue<T>(this Enum enumAttr) where T : Attribute {
      Type type = enumAttr.GetType();
      MemberInfo[] memInfo = type.GetMember(enumAttr.ToString());
      object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
      return attributes.Length > 0 ? (T)attributes[0] : null;
    }
  }
}
