using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/* StreamHelpers
 * C# extension methods for the Stream type.
 * Copyright © 2013 Clay Miller (clay@smockle.com)
 */

namespace Smockle.Helpers {
	public static class StreamHelpers {
		/// <summary>
		/// Converts a stream to a byte array.
		/// </summary>
		/// <param name="stream">Stream to convert.</param>
		public static byte[] ToBytes(this Stream stream) {
			var memStream = new MemoryStream();
			stream.CopyTo(memStream);
			return memStream.ToArray();
		}

		/// <summary>
		/// Converts a stream to a string.
		/// </summary>
		/// <param name="stream">Stream to convert.</param>
		/// <param name="b">Required to overwrite default ToString function. Value is irrelevant.</param>
		public static string ToString(this Stream stream, bool b) {
			stream.Position = 0;
			StreamReader reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}
