//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Represents the object that is passed as a parameter to the event handler that is invoked when the state of a signal line changes on the serial port.
    /// </summary>
    /// <remarks>
    /// At times, the state of a signal line can change on the serial port. For example, when the break state is enabled on the serial port causing data transmission to stop. The event is reported by invoking the app-implemented PinChanged event handler. That event handler's parameter is a PinChangedEventArgs object. Inspect the PinChange property to determine the type of signal line. Those values are defined in the SerialPinChange enumeration.
    /// </remarks>
    public sealed class PinChangedEventArgs : IPinChangedEventArgs
    {
        /// <summary>
        /// Gets the type of signal change that caused the event on the serial port.
        /// </summary>
        /// <value>
        /// One of the values defined in SerialPinChange enumeration.
        /// </value>
        public SerialPinChange PinChange { get; }
    }
}
