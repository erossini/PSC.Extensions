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
// <copyright file="EnumerableExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC.Extensions
{
	/// <summary>
	/// Enumerable Extensions
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Return a random item for an IEnumerable T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns>T.</returns>
		public static T PickRandom<T>(this IEnumerable<T> source)
		{
			return source.PickRandom(1).Single();
		}

		/// <summary>
		/// Return a random item for an IEnumerable T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="count">The count.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
		{
			return source.Shuffle().Take(count);
		}

		/// <summary>
		/// Return source ordered by a new Guid
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.OrderBy(x => Guid.NewGuid());
		}
	}
}