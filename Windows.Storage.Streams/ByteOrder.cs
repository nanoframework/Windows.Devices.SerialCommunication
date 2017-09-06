//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Specifies the byte order of a stream.
    /// </summary>
    public enum ByteOrder
    {
        /// <summary>
        /// The most significant byte (highest address) is stored first.
        /// </summary>
        BigEndian,
        /// <summary>
        /// The least significant byte (lowest address) is stored first.
        /// </summary>
        LittleEndian
    }
}
