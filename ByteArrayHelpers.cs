using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* ByteArrayHelpers
 * C# extension methods for the byte[] type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class ByteArrayHelpers {
		/// <summary>
		/// Converts a byte array to a string.
		/// </summary>
		/// <param name="bytes">Byte array to convert.</param>
		/// <param name="b">Required to overwrite default ToString function. Value is irrelevant.</param>
		public static string ToString(this byte[] bytes, bool b) {
			char[] chars = new char[bytes.Length];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}
	}
}
