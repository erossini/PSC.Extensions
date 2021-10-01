// ***********************************************************************
// Assembly         : PSC.Extensions
// Author           : enric
// Blog             :
// Blog URL         :
// Created          : 09-24-2021
//
// Last Modified By : enric
// Last Modified On : 09-24-2021
// ***********************************************************************
// <copyright file="LocalizedEnumAttribute.cs" company="Enrico Rossini - PureSourceCode.com">
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
	/// Localized Enum Attribute
	/// </summary>
	public class LocalizedEnumAttribute : DescriptionAttribute
	{
		/// <summary>
		/// The name property
		/// </summary>
		private PropertyInfo _nameProperty;

		/// <summary>
		/// The resource type
		/// </summary>
		private Type _resourceType;

		/// <summary>
		/// Localized Enum Attribute
		/// </summary>
		/// <param name="displayNameKey">The display name key.</param>
		public LocalizedEnumAttribute(string displayNameKey)
			: base(displayNameKey)
		{
		}

		/// <summary>
		/// Gets or sets the name of the resource type
		/// </summary>
		/// <value>The type of the name resource.</value>
		public Type NameResourceType
		{
			get
			{
				return _resourceType;
			}
			set
			{
				_resourceType = value;

				_nameProperty = _resourceType.GetProperty(this.Description, BindingFlags.Static | BindingFlags.Public);
			}
		}

		/// <summary>
		/// Gets the description
		/// </summary>
		/// <value>The description.</value>
		public override string Description
		{
			get
			{
				//check if nameProperty is null and return original display name value
				if (_nameProperty == null)
				{
					return base.Description;
				}

				return (string)_nameProperty.GetValue(_nameProperty.DeclaringType, null);
			}
		}
	}
}