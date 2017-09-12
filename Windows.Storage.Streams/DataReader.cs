//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Text;

namespace Windows.Storage.Streams
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DataReader : IDisposable, IDataReader
    {

        private byte[] bufferData;
        private Buffer buffer;
        private int currentPosition;
        private IInputStream stream;


        /// <summary>
        /// Creates and initializes a new instance of the data reader.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        public DataReader(IInputStream inputStream)
        {
            stream = inputStream ?? throw new ArgumentNullException("inputStream");
            ResetBufferData();
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
            IInputStream inputStream = stream;
            stream = null;
            return inputStream;
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
            if (stream == null)
            {
                throw new InvalidOperationException();
            }
            if (bufferData.Length < count)
            {
                int size = 128;
                while (size < (count + UnconsumedBufferLength))
                {
                    size *= 2;
                }
                byte[] byteArray = new byte[size];
                Array.Copy(bufferData, currentPosition, byteArray, 0, (int)UnconsumedBufferLength);
                currentPosition = 0;
                bufferData = byteArray;
            }
            IBuffer buffer = stream.Read(SyncBuffer(), count, InputStreamOptions);
            return (uint)bufferData.Length;
        }



        private void ResetBufferData()
        {
            bufferData = new byte[128];
            currentPosition = 0;
            SyncBuffer();
        }

        private Buffer SyncBuffer()
        {
            throw new NotImplementedException();
        }

        private int IncreasePosition(int count)
        {
            if (UnconsumedBufferLength < count)
            {
                throw new IndexOutOfRangeException();
            }
            int newPosition = currentPosition;
            currentPosition += count;
            return newPosition;
        }




        /// <summary>
        /// Reads a Boolean value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public bool ReadBoolean()
        {
            return bufferData[IncreasePosition(1)] > 0;
        }

        /// <summary>
        /// Reads a buffer from the input stream.
        /// </summary>
        /// <param name="length">The length of the buffer, in bytes.</param>
        /// <returns>The buffer.</returns>
        public IBuffer ReadBuffer(UInt32 length)
        {
            //byte[] byteArray = new byte[length];
            //ReadBytes(byteArray);
            //return new Buffer(byteArray, 0, length);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a byte value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public byte ReadByte()
        {
            return bufferData[IncreasePosition(1)];
    }

        /// <summary>
        /// Reads an array of byte values from the input stream.
        /// </summary>
        /// <param name="value">The array of values.</param>
        public void ReadBytes(Byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Array.Copy(bufferData, IncreasePosition(value.Length), value, 0, value.Length);
        }

        /// <summary>
        /// Reads a date and time value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public DateTime ReadDateTime()
        {
            return new DateTime(ReadInt64());
        }

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public double ReadDouble()
        {
            return BitConverter.ToDouble(bufferData, IncreasePosition(8));
        }

        /// <summary>
        /// Reads a GUID value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public Guid ReadGuid()
        {
            byte[] byteArray = new byte[16];
            ReadBytes(byteArray);
            return new Guid(byteArray);
        }

        /// <summary>
        /// Reads a 16-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public short ReadInt16()
        {
            return BitConverter.ToInt16(bufferData, IncreasePosition(2));
        }

        /// <summary>
        /// Reads a 32-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public int ReadInt32()
        {
            return BitConverter.ToInt32(bufferData, IncreasePosition(4));
    }

        /// <summary>
        /// Reads a 64-bit integer value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public long ReadInt64()
        {
            return BitConverter.ToInt64(bufferData, IncreasePosition(8));
    }

        /// <summary>
        /// Reads a floating-point value from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public float ReadSingle()
        {
            return BitConverter.ToSingle(bufferData, IncreasePosition(4));
        }

        /// <summary>
        /// Reads a string value from the input stream.
        /// </summary>
        /// <param name="codeUnitCount">The length of the string.</param>
        /// <returns>The value.</returns>
        public string ReadString(UInt32 codeUnitCount)
        {
            return new string(Encoding.UTF8.GetChars(bufferData, IncreasePosition((int)codeUnitCount), (int)codeUnitCount));
        }

        /// <summary>
        /// Reads a time interval from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public TimeSpan ReadTimeSpan()
        {
            return new TimeSpan(ReadInt64());
    }

        /// <summary>
        /// Reads a 16-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(bufferData, IncreasePosition(2));
        }

        /// <summary>
        /// Reads a 32-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public uint ReadUInt32()
        {
            return BitConverter.ToUInt32(bufferData, IncreasePosition(4));
        }

        /// <summary>
        /// Reads a 64-bit unsigned integer from the input stream.
        /// </summary>
        /// <returns>The value.</returns>
        public ulong ReadUInt64()
        {
            return BitConverter.ToUInt64(bufferData, IncreasePosition(8));
        }
    }
}
