using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/* StringHelpers
 * C# extension methods for the String type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class StringHelpers {
		/// <summary>
		/// Removes invalid characters from a string.
		/// </summary>
		/// <param name="s">String to clean.</param>
		public static string Sanitize(this string s) {
			string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
			string invalidReStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
			s = Regex.Replace(s, invalidReStr, "_");
			s = s.Replace("&", "_");
			return s;
		}

		/// <summary>
		/// Splits a string using a string delimiter.
		/// </summary>
		/// <param name="s">String to split.</param>
		/// <param name="delimiter">String delimiter.</param>
		public static string[] Split(this string s, string delimiter) {
			return s.Split(new string[] { delimiter }, StringSplitOptions.None);
		}

		/// <summary>
		/// Converts a string to a byte array.
		/// </summary>
		/// <param name="s">String to convert.</param>
		public static byte[] ToBytes(this string s) {
			byte[] bytes = new byte[s.Length * sizeof(char)];
			System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Formats a string as a phone number.
		/// All non-numeric characters are removed.
		/// If the result has 7 characters, the phone number is formatted like "xxx-xxxx".
		/// If the result has 10 characters, the phone number is formatted like "(xxx) xxx-xxxx".
		/// If the result does not have 7 or 10 characters, null is returned.
		/// </summary>
		/// <param name="s">String to format.</param>
		public static string ToPhone(this string s) {
			s = Regex.Replace((s ?? ""), @"\D", "");
			if ((s ?? "").Length == 7)
				return s.Substring(0, 3) + "-" + s.Substring(3, 4);
			else if ((s ?? "").Length == 10)
				return "(" + s.Substring(0, 3) + ") " + s.Substring(3, 3) + "-" + s.Substring(6, 4);
			return null;
		}

		/// <summary>
		/// Returns a copy of this string converted to sentence case.
		/// </summary>
		/// <param name="s">String to convert.</param>
		public static string ToSentence(this string s) {
			return (s.Length < 1) ? s : s[0].ToString().ToUpper() + s.ToLower().Substring(1);
		}

		/// <summary>
		/// Returns a copy of this string converted to title case.
		/// </summary>
		/// <param name="s">String to convert.</param>
		public static string ToTitle(this string s) {
			// List of words that should usually be lowercase.
			var l = new string[] { "a", "an", "the", "of", "on", "to", "at", "in", "from", "atop", "with", "for", "and", "nor", "but", "or", "yet", "so" };

			// List of words that should usually be upppercase.
			var u = new string[] { "US", "I", "II", "III", "IIII", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

			// Array of words in s.
			var w = s.Replace("  ", " ").Split(' ');

			for (int i = 0; i < w.Length; i++) {
				// Lowercase the words listed in l.
				// Except the first word.
				// Except words after a colon.
				if (l.Contains(w[i].Replace(":", "").Replace(",", "").ToLower()) && i != 0 && w[i - 1][w[i - 1].Length - 1] != ':')
					w[i] = w[i].ToLower();

				// Uppercase the words listed in u.
				else if (u.Contains(w[i].Replace(":", "").Replace(",", "").ToUpper()))
					w[i] = w[i].ToUpper();

				// Sentence case everything else.
				else
					w[i] = w[i].ToSentence();

				// Capitalize letter after slash.
				var x = w[i].Split('/');
				for (int j = 1; j < x.Length; j++) {
					x[j] = x[j].ToSentence();
				}
				w[i] = String.Join("/", x);

				// Capitalize letter after dash.
				x = w[i].Split('-');
				for (int j = 1; j < x.Length; j++) {
					x[j] = x[j].ToSentence();
				}
				w[i] = String.Join("-", x);

				// Capitalize letter after period.
				x = w[i].Split('.');
				for (int j = 1; j < x.Length; j++) {
					x[j] = x[j].ToSentence();
				}
				w[i] = String.Join(".", x);
			}

			// Capitalize first letter.
			w[0] = w[0].Length < 1 ? w[0] : w[0][0].ToString().ToUpper() + w[0].Substring(1);

			return String.Join(" ", w);
		}
	}
}
