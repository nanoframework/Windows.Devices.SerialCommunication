//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Provides read access to an input stream.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Gets or sets the byte order of the data in the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        ByteOrder ByteOrder { get; set; }

        /// <summary>
        /// Gets or sets the read options for the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        InputStreamOptions InputStreamOptions { get; set; }

        /// <summary>
        /// Gets the size of the buffer that has not been read.
        /// </summary>
        /// <value>
        /// The size of the buffer that has not been read, in bytes.
        /// </value>
        uint UnconsumedBufferLength { get; }

        /// <summary>
        /// Gets or sets the Unicode character encoding for the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        UnicodeEncoding UnicodeEncoding { get; set; }

        /// <summary>
        /// Detaches a buffer that was previously attached to the reader.
        /// </summary>
        /// <returns>The detached buffer.</returns>
        IBuffer DetachBuffer();

        /// <summary>
        /// Detaches a stream that was previously attached to the reader.
        /// </summary>
        /// <returns>The detached stream.</returns>
        IInputStream DetachStream();

        /// <summary>
        /// Loads data from the input stream.
        /// </summary>
        /// <param name="count">The count of bytes to load into the intermediate buffer.</param>
        /// <returns>The asynchronous operation.</returns>
        //DataReaderLoadOperation LoadAsync(UInt32 count);
        uint Load(UInt32 count)

        /// <summary>
        /// Reads a Boolean value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        bool ReadBoolean();

        /// <summary>
        /// Reads a buffer from the input stream.
        /// </summary>
        /// <param name="length">The length of the buffer, in bytes.</param>
        /// <returns>The buffer.</returns>
        IBuffer ReadBuffer(UInt32 length);

        /// <summary>
        /// Reads a byte value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        byte ReadByte();

        /// <summary>
        /// Reads an array of byte values from the input stream.
        /// </summary>
        /// <param name="value">The array of values.</param>
        void ReadBytes(Byte[] value);

        /// <summary>
        /// Reads a date and time value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        DateTimeOffset ReadDateTime();

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        double ReadDouble();

        /// <summary>
        /// Reads a GUID value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        Guid ReadGuid();

        /// <summary>
        /// Reads a 16-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        short ReadInt16();

        /// <summary>
        /// Reads a 32-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        int ReadInt32();

        /// <summary>
        /// Reads a 64-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        long ReadInt64();

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        float ReadSingle();

        /// <summary>
        /// Reads a string value from the input stream.
        /// </summary>
        /// <param name="codeUnitCount">The length of the string.</param>
        /// <returns>The value.</returns>
        string ReadString(UInt32 codeUnitCount);

        /// <summary>
        /// Reads a time interval from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        TimeSpan ReadTimeSpan();

        /// <summary>
        /// Reads a 16-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        ushort ReadUInt16();

        /// <summary>
        /// Reads a 32-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        ushort ReadUInt32();

        /// <summary>
        /// Reads a 64-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        ushort ReadUInt64();

    }
}
