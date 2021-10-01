// ***********************************************************************
// Assembly         : PSC.Extensions
// Author           : enric
// Blog             :
// Blog URL         :
// Created          : 09-24-2021
//
// Last Modified By : enric
// Last Modified On : 09-22-2021
// ***********************************************************************
// <copyright file="EnumExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace PSC.Extensions
{
	/// <summary>
	/// Class EnumExtensions.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumerationValue">The enumeration value.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="ArgumentException">EnumerationValue must be of Enum type - enumerationValue</exception>
		/// <exception cref="System.ArgumentException">EnumerationValue must be of Enum type - enumerationValue</exception>
		public static string GetDescription<T>(this T enumerationValue) where T : struct
		{
			Type type = enumerationValue.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
			}

			//Tries to find a DescriptionAttribute for a potential friendly name
			//for the enum
			MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo != null && memberInfo.Length > 0)
			{
				object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attrs != null && attrs.Length > 0)
				{
					//Pull out the description value
					return ((DescriptionAttribute)attrs[0]).Description;
				}
			}

			//If we have no description attribute, just return the ToString of the enum
			return enumerationValue.ToString();
		}

		/// <summary>
		/// Gets localized description
		/// </summary>
		/// <param name="value">The enum.</param>
		/// <returns>System.String.</returns>
		public static string GetLocalizedDescription(this Enum value)
		{
			if (value == null)
				return null;

			string description = value.ToString();

			FieldInfo fieldInfo = value.GetType().GetField(description);
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes.Any())
				return attributes[0].Description;

			return description;
		}

		/// <summary>
		/// Extension method to return an enum value of type T for the given string.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <returns>T.</returns>
		/// <exception cref="Exception">T must be an Enumeration type.</exception>
		public static T ToEnum<T>(this string value) where T : struct, Enum
		{
			Type enumType = typeof(T);
			if (!enumType.IsEnum)
			{
				throw new Exception("T must be an Enumeration type.");
			}

			return Enum.TryParse(value, out T val) ? val : default;
		}

		/// <summary>
		/// Extension method to return an enum value of type T for the given int.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <returns>T.</returns>
		/// <exception cref="Exception">T must be an Enumeration type.</exception>
		public static T ToEnum<T>(this int value)
		{
			Type enumType = typeof(T);
			if (!enumType.IsEnum)
			{
				throw new Exception("T must be an Enumeration type.");
			}

			return (T)Enum.ToObject(enumType, value);
		}
	}
}