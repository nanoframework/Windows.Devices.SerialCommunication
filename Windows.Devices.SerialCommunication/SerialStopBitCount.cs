//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Defines values that indicate the number of stop bits used in a transmission. The values are used by the StopBits property on the SerialDevice object.
    /// </summary>
    public enum SerialStopBitCount
    {
        /// <summary>
        /// One stop bit is used.
        /// </summary>
        One,
        /// <summary>
        /// 1.5 stop bits are used.
        /// </summary>
        OnePointFive,
        /// <summary>
        /// Two stop bits are used.
        /// </summary>
        Two
    }
}
