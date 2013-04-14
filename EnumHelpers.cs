using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* EnumHelpers
 * C# extension methods for the Enum type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class EnumHelpers {
		/// <summary>
		/// Get next member of the enum.
		/// </summary>
		/// <typeparam name="T">Enum type.</typeparam>
		/// <param name="src">Enum.</param>
		/// <returns></returns>
		public static T Next<T>(this T e) where T : struct {
			if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

			T[] Arr = (T[])Enum.GetValues(e.GetType());
			int j = Array.IndexOf<T>(Arr, e) + 1;
			return (Arr.Length == j) ? Arr[0] : Arr[j];
		}

		/// <summary>
		/// Converts enum to string.
		/// </summary>
		/// <param name="e">Enum.</param>
		public static String ToString(this Enum e) {
			return Enum.GetName(e.GetType(), e);
		}
	}
}
