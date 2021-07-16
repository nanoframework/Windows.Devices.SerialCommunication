//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Runtime.Events;

namespace Windows.Devices.SerialCommunication
{
    internal class SerialDataEvent : BaseEvent
    {
        public int SerialDeviceIndex;
        public SerialData Event;
    }
}
