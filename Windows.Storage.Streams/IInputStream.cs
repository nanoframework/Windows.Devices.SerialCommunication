//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Storage.Streams
{
    public interface IInputStream
    {
        /// <summary>
        /// Reads data from the stream.
        /// </summary>
        /// <param name="buffer">A buffer that may be used to return the bytes that are read. The return value contains the buffer that holds the results.</param>
        /// <param name="count">The number of bytes to read that is less than or equal to the Capacity value.</param>
        /// <param name="options">Specifies the type of the asynchronous read operation.</param>
        /// <returns>The Buffer</returns>
        /// <remarks>
        /// Don't assume that the input buffer contains the data. Depending on the implementation, the data that's read might be placed into the input buffer, or it might be returned in a different buffer. For the input buffer, you don't have to implement the IBuffer interface. Instead, you can create an instance of the Buffer class.
        /// </remarks>
        //IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, UInt32 count, InputStreamOptions options);
        IBuffer Read(IBuffer buffer, UInt32 count, InputStreamOptions options);
    }
}
