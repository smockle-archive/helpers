using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

/* IEnumerableHelpers
 * C# extension methods for the IEnumerable type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class IEnumerableHelpers {
		/// <summary>
		/// Converts any IEnumerable into a SelectList.
		/// </summary>
		/// <typeparam name="T">Type of object stored in IEnumerable.</typeparam>
		/// <param name="e">IEnumerable to convert.</param>
		/// <param name="text">Lambda expression selecting the Text field, eg. n => n.preferredname.</param>
		/// <param name="value">Lambda expression selecting the Value field, eg. v => v.aubGid.ToString().</param>
		public static SelectList ToSelectList<T>(this IEnumerable<T> e, Func<T, string> text, Func<T, string> value) {
			return e.Select(f => new SelectListItem() { Text = text(f), Value = value(f) }).ToList().ToSelectList();
		}

		/// <summary>
		/// Converts any IEnumerable into a SelectList.
		/// </summary>
		/// <typeparam name="T">Type of object stored in IEnumerable.</typeparam>
		/// <param name="e">IEnumerable to convert.</param>
		/// <param name="text">Lambda expression selecting the Text field, eg. n => n.preferredname.</param>
		/// <param name="value">Lambda expression selecting the Value field, eg. v => v.aubGid.ToString().</param>
		/// <param name="selected">Value of the default option.</param>
		public static SelectList ToSelectList<T>(this IEnumerable<T> e, Func<T, string> text, Func<T, string> value, int selected) {
			return e.Select(f => new SelectListItem() { Text = text(f), Value = value(f) }).ToList().ToSelectList(selected);
		}

		/// <summary>
		/// Converts any IEnumerable into a SelectList.
		/// </summary>
		/// <typeparam name="T">Type of object stored in IEnumerable.</typeparam>
		/// <param name="e">IEnumerable to convert.</param>
		/// <param name="text">Lambda expression selecting the Text field, eg. n => n.preferredname.</param>
		/// <param name="value">Lambda expression selecting the Value field, eg. v => v.aubGid.ToString().</param>
		/// <param name="selected">Value of the default option.</param>
		public static SelectList ToSelectList<T>(this IEnumerable<T> e, Func<T, string> text, Func<T, string> value, string selected) {
			return e.Select(f => new SelectListItem() { Text = text(f), Value = value(f) }).ToList().ToSelectList(selected);
		}
	}
}
