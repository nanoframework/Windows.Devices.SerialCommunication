//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace Windows.Storage.Streams
{
    public sealed class DataReader : IDisposable, IDataReader
    {
        /// <summary>
        /// Creates and initializes a new instance of the data reader.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        public DataReader(IInputStream inputStream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the byte order of the data in the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        public ByteOrder ByteOrder { get; set; }

        /// <summary>
        /// Gets or sets the read options for the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        public InputStreamOptions InputStreamOptions { get; set; }

        /// <summary>
        /// Gets the size of the buffer that has not been read.
        /// </summary>
        /// <value>
        /// The size of the buffer that has not been read, in bytes.
        /// </value>
        public uint UnconsumedBufferLength { get; }

        /// <summary>
        /// Gets or sets the Unicode character encoding for the input stream.
        /// </summary>
        /// <value>
        /// One of the enumeration values.
        /// </value>
        public UnicodeEncoding UnicodeEncoding { get; set; }

        /// <summary>
        /// Closes the current stream and releases system resources.
        /// </summary>
        /// <remarks>
        /// DataReader takes ownership of the stream that is passed to its constructor. Calling this method also calls on the associated stream. After calling this method, calls to most other DataReader methods will fail.
        /// If you do not want the associated stream to be closed when the reader closes, call DataReader.DetachStream before calling this method.
        /// </remarks>
        public void Close()
        {
            // This member is not implemented in C#
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detaches a buffer that was previously attached to the reader.
        /// </summary>
        /// <returns>The detached buffer.</returns>
        public IBuffer DetachBuffer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Detaches a stream that was previously attached to the reader.
        /// </summary>
        /// <returns>The detached stream.</returns>
        public IInputStream DetachStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new instance of the data reader with data from the specified buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>The data reader.</returns>
        public static DataReader FromBuffer(IBuffer buffer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads data from the input stream.
        /// </summary>
        /// <param name="count">The count of bytes to load into the intermediate buffer.</param>
        /// <returns>The operation.</returns>
        //public DataReaderLoadOperation LoadAsync(UInt32 count)
        public uint Load(UInt32 count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a Boolean value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public bool ReadBoolean()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a buffer from the input stream.
        /// </summary>
        /// <param name="length">The length of the buffer, in bytes.</param>
        /// <returns>The buffer.</returns>
        public IBuffer ReadBuffer(UInt32 length)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a byte value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public byte ReadByte()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads an array of byte values from the input stream.
        /// </summary>
        /// <param name="value">The array of values.</param>
        public void ReadBytes(Byte[] value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a date and time value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public DateTimeOffset ReadDateTime()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public double ReadDouble()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a GUID value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public Guid ReadGuid()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 16-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public short ReadInt16()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 32-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public int ReadInt32()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 64-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public long ReadInt64()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public float ReadSingle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a string value from the input stream.
        /// </summary>
        /// <param name="codeUnitCount">The length of the string.</param>
        /// <returns>The value.</returns>
        public string ReadString(UInt32 codeUnitCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a time interval from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public TimeSpan ReadTimeSpan()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 16-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public ushort ReadUInt16()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public ushort ReadUInt32()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 64-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public ushort ReadUInt64()
        {
            throw new NotImplementedException();
        }
    }
}
