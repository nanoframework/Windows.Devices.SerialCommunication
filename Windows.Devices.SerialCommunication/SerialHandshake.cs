//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Defines values for hardware and software flow control protocols used in serial communication. The values are used by Handshake property on the SerialDevice object.
    /// </summary>
    public enum SerialHandshake
    {
        /// <summary>
        /// No protocol is used for the handshake.
        /// </summary>
        None,
        /// <summary>
        /// When the port is receiving data and if the read buffer is full, the Request-to-Send (RTS) line is set to false. When buffer is available, the line is set to true. When the serial port is transmitting data, CTS line is set to false and the port does not send data until there is room in the write buffer.
        /// </summary>
        RequestToSend,
        /// <summary>
        /// Both RequestToSend and XOnXOff controls are used for flow control.
        /// </summary>
        RequestToSendXOnXOff,
        /// <summary>
        /// The serial port sends an Xoff control to inform the sender to stop sending data. When ready, the port sends an Xon control to inform he sender that the port is now ready to receive data.
        /// </summary>
        XOnXOff
    }
}
