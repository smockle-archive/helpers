using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

/* ListHelpers
 * C# extension methods for the List type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class ListHelpers {
		/// <summary>
		/// Converts a List of SelectListItems into a SelectList.
		/// </summary>
		/// <param name="l">List to convert.</param>
		public static SelectList ToSelectList(this List<SelectListItem> l) {
			return new SelectList(l, "Value", "Text");
		}

		/// <summary>
		/// Converts a List of SelectListItems into a SelectList.
		/// </summary>
		/// <param name="l">List to convert.</param>
		/// <param name="selected">Value of the default option. [Or text of the default option; I can't remember.]</param>
		public static SelectList ToSelectList(this List<SelectListItem> l, int selected) {
			return new SelectList(l, "Value", "Text", selected);
		}

		/// <summary>
		/// Converts a List of SelectListItems into a SelectList.
		/// </summary>
		/// <param name="l">List to convert.</param>
		/// <param name="selected">Value of the default option. [Or text of the default option; I can't remember.]</param>
		public static SelectList ToSelectList(this List<SelectListItem> l, string selected) {
			return new SelectList(l, "Value", "Text", selected);
		}
	}
}
