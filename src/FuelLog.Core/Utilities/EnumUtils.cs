using FuelLog.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace FuelLog.Core.Utilities
{
    public static class EnumUtils
    {
    /// <summary>
    /// Returns all values defined in enumerator type except values with Browsable(false) attribute.
    /// </summary>
    /// <param name="enumType">Enumerator type.</param>
    /// <returns>Enumerator values array.</returns>
    public static Enum[] GetEnumValues(Type enumType) {
      return Enum.GetValues(enumType).Cast<Enum>().Where(GetEnumBrowsable).ToArray();
    }

    /// <summary>
    /// Return values defined in enumerator filtered by specified attribute.
    /// </summary>
    /// <param name="enumType">Enumerator type.</param>
    /// <param name="filterAttributeType">Filter attribute type.</param>
    /// <returns>Enumerator values array.</returns>
    public static Enum[] GetEnumValues(Type enumType, Type filterAttributeType) {
      Enum[] values = GetEnumValues(enumType);
      List<Enum> returnedValues = new List<Enum>();
      foreach (Enum value in values) {
        if (GetEnumAttribute(value, filterAttributeType) != null) {
          returnedValues.Add(value);
        }
      }

      return returnedValues.ToArray();
    }

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
    /// Checks if given enumerator value has Browsable attribute and it's set to False;
    /// else returns True.
    /// </summary>
    /// <param name="value">Enumerator value.</param>
    /// <returns>true if member is browsable; otherwise, returns false.</returns>
    public static bool GetEnumBrowsable(Enum value) {
      BrowsableAttribute attr = GetAttribute<BrowsableAttribute>(value);
      if (attr != null) {
        return attr.Browsable;
      }
      else {
        return true;
      }
    }

    /// <summary>
    /// Generic method getting attribute object of the given type from enumerated value.
    /// </summary>
    /// <typeparam name="TAttributeType">Attribute type.</typeparam>
    /// <param name="enumValue">Enumerated value.</param>
    /// <returns>Attribute object.</returns>
    public static TAttributeType GetAttribute<TAttributeType>(this Enum enumValue) where TAttributeType : Attribute {
      return (TAttributeType)GetEnumAttribute(enumValue, typeof(TAttributeType));
    }

    /// <summary>
    /// Generic method getting attribute objects of the given type from enumerated value.
    /// </summary>
    /// <typeparam name="TAttributeType">Attribute type.</typeparam>
    /// <param name="enumValue">Enumerated value.</param>
    /// <returns>Attribute object.</returns>
    public static TAttributeType[] GetAttributes<TAttributeType>(Enum enumValue) where TAttributeType : Attribute {
      return (TAttributeType[])GetEnumAttributes(enumValue, typeof(TAttributeType));
    }

    /// <summary>
    /// Basic method getting attribute object of the given type from enumerator type and enumerated value.
    /// </summary>
    /// <param name="enumValue">Enumerator type.</param>
    /// <param name="attributeType">Enumerator value.</param>
    /// <returns>Attribute object.</returns>
    public static Attribute GetEnumAttribute(Enum enumValue, Type attributeType) {
      Attribute[] atts = GetEnumAttributes(enumValue, attributeType);
      if (atts == null || atts.Length == 0) {
        return null;
      }
      else {
        return atts[0];
      }
    }

    /// <summary>
    /// Basic method getting attribute objects of the given type from an enumerated value.
    /// </summary>
    /// <param name="enumValue">Enumerator value.</param>
    /// <param name="attributeType">Attribute type.</param>
    /// <returns>Attribute object.</returns>
    public static Attribute[] GetEnumAttributes(Enum enumValue, Type attributeType) {
      if (Enum.IsDefined(enumValue.GetType(), enumValue)) {
        FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
        return (Attribute[])field.GetCustomAttributes(attributeType, true);
      }
      else {
        return null;
      }
    }

    /// <summary>
    /// Creates an instance of enumerated value.
    /// </summary>
    /// <param name="enumeratorType">Enumerator type full name.</param>
    /// <param name="valueName">Enumerated value name.</param>
    /// <returns>An instance of the enumerated value.</returns>
    public static Enum CreateEnumValue(string enumeratorType, string valueName) {
      return (Enum)Enum.Parse(Type.GetType(enumeratorType), valueName);
    }

    /// <summary>
    /// Checks whether given value is part of given enumerator
    /// </summary>
    /// <param name="enumType">Type of the enumerator</param>
    /// <param name="value">Value to check</param>
    public static void CheckValue(Type enumType, int value) {
      if (!Enum.IsDefined(enumType, value)) {
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture,
          "Value {0} is not defined in {1} enumerator.",
          value,
          enumType.Name));
      }
    }

    /// <summary>
    /// Build descriptions dictionary.
    /// </summary>
    /// <typeparam name="TEnum">Enumerator type.</typeparam>
    /// <returns>Description dictionary.</returns>
    public static Dictionary<string, TEnum> BuildDescriptionsDictionary<TEnum>()
      where TEnum : struct {
      EnumTypeCheck<TEnum>();

      Dictionary<string, TEnum> descriptionsDictionary = new Dictionary<string, TEnum>();

      foreach (TEnum value in Enum.GetValues(typeof(TEnum))) {
        string description = GetEnumDescription(value as Enum);

        if (!string.IsNullOrEmpty(description)) {
          if (descriptionsDictionary.ContainsKey(description)) {
            throw new ArgumentException("Description " + description + " is already set for another enum value.");
          }

          descriptionsDictionary.Add(description, value);
        }
      }

      return descriptionsDictionary;
    }

    /// <summary>
    /// Converts the flag enum into single values of the same enumerator type.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="enumValue">The enum value.</param>
    /// <param name="withZeroValue">If set to true, output collection stores value for 0.</param>
    /// <returns>Collection storing single values of enumerator</returns>
    public static IEnumerable<TEnum> ConvertFlagEnumIntoSingleValues<TEnum>(TEnum enumValue, bool withZeroValue)
      where TEnum : struct {
      EnumTypeCheck<TEnum>();

      Collection<TEnum> singleEnumValues = new Collection<TEnum>();

      foreach (TEnum value in Enum.GetValues(typeof(TEnum))) {
        int valueAsInt = Convert.ToInt32(value);
        if (withZeroValue == false && valueAsInt == 0) {
          continue;
        }

        if ((valueAsInt & Convert.ToInt32(enumValue)) == valueAsInt) {
          singleEnumValues.Add(value);
        }
      }

      return singleEnumValues;
    }

    /// <summary>
    /// Return value indicating whether flag enumerator values combination
    /// contains given single value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="complexEnumValue">The complex enum value.</param>
    /// <param name="singleEnumValue">The single enum value.</param>
    /// <param name="withZeroValue">If set to true zero value is also considered.</param>
    /// <returns>Value indicating whether flag enumerator values combination
    /// contains given single value</returns>
    public static bool FlagEnumContainsValueCheck<TEnum>(TEnum complexEnumValue, TEnum singleEnumValue, bool withZeroValue)
      where TEnum : struct {
      EnumTypeCheck<TEnum>();

      IEnumerable<TEnum> singleValues = ConvertFlagEnumIntoSingleValues<TEnum>(complexEnumValue, withZeroValue);

      return singleValues.Any(v => v.Equals(singleEnumValue));
    }

    /// <summary>
    /// Checks whether given type is enum. If not, throws exception.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    private static void EnumTypeCheck<TEnum>() where TEnum : struct {
      if (!typeof(TEnum).IsEnum) {
        throw new ArgumentException("TEnum must be an enumerated type");
      }
    }

    /// <summary>
    /// Converts the string representation of the name or numeric
    /// value of one or more enumerated constants to an equivalent
    /// enumerated object.
    /// </summary>
    /// <typeparam name="TEnum">Enum type.</typeparam>
    /// <param name="input">A string containing the name or value to convert.</param>
    /// <returns>An object of type enumType whose value is represented by value.</returns>
    public static TEnum Parse<TEnum>(string input)
      where TEnum : struct {
      EnumTypeCheck<TEnum>();

      TEnum value = (TEnum)Enum.Parse(typeof(TEnum), input);

      if (!Enum.IsDefined(typeof(TEnum), value) && !value.ToString().Contains(",")) {
        throw new ArgumentOutOfRangeException(input);
      }

      return value;
    }

    /// <summary>
    /// Converts the string representation of the name or numeric
    /// value of one or more enumerated constants to an equivalent
    /// enumerated object.
    /// </summary>
    /// <typeparam name="TEnum">Enum type.</typeparam>
    /// <param name="input">A string containing the name or value to convert.</param>
    /// <param name="defaultValue">A default value for enum if string value cannot be parsed</param>
    /// <returns>An object of type enumType whose value is represented by value.</returns>
    public static TEnum Parse<TEnum>(string input, TEnum defaultValue)
      where TEnum : struct {
      EnumTypeCheck<TEnum>();
      try {
        return Parse<TEnum>(input);
      }
      catch (Exception) {
        return defaultValue;
      }
    }

    /// <summary>
    /// Gets the enum value by description.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static TEnum? GetEnumValueByDescription<TEnum>(string text) where TEnum : struct {
      foreach (TEnum value in Enum.GetValues(typeof(TEnum))) {
        if (GetEnumDescription(value as Enum) == text) {
          return value;
        }
      }

      return null;
    }

    /// <summary>
    /// Gets the enum value description.
    /// </summary>
    /// <param name="enumValue">The enum value.</param>
    /// <returns></returns>
    public static string GetEnumValueDescription(this Enum enumValue) {
      return enumValue.GetEnumAttributeValue<DescriptionAttribute>().Description;
    }
  }
}
