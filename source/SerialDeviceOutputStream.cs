//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    internal class SerialDeviceOutputStream : IOutputStream
    {
        private readonly SerialDevice _serialDevice;

        public SerialDeviceOutputStream(SerialDevice serialDevice)
        {
            _serialDevice = serialDevice;
        }

        public bool Flush()
        {
            throw new System.NotImplementedException();
        }

        public void Write(ref byte[] buffer)
        {
            _serialDevice.NativeWrite(buffer, buffer.Length);
        }
    }
}
