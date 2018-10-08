//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Runtime.Events;
using System;
using System.Collections;

namespace Windows.Devices.SerialCommunication
{
    internal class SerialDeviceEventListener : IEventProcessor, IEventListener
    {
        // Map of serial device numbers to SerialDevice objects.
        private Hashtable _serialDevicesMap = new Hashtable();

        public SerialDeviceEventListener()
        {
            EventSink.AddEventProcessor(EventCategory.SerialDevice, this);
            EventSink.AddEventListener(EventCategory.SerialDevice, this);
        }

        public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time)
        {
            return new SerialDataEvent
            {
                // Data1 is packed by PostManagedEvent, so we need to unpack the high word.
                SerialDeviceIndex = (int)(data1 >> 16),
                Event = (SerialData)data2
            };
        }

        public void InitializeForEventSource()
        {
        }

        public bool OnEvent(BaseEvent ev)
        {
            var serialDataEvent = (SerialDataEvent)ev;
            SerialDevice device = null;

            lock (_serialDevicesMap)
            {
                if (_serialDevicesMap.Contains(serialDataEvent.SerialDeviceIndex))
                {
                    device = (SerialDevice)_serialDevicesMap[serialDataEvent.SerialDeviceIndex];
                }
            }

            // Avoid calling this under a lock to prevent a potential lock inversion.
            if (device != null)
            {
                device.OnSerialDataReceivedInternal(serialDataEvent.Event);
            }

            return true;
        }

        public void AddSerialDevice(SerialDevice device)
        {
            lock (_serialDevicesMap)
            {
                _serialDevicesMap[device._portIndex] = device;
            }
        }

        public void RemoveSerialDevice(int index)
        {
            lock (_serialDevicesMap)
            {
                if (_serialDevicesMap.Contains(index))
                {
                    _serialDevicesMap.Remove(index);
                }
            }
        }
    }
}
