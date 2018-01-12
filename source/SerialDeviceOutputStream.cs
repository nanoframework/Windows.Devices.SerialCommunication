//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    internal class SerialDeviceOutputStream : IOutputStream
    {
        private readonly SerialDevice _serialDevice;

        // this field is updated in the native end
#pragma warning disable 0649
        private uint _unstoredBufferLength;
#pragma warning restore 0649

        public uint UnstoredBufferLength { get => _unstoredBufferLength; }

        public SerialDeviceOutputStream(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public bool Flush()
        {
            // call 'store' to UART
            _serialDevice.NativeStore();

            return true;
        }

        public void Write(byte[] buffer)
        {
            // write to UART stream
            _serialDevice.NativeWrite(buffer);
        }

        public uint Store()
        {
            // store to UART
            return _serialDevice.NativeStore();
        }
    }
}
