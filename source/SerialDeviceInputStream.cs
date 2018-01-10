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

        public SerialDeviceInputStream(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public uint Read(IBuffer buffer, uint count, InputStreamOptions options)
        {
            // read from the UART stream
            // get the Data field from the IBuffer
            return _serialDevice.NativeRead(((ByteBuffer)buffer).Data, (int)options);
        }
    }
}
