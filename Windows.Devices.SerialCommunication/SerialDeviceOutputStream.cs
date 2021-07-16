//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

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

        /// <inheritdoc/>
        public uint UnstoredBufferLength 
        { 
            get => _unstoredBufferLength;

            set
            {
                _unstoredBufferLength = value;
            }
        }

        public SerialDeviceOutputStream(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
            _unstoredBufferLength = 0;
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
