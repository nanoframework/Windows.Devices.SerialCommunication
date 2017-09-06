//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Specifies the type of character encoding for a stream.
    /// </summary>
    public enum UnicodeEncoding
    {
        /// <summary>
        /// The encoding is UTF-16, with the most significant byte first in the two eight-bit bytes.
        /// </summary>
        Utf16BE,
        /// <summary>
        /// The encoding is UTF-16, with the least significant byte first in the two eight-bit bytes.
        /// </summary>
        Utf16LE,
        /// <summary>
        /// The encoding is UTF-8.
        /// </summary>
        Utf8
    }
}
