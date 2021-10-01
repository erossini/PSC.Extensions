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
// <copyright file="StringExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace PSC.Extensions
{
	/// <summary>
	/// String Extensions
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Checks the ip valid.
		/// </summary>
		/// <param name="strIP">The string ip.</param>
		/// <returns>System.String.</returns>
		public static string CheckIPValid(this string strIP)
		{
			//IPAddress result = null;
			//return !String.IsNullOrEmpty(strIP) && IPAddress.TryParse(strIP, out result);
			IPAddress address;
			if (IPAddress.TryParse(strIP, out address))
			{
				switch (address.AddressFamily)
				{
					case System.Net.Sockets.AddressFamily.InterNetwork:
						// we have IPv4
						return "ipv4";
					//break;
					case System.Net.Sockets.AddressFamily.InterNetworkV6:
						// we have IPv6
						return "ipv6";
					//break;
					default:
						// umm... yeah... I'm going to need to take your red packet and...
						return null;
						//break;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the last.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="tailLength">Length of the tail.</param>
		/// <returns>System.String.</returns>
		public static string GetLast(this string source, int tailLength)
		{
			if (tailLength >= source.Length)
				return source;
			return source.Substring(source.Length - tailLength);
		}

		/// <summary>
		/// Extract a domain name from a full URL
		/// </summary>
		/// <param name="Url">Full URL</param>
		/// <returns>Domain</returns>
		public static string ExtractDomainNameFromURL(this string Url)
		{
			string rtn = "";
			if (!string.IsNullOrEmpty(Url))
			{
				rtn = System.Text.RegularExpressions.Regex.Replace(
							Url,
							@"^([a-zA-Z]+:\/\/)?([^\/]+)\/.*?$",
							"$2"
						);
			}

			return rtn;
		}

		/// <summary>
		/// Gets a number from a IPv4
		/// </summary>
		/// <param name="Ip">IPv4 to convert in a number</param>
		/// <returns>System.Decimal.</returns>
		public static decimal IPToNumber(this string Ip)
		{
			decimal ipnum = 0;

			// verifiy the IP is an IPv4
			// IPv6 has :
			if (Ip.IndexOf(":") < 0)
			{
				string[] split = Ip.Split('.');
				ipnum = Convert.ToInt64(split[0]) * (256 * 256 * 256) + Convert.ToInt64(split[1]) * (256 * 256) +
						Convert.ToInt64(split[2]) * 256 + Convert.ToInt64(split[3]);
			}

			return ipnum;
		}

		/// <summary>
		/// Determines whether the specified date is date.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns><c>true</c> if the specified date is date; otherwise, <c>false</c>.</returns>
		public static bool IsDate(this string date)
		{
			DateTime Temp;
			if (DateTime.TryParse(date, out Temp) == true)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Is the numeric.
		/// </summary>
		/// <param name="str">String.</param>
		/// <param name="style">Style.</param>
		/// <param name="culture">Culture.</param>
		/// <returns><c>true</c>, if numeric was ised, <c>false</c> otherwise.</returns>
		/// <remarks>Example to use:
		/// var mystring = "1234.56789";
		/// var test = mystring.IsNumeric();
		/// Or, if you want to test other types of number, you can specify the 'style'.
		/// So, to convert a number with an Exponent, you could use:
		/// var mystring = "5.2453232E6";
		/// var test = mystring.IsNumeric(style: NumberStyles.AllowExponent);
		/// Or to test a potential Hex string, you could use:
		/// var mystring = "0xF67AB2";
		/// var test = mystring.IsNumeric(style: NumberStyles.HexNumber)
		/// The optional 'culture' parameter can be used in much the same way.</remarks>
		public static bool IsNumeric(this string str, NumberStyles style = NumberStyles.Integer, CultureInfo culture = null)
		{
			double num;
			if (culture == null) culture = CultureInfo.InvariantCulture;
			return Double.TryParse(str, style, culture, out num) && !String.IsNullOrWhiteSpace(str);
		}

		/// <summary>
		/// Pads the number.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns>System.String.</returns>
		public static string PadNumber(this string text)
		{
			return text.PadRight(1, '0');
		}

		/// <summary>
		/// Returns a random string with random alphanumeric characters
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="length">String length</param>
		/// <returns>A string with random alphanumeric characters</returns>
		public static string RandomString(this string str, int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();
			return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}

		/// <summary>
		/// Replace special character with another string
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="repl">The repl.</param>
		/// <returns>System.String.</returns>
		public static string RemoveSpecialCharacter(this string str, string repl = "")
		{
			return Regex.Replace(str, @"[^0-9a-zA-Z]+", repl);
		}

		/// <summary>
		/// Replace spaces with another string
		/// </summary>
		/// <param name="str">Input string</param>
		/// <param name="repl">String to replace with a space. For default is _</param>
		/// <returns>System.String.</returns>
		public static string ReplaceSpace(this string str, string repl = "_")
		{
			return str.Replace(" ", repl);
		}

		/// <summary>
		/// Replace non-ASCII characters with their ASCII value
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>System.String.</returns>
		public static string ReplaceSpecialCharacters(this string value)
		{
			string[] nonAsciiCharacters = new string[] { "À", "Á", "Â", "Ã", "Å", "Ä", "Ç", "È", "É", "Ê", "Ë", "Ì", "Í", "Î", "Ï", "Ñ", "Ò", "Ó", "Ô", "Ö", "Õ", "Ù", "Ú", "Û", "Ü", "Ý", "à", "á", "â", "ã", "ä", "å", "ç", "è", "é", "ê", "ë", "ì", "í", "î", "ï", "ñ", "ò", "ó", "ô", "õ", "ö", "ø", "ù", "ú", "û", "ý", "ÿ", "Ā", "ā", "Ă", "ă", "Ą", "ą", "Ć", "ć", "Ĉ", "ĉ", "Ċ", "ċ", "Č", "č", "Ď", "ď", "Đ", "đ", "Ē", "ē", "Ĕ", "ĕ", "Ė", "ė", "Ę", "ę", "Ě", "ě", "Ĝ", "ĝ", "Ğ", "ğ", "Ġ", "ġ", "Ģ", "ģ", "Ĥ", "ĥ", "Ĩ", "ĩ", "Ī", "ī", "Ĭ", "ĭ", "Į", "į", "İ", "ı", "Ĵ", "ĵ", "Ķ", "ķ", "ĸ", "Ĺ", "ĺ", "Ļ", "ļ", "Ľ", "ľ", "Ŀ", "ŀ", "Ł", "ł", "Ń", "ń", "Ņ", "ņ", "Ň", "ň", "ŉ", "Ŋ", "ŋ", "Ō", "ō", "Ŏ", "ŏ", "Ő", "ő", "Ŕ", "ŕ", "Ŗ", "ŗ", "Ř", "ř", "Ś", "ś", "Ŝ", "ŝ", "Ş", "ş", "Š", "š", "Ţ", "ţ", "Ť", "ť", "Ũ", "ũ", "Ū", "ū", "Ŭ", "ŭ", "Ů", "ů", "Ű", "ű", "Ų", "ų", "Ŵ", "ŵ", "Ŷ", "ŷ", "Ÿ", "Ź", "ź", "Ż", "ż", "Ž", "ž", "Ơ", "ơ", "Ư", "ư", "Ǎ", "ǎ", "Ǐ", "ǐ", "Ǒ", "ǒ", "Ǔ", "ǔ", "Ǖ", "ǖ", "Ǘ", "ǘ", "Ǚ", "ǚ", "Ǜ", "ǜ", "Ǻ", "ǻ", "Ǿ", "ǿ" };
			string[] asciiCharacters = new string[] { "A", "A", "A", "A", "A", "A", "C", "E", "E", "E", "E", "I", "I", "I", "I", "N", "O", "O", "O", "O", "O", "U", "U", "U", "U", "Y", "a", "a", "a", "a", "a", "a", "c", "e", "e", "e", "e", "i", "i", "i", "i", "n", "o", "o", "o", "o", "o", "o", "u", "u", "u", "y", "y", "A", "a", "A", "a", "A", "a", "C", "c", "C", "c", "C", "c", "C", "c", "D", "c", "D", "d", "E", "e", "E", "e", "E", "e", "E", "e", "E", "e", "G", "g", "G", "g", "G", "g", "G", "g", "H", "h", "I", "i", "I", "i", "I", "i", "I", "i", "I", "i", "J", "j", "K", "k", "k", "L", "l", "L", "l", "L", "l", "L", "l", "L", "l", "N", "n", "N", "n", "N", "n", "n", "N", "n", "O", "o", "O", "o", "O", "o", "R", "r", "R", "r", "R", "r", "S", "s", "S", "s", "S", "s", "S", "s", "T", "t", "T", "t", "U", "u", "U", "u", "U", "u", "U", "u", "U", "u", "U", "u", "W", "w", "Y", "y", "Y", "Z", "z", "Z", "z", "Z", "z", "O", "o", "U", "u", "A", "a", "I", "i", "O", "o", "U", "u", "U", "u", "U", "u", "U", "u", "U", "u", "A", "a", "O", "o" };

			value = Regex.Replace(value.Trim(), @"[\s]", "_"); // Replace white with under character

			for (int currentChar = 0; currentChar < nonAsciiCharacters.Length; currentChar++)
				value = value.Replace(nonAsciiCharacters[currentChar], asciiCharacters[currentChar]);

			return Regex.Replace(value, @"[^0-9a-zA-Z_]+", string.Empty); // Remove white characters
		}

		/// <summary>
		/// Return the last n characters from a string
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="num">Number of characters from the right</param>
		/// <returns>The last num characters from the string</returns>
		public static string Right(this string value, int num)
		{
			if (value == null || value.Length < num)
				return string.Empty;

			return value.Substring(value.Length - num);
		}

		/// <summary>
		/// Remove all HTML tags from a string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>System.String.</returns>
		public static string StripHTML(this string input)
		{
			return Regex.Replace(input, "<.*?>", String.Empty);
		}

		/// <summary>
		/// Takes a substring between two anchor strings (or the end of the string if that anchor is null)
		/// </summary>
		/// <param name="this">a string</param>
		/// <param name="from">an optional string to search after</param>
		/// <param name="until">an optional string to search before</param>
		/// <param name="comparison">an optional comparison for the search</param>
		/// <returns>a substring based on the search</returns>
		/// <exception cref="ArgumentException">from: Failed to find an instance of the first anchor</exception>
		public static string SubstringBetween(this string @this, string from = null, string until = null,
											  StringComparison comparison = StringComparison.InvariantCulture)
		{
			var fromLength = (from ?? string.Empty).Length;
			var startIndex = !string.IsNullOrEmpty(from) ? @this.IndexOf(from, comparison) + fromLength : 0;

			if (startIndex < fromLength)
			{
				throw new ArgumentException("from: Failed to find an instance of the first anchor");
			}

			var endIndex = !string.IsNullOrEmpty(until) ? @this.IndexOf(until, startIndex, comparison) : @this.Length;

			if (endIndex < 0)
			{
				endIndex = @this.Length;
			}

			var subString = @this.Substring(startIndex, endIndex - startIndex);
			return subString;
		}

		/// <summary>
		/// Truncate a string after maxLength characters.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <returns>A string truncates after maxLength characters. If the string length is less the maxLength, return the string</returns>
		public static string TruncateString(this string str, int maxLength)
		{
			return new string(str.Take(maxLength).ToArray());
		}

		/// <summary>
		/// Truncate a string after maxLength characters.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="maxLength">The maximum length.</param>
		/// <param name="addFullStop">if set to <c>true</c> [add full stop].</param>
		/// <returns>A string truncates after maxLength characters. If the string length is less the maxLength, return the string</returns>
		public static string TruncateString(this string str, int maxLength, bool addFullStop = false)
		{
			string rtn = "";

			if (!string.IsNullOrEmpty(str))
			{
				if (str.Length > maxLength)
				{
					rtn = new string(str.ToCharArray(0, maxLength));
					if (addFullStop)
					{
						rtn += "...";
					}
				}
				else
				{
					rtn = str;
				}
			}

			return rtn;
		}
	}
}