//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //// THIS CLASS IS INTERNAL AND IT'S A MIRROR FROM THE ONE IN WINDOWS.STORAGE.STREAMS ////
    //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// Provides a byte array implementation of the IBuffer interface and its related interfaces.
    /// </summary>
    internal sealed class ByteBuffer : IBuffer
    {
        private byte[] _buffer;
        private uint _length;

        /// <summary>
        /// Initializes a new instance of the Buffer class with the specified capacity.
        /// </summary>
        /// <param name="capacity">The maximum number of bytes that the buffer can hold.</param>
        public ByteBuffer(UInt32 capacity)
        {
            _buffer = new byte[(int)capacity];
            _length = 0;
        }

        /// <summary>
        /// Gets the maximum number of bytes that the buffer can hold.
        /// </summary>
        /// <value>
        /// The maximum number of bytes that the buffer can hold.
        /// </value>
        public uint Capacity
        {
            get
            {
                return (uint)_buffer.Length;
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes currently in use in the buffer.
        /// </summary>
        /// <value>
        /// The number of bytes currently in use in the buffer, which is less than or equal to the capacity of the buffer.
        /// </value>
        public uint Length
        {
            get => _length;
            set => _length = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="byte[]"/> backing this <see cref="ByteBuffer"/>.
        /// </summary>
        /// <value>
        /// The <see cref="byte[]"/> backing this <see cref="ByteBuffer"/>.
        /// </value>
        public byte[] Data
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;
            }
        }
    }
}
