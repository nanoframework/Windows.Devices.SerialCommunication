//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Collections;

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// This class is used to keep tabs on what serial ports are open.
    /// </summary>
    internal sealed class SerialDeviceController
    {
        // this is used as the lock object 
        // a lock is required because multiple threads can access the I2C controller
        readonly static object _syncLock = new object();

        // we can have only one instance of the SerialDeviceController
        // need to do a lazy initialization of this field to make sure it exists when called elsewhere.
        private static SerialDeviceController s_instance;

        // backing field for DeviceCollection
        private static Hashtable s_deviceCollection;

        /// <summary>
        /// Device collection associated with this <see cref="SerialDeviceController"/>.
        /// </summary>
        /// <remarks>
        /// This collection is for internal use only.
        /// </remarks>
        internal static Hashtable DeviceCollection
        {
            get
            {
                if (s_deviceCollection == null)
                {
                    lock (_syncLock)
                    {
                        if (s_deviceCollection == null)
                        {
                            s_deviceCollection = new Hashtable();
                        }
                    }
                }

                return s_deviceCollection;
            }

            set
            {
                s_deviceCollection = value;
            }
        }

        /// <summary>
        /// Gets the default serial device controller for the system.
        /// </summary>
        /// <returns>The default GPIO controller for the system, or null if the system has no GPIO controller.</returns>
        internal static SerialDeviceController GetDefault()
        {
            if (s_instance == null)
            {
                lock (_syncLock)
                {
                    if (s_instance == null)
                    {
                        s_instance = new SerialDeviceController();
                    }
                }
            }

            return s_instance;
        }
    }
}
