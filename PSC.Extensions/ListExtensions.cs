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
// <copyright file="ListExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace PSC.Extensions
{
	/// <summary>
	/// List Extensions
	/// </summary>
	public static class ListExtensions
	{
		/// <summary>
		/// Remove spece for each element of a list of string
		/// </summary>
		/// <param name="list">The list.</param>
		/// <returns>List&lt;System.String&gt;.</returns>
		public static List<string> TrimSpace(this List<string> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = list[i].Trim();
			}

			return list;
		}
	}
}