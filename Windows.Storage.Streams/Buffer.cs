//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Provides a default implementation of the IBuffer interface and its related interfaces.
    /// </summary>
    public sealed class Buffer : IBuffer
    {
        /// <summary>
        /// Initializes a new instance of the Buffer class with the specified capacity.
        /// </summary>
        /// <param name="capacity">The maximum number of bytes that the buffer can hold.</param>
        public Buffer(UInt32 capacity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the maximum number of bytes that the buffer can hold.
        /// </summary>
        /// <value>
        /// The maximum number of bytes that the buffer can hold.
        /// </value>
        public uint Capacity { get; }

        /// <summary>
        /// Gets the number of bytes currently in use in the buffer.
        /// </summary>
        /// <value>
        /// The number of bytes currently in use in the buffer, which is less than or equal to the capacity of the buffer.
        /// </value>
        public uint Length { get; set; }

        ///// <summary>
        ///// Creates a new buffer containing a copy of a specified buffer.
        ///// </summary>
        ///// <param name="input">The buffer to be copied.</param>
        ///// <returns>The newly created copy.</returns>
        //public static Buffer CreateCopyFromMemoryBuffer(IMemoryBuffer input)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Creates a MemoryBuffer from an existing IBuffer.
        ///// </summary>
        ///// <param name="input">The input IBuffer.</param>
        ///// <returns>The newly created MemoryBuffer.</returns>
        //public static MemoryBuffer CreateMemoryBufferOverIBuffer(IBuffer input)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
