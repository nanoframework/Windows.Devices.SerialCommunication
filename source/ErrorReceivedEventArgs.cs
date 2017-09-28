//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Represents the object that is passed as a parameter to the event handler that is invoked when error occurs on the serial port.
    /// </summary>
    /// <remarks>
    /// ErrorReceivedEventArgs is used to determine the type of error condition. When error occurs on the port, the previously registered ErrorReceived event handler is invoked. That event handler's parameter is a ErrorReceivedEventArgs object. After the event handler is invoked, you can determine the error condition by using the Error property.
    /// </remarks>
    public sealed class ErrorReceivedEventArgs : IErrorReceivedEventArgs
    {
        /// <summary>
        /// Gets the character type received that caused the event on the serial port.
        /// </summary>
        /// <value>
        /// One of the values defined in the SerialError enumeration.
        /// </value>
        public SerialError Error { get; }
    }
}
