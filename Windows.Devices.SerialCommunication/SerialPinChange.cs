//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Defines values for types of signal state changes on the serial port.
    /// </summary>
    public enum SerialPinChange
    {
        /// <summary>
        /// Change in the break signal state.
        /// </summary>
        BreakSignal,
        /// <summary>
        /// Change in the Carrier Detect line for the port.
        /// </summary>
        CarrierDetect,
        /// <summary>
        /// Change in the Clear-to-Send line for the port.
        /// </summary>
        ClearToSend,
        /// <summary>
        /// Change in the state of the Data Set Ready (DSR) signal.
        /// </summary>
        DataSetReady,
        /// <summary>
        /// Change in the ring indicator state.
        /// </summary>
        RingIndicator
    }
}
