//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Provides data for the <see cref="SerialDevice.DataReceived"/> event.
    /// </summary>
    /// <remarks>
    /// This method is specific to nanoFramework. There is no equivalent method in the UWP API.
    /// </remarks>
    public class SerialDataReceivedEventArgs
    {
        SerialData _data;

        internal SerialDataReceivedEventArgs(SerialData dataValue)
        {
            _data = dataValue;
        }

        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        public SerialData EventType { get { return _data; } }
    }

    /// <summary>
    /// Specifies the type of character that was received on the <see cref="SerialDeviceInputStream"/> serial port of a <see cref="SerialDevice"/> object.
    /// </summary>
    /// <remarks>
    /// This enum is specific to nanoFramework. There is no equivalent in the UWP API.
    /// </remarks>
    public enum SerialData
    {
        /// <summary>
        /// A character was received and placed in the input stream.
        /// </summary>
        Chars,

        /// <summary>
        /// The character to watch was received and placed in the input stream.
        /// </summary>
        WatchChar,
    }
}
