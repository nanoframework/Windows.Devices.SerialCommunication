//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Represents a referenced array of bytes used by byte stream read and write interfaces. Buffer is the class implementation of this interface.
    /// </summary>
    public interface IBuffer
    {
        /// <summary>
        /// Gets the maximum number of bytes that the buffer can hold.
        /// </summary>
        /// <value>
        /// The maximum number of bytes that the buffer can hold.
        /// </value>
        uint Capacity { get; }
        /// <summary>
        /// Gets the number of bytes currently in use in the buffer.
        /// </summary>
        /// <value>
        /// The number of bytes currently in use in the buffer which is less than or equal to the capacity of the buffer.
        /// </value>
        uint Length { get; set; }
    }
}
