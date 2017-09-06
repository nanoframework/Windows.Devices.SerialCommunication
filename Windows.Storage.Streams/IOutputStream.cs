//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Represents a sequential stream of bytes to be written.
    /// </summary>
    public interface IOutputStream
    {
        /// <summary>
        /// Flushes data in a sequential stream.
        /// </summary>
        /// <returns>The stream flush operation.</returns>
        /// <remarks>
        /// The Flush method may produce latencies and does not always guarantee durable and coherent storage of data. It's generally recommended to avoid this method if possible.
        /// </remarks>
        //IAsyncOperation<bool> FlushAsync()
        bool Flush();

        /// <summary>
        /// Writes data in a sequential stream.
        /// </summary>
        /// <param name="buffer">A buffer that contains the data to be written.</param>
        /// <returns>The byte writer operation.</returns>
        //IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
        uint Write(IBuffer buffer);

    }
}
