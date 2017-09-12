//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Provides write access to an output stream.
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Gets or sets the byte order of the data in the output stream.
        /// </summary>
        /// <value>One of the enumeration values.</value>
        ByteOrder ByteOrder { get; set; }

        /// <summary>
        /// Gets or sets the Unicode character encoding for the output stream.
        /// </summary>
        /// /// <value>One of the enumeration values.</value>
        UnicodeEncoding UnicodeEncoding { get; set; }

        /// <summary>
        /// Gets the size of the buffer that has not been used.
        /// </summary>
        /// <value>The available buffer length, in bytes.</value>
        uint UnstoredBufferLength { get; }

        /// <summary>
        /// Detaches a buffer that was previously attached to the writer.
        /// </summary>
        /// <returns>The detached buffer.</returns>
        IBuffer DetachBuffer();

        /// <summary>
        /// Detaches a stream that was previously attached to the writer.
        /// </summary>
        /// <returns>The detached stream.</returns>
        IOutputStream DetachStream();

        /// <summary>
        /// Flushes data.
        /// </summary>
        /// <returns>The stream flush operation.</returns>
        /// <remarks>
        /// The Flush method ensures that the data has reached the target storage medium that the stream represents. For example, to improve application responsiveness and throughput, a file stream might respond to a write operation by copying the buffer into another temporary storage medium and returning immediately, while the target device begins writing the data concurrently.
        /// The Flush method doesn't complete until all data specified in previous write calls has reached the target storage medium. If the data can't be written, or an error occurred during a write operation, the method returns false.
        /// The Flush method may produce latencies and does not always guarantee durable and coherent storage of data.It's generally recommended to avoid this method if possible.
        /// </remarks>
        //IAsyncOperation<bool> FlushAsync();
        bool Flush();

        /// <summary>
        /// Gets the size of a string.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <returns>The size of the string, in bytes.</returns>
        uint MeasureString(String value);

        /// <summary>
        /// Commits data in the buffer to a backing store.
        /// </summary>
        /// <returns>The store data operation.</returns>
        //DataWriterStoreOperation StoreAsync();
        uint Store();

        /// <summary>
        /// Writes a Boolean value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteBoolean(Boolean value);

        /// <summary>
        /// Writes a number of bytes from a buffer to the output stream.
        /// </summary>
        /// <param name="buffer">The value to write.</param>
        void WriteBuffer(IBuffer buffer);

        /// <summary>
        /// Writes a range of bytes from a buffer to the output stream.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="start">The starting byte to be written.</param>
        /// <param name="count">The number of bytes to write.</param>
        void WriteBuffer(IBuffer buffer, UInt32 start, UInt32 count);

        /// <summary>
        /// Writes a byte value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteByte(Byte value);

        /// <summary>
        /// Writes an array of byte values to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteBytes(Byte[] value);

        /// <summary>
        /// Writes a date and time value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteDateTime(DateTime value);

        /// <summary>
        /// Writes a floating-point value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteDouble(Double value);

        /// <summary>
        /// Writes a GUID value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteGuid(Guid value);

        /// <summary>
        /// Writes a 16-bit integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteInt16(Int16 value);

        /// <summary>
        /// Writes a 32-bit integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteInt32(Int32 value);

        /// <summary>
        /// Writes a 64-bit integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteInt64(Int64 value);

        /// <summary>
        /// Write a floating-point value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteSingle(Single value);

        /// <summary>
        /// Writes a string value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>The length of the string.</returns>
        uint WriteString(String value);

        /// <summary>
        /// Writes a time interval value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteTimeSpan(TimeSpan value);

        /// <summary>
        /// Writes a 16-bit unsigned integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteUInt16(UInt16 value);

        /// <summary>
        /// Writes a 32-bit unsigned integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteUInt32(UInt32 value);

        /// <summary>
        /// Writes a 64-bit unsigned integer value to the output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        void WriteUInt64(UInt64 value);


    }
}
