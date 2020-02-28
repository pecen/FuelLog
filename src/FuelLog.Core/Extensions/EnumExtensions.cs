using FuelLog.Core.Utilities;
using System;
using System.ComponentModel;
using System.Reflection;

namespace FuelLog.Core.Extensions {
  public static class EnumExtensions {
    /// <summary>
    /// Gets value stored in the Description attribute of the given enumerator value.
    /// </summary>
    /// <param name="value">Enumerator value.</param>
    /// <returns>Description stored in attribute.</returns>
    public static string GetEnumDescription(this Enum value) {
      if (value != null) {
        DescriptionAttribute attr = GetAttribute<DescriptionAttribute>(value);
        if (attr != null) {
          return attr.Description;
        }
      }

      return string.Empty;
    }

    /// <summary>
    /// Another take on GetEnumDescription. Gets the enum value description.
    /// </summary>
    /// <param name="enumValue">The enum value.</param>
    /// <returns></returns>
    public static string GetEnumValueDescription(this Enum enumValue) {
      return enumValue.GetEnumAttributeValue<DescriptionAttribute>().Description;
    }

    /// <summary>
    /// Generic method getting attribute object of the given type from enumerated value.
    /// </summary>
    /// <typeparam name="TAttributeType">Attribute type.</typeparam>
    /// <param name="enumValue">Enumerated value.</param>
    /// <returns>Attribute object.</returns>
    public static TAttributeType GetAttribute<TAttributeType>(this Enum enumValue) where TAttributeType : Attribute {
      return (TAttributeType)EnumUtils.GetEnumAttribute(enumValue, typeof(TAttributeType));
    }

    /// <summary>
    /// Another take of the GetAttribute method. Gets an attribute on an enum field value.
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
