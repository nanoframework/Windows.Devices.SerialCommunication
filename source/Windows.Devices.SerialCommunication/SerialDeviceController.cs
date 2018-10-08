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
        // we can have only one instance of the SerialDeviceController
        private static SerialDeviceController s_instance = new SerialDeviceController();

        internal static Hashtable s_deviceCollection = new Hashtable();

        /// <summary>
        /// Gets the default serial device controller for the system.
        /// </summary>
        /// <returns>The default GPIO controller for the system, or null if the system has no GPIO controller.</returns>
        internal static SerialDeviceController GetDefault()
        {
            return s_instance;
        }
    }
}
