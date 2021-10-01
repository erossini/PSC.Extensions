// ***********************************************************************
// Assembly         : PSC.Extensions
// Author           : enric
// Blog             :
// Blog URL         :
// Created          : 09-29-2021
//
// Last Modified By : enric
// Last Modified On : 09-29-2021
// ***********************************************************************
// <copyright file="ClaimExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PSC.Extensions
{
	/// <summary>
	/// Class Claim Extensions.
	/// </summary>
	public static class ClaimExtensions
	{
		/// <summary>
		/// Gets a claim from a list of claims
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <param name="claimName">Name of the claim.</param>
		/// <returns>Claim.</returns>
		public static Claim GetClaim(this IEnumerable<Claim> claims, string claimName)
		{
			Claim rtn = null;

			if (!string.IsNullOrEmpty(claimName))
			{
				rtn = claims.FirstOrDefault(x => x.Type == claimName);
			}

			return rtn;
		}

		/// <summary>
		/// Gets the value of the requested claim if it exists
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <param name="claimName">Name of the claim.</param>
		/// <returns>System.String.</returns>
		public static string GetClaimValue(this IEnumerable<Claim> claims, string claimName)
		{
			string rtn = null;

			if (!string.IsNullOrEmpty(claimName))
			{
				Claim claim = GetClaim(claims, claimName);
				if (claim != null)
					rtn = claim.Value;
			}

			return rtn;
		}

		/// <summary>
		/// Determines whether the specified role name has role.
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <param name="roleName">Name of the role.</param>
		/// <returns><c>true</c> if the specified role name has role; otherwise, <c>false</c>.</returns>
		public static bool HasRole(this IEnumerable<Claim> claims, string roleName)
		{
			bool rtn = false;

			if (!string.IsNullOrEmpty(roleName))
			{
				rtn = claims.Where(c => c.Type == "role" && c.Value.Contains(roleName)).Count() > 0;
			}

			return rtn;
		}

		/// <summary>
		/// Determines whether the specified role name has roles.
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <param name="roleName">Name of the role.</param>
		/// <returns><c>true</c> if the specified role name has roles; otherwise, <c>false</c>.</returns>
		public static bool HasRoles(this IEnumerable<Claim> claims, string roleName)
		{
			bool rtn = false;

			string[] roles = roleName.Split(',');
			for (int i = 0; i < roles.Count(); i++)
				roles[i] = roles[i].Trim();

			if (!string.IsNullOrEmpty(roleName))
			{
				rtn = claims.Where(c => c.Type == "role" && roles.Contains(c.Value)).Count() > 0;
			}

			return rtn;
		}

		/// <summary>
		/// Updates a claim with a new value
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <param name="claimName">Name of the claim.</param>
		/// <param name="newValue">The new value.</param>
		public static void UpdateClaim(this List<Claim> claims, string claimName, string newValue)
		{
			Claim claim = claims.GetClaim(claimName);
			if (claim != null)
				claims.Remove(claim);

			claims.Add(new Claim(claimName, newValue));
		}
	}
}