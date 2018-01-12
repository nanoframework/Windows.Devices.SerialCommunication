//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    internal class SerialDeviceInputStream : IInputStream
    {
        private readonly SerialDevice _serialDevice;

        // this field is updated in the native end
#pragma warning disable 0649
        private uint _unstoredBufferLength;
#pragma warning restore 0649

        public uint UnstoredBufferLength { get => _unstoredBufferLength; }

        public SerialDeviceInputStream(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public uint Read(IBuffer buffer, uint count, InputStreamOptions options)
        {
            // read from the UART stream
            // get the Data field from the IBuffer
            var bytesReceived = _serialDevice.NativeRead(((ByteBuffer)buffer).Data, (int)count, (int)options);

            // need to update this field in the parent
            _serialDevice._bytesReceived = bytesReceived;

            return bytesReceived;
        }
    }
}
