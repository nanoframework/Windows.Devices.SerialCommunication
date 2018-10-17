//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Defines values for error conditions that can occur on the serial port.
    /// </summary>
    public enum SerialError
    {
        /// <summary>
        /// A character-buffer overrun has occurred. The next character is lost.
        /// </summary>
        BufferOverrun,
        /// <summary>
        /// The hardware detected a framing error.
        /// </summary>
        Frame,
        /// <summary>
        /// An input buffer overflow has occurred. There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.
        /// </summary>
        ReceiveFull,
        /// <summary>
        /// The hardware detected a parity error.
        /// </summary>
        ReceiveParity,
        /// <summary>
        /// The application tried to transmit a character, but the output buffer was full.
        /// </summary>
        TransmitFull
    }
}
