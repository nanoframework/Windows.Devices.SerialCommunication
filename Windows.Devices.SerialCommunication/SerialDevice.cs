//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Represents a serial port. The object provides methods and properties that an app can use to find the port (in the system).
    /// </summary>
    public sealed class SerialDevice : ISerialDevice, IDisposable
    {
        /// <summary>
        /// Gets or sets the baud rate.
        /// </summary>
        /// <value>
        /// The baud rate of the serial port.
        /// </value>
        /// <remarks>
        /// The property is set on the SerialDevice object that represents the serial port. The baud rate must be supported by the serial port. To see the possible values, in Device Manager, open the Port Settings tab of the COM port.
        /// </remarks>
        public uint BaudRate { get; set; }

        /// <summary>
        /// Gets or sets the break signal state.
        /// </summary>
        /// <value>
        /// Toggles the TX line to enable or disable data transmission.
        /// </value>
        /// <remarks>
        /// In serial communication, the break signal state is used to toggle the TX line. To suspend data transmission, set the property value to true. In that state, you cannot write to the serial port. To resume transmission, set to false.
        /// </remarks>
        public bool BreakSignalState { get; set; }

        /// <summary>
        /// Represents the number of bytes received by the last read operation of the input stream.
        /// </summary>
        /// <value>
        /// The number of bytes received by the last read operation of the input stream.
        /// </value>
        public uint BytesReceived { get; }

        /// <summary>
        /// Gets the state of the Carrier Detect (CD) line.
        /// </summary>
        /// <value>
        /// Detects the state of Carrier Detect line. If the line is detected, value is true; otherwise, false.
        /// </value>
        public bool CarrierDetectState { get; }

        /// <summary>
        /// Gets the state of the Clear-to-Send (CTS) line.
        /// </summary>
        /// <value>
        /// Detects the state of Clear-to-Send line. If the line is detected, value is true; otherwise, false.
        /// </value>
        public bool ClearToSendState { get; }

        /// <summary>
        /// The number of data bits in each character value that is transmitted or received, and does not include parity bits or stop bits.
        /// </summary>
        /// <value>
        /// The number of data bits in each character value that is transmitted or received.
        /// </value>
        /// <remarks>
        /// DataBits corresponds to the WordLength member of the SERIAL_LINE_CONTROL structure.
        /// </remarks>
        public ushort DataBits { get; set; }

        /// <summary>
        /// Gets the state of the Data Set Ready (DSR) signal.
        /// </summary>
        /// <value>
        /// Indicates whether DSR has been sent to the serial port. If the signal was sent, value is true; otherwise, false.
        /// </value>
        public bool DataSetReadyState { get; }

        /// <summary>
        /// Gets or sets the handshaking protocol for flow control.
        /// </summary>
        /// <value>
        /// One of the values defined in SerialHandshake enumeration.
        /// </value>
        public SerialHandshake Handshake { get; set; }

        /// <summary>
        /// Input stream that contains the data received on the serial port.
        /// </summary>
        /// <value>
        /// Input stream that contains the data received.
        /// </value>
        /// <remarks>
        /// To access data received on the port, get the input stream from SerialDevice object, and then use the DataReader to read data.
        /// </remarks>
        public IInputStream InputStream { get; }

        /// <summary>
        /// Gets or sets a value that enables the Data Terminal Ready (DTR) signal.
        /// </summary>
        /// <value>
        /// Enables or disables the Data Terminal Ready (DTR) signal. true enables DTR; Otherwise, false.
        /// </value>
        public bool IsDataTerminalReadyEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value that enables the Request to Send (RTS) signal.
        /// </summary>
        /// <value>
        /// Enables or disables the Request to Send (RTS) signal. true enables DTR; Otherwise, false.
        /// </value>
        public bool IsRequestToSendEnabled { get; set; }

        /// <summary>
        /// Enables or disables the Request to Send (RTS) signal. true enables DTR; Otherwise, false.
        /// </summary>
        /// <remarks>
        /// To write data, first get the output stream from the SerialDevice object by using OutputStream property and then use the DataWriter object to write the actual buffer.
        /// </remarks>
        public IOutputStream OutputStream { get; }

        /// <summary>
        /// Gets or sets the parity bit for error-checking.
        /// </summary>
        /// <value>
        /// One of the values defined in SerialParity enumeration.
        /// </value>
        /// <remarks>
        /// In serial communication, the parity bit is used as an error-checking procedure. In data transmission that uses parity checking, the bit format is 7 data bits-x-1 stop bit, where x is the parity bit. That bit indicates whether the number of 1s in the data byte is even or odd. The parity bit can be E (even), O (odd), M (mark), or S (space). Those values are defined in the SerialParity enumeration.
        /// For example, if the format is 7-E-1 and the data bits are 0001000, the parity bit is set to 1 to make sure there are even number of 1s.
        /// </remarks>
        public SerialParity Parity { get; set; }

        /// <summary>
        /// Gets the port name for serial communications.
        /// </summary>
        /// <value>
        /// The communication port name. For example "COM1".
        /// </value>
        public string PortName { get; }

        /// <summary>
        /// Gets or sets the time-out value for a read operation.
        /// </summary>
        /// <value>
        /// The span of time before a time-out occurs when a read operation does not finish.
        /// </value>
        public TimeSpan ReadTimeout { get; set; }

        /// <summary>
        /// Gets or sets the standard number of stop bits per byte.
        /// </summary>
        /// <value>
        /// One of the values defined in the SerialStopBitCount enumeration.
        /// </value>
        /// <remarks>
        /// In serial communication, a transmission begins with a start bit, followed by 8 bits of data, and ends with a stop bit. The purpose of the stop bit is to separate each unit of data or to indicate that no data is available for transmission.
        /// </remarks>
        public SerialStopBitCount StopBits { get; set; }

        /// <summary>
        /// Gets the idProduct field of the USB device descriptor. This value indicates the device-specific product identifier and is assigned by the manufacturer.
        /// </summary>
        /// <value>
        /// The device-defined product identifier.
        /// </value>
        public ushort UsbProductId { get; }

        /// <summary>
        /// Gets the idVendor field of the USB device descriptor. The value indicates the vendor identifier for the device as assigned by the USB specification committee.
        /// </summary>
        /// <value>
        /// The vendor identifier for the device as assigned by the USB specification committee.
        /// </value>
        public ushort UsbVendorId { get; }

        /// <summary>
        /// Gets or sets the time-out value for a write operation.
        /// </summary>
        /// <value>
        /// The span of time before a time-out occurs when a write operation does not finish.
        /// </value>
        public TimeSpan WriteTimeout { get; set; }

        /// <summary>
        /// Releases the reference to the SerialDevice object that was previously obtained by calling FromIdAsync.
        /// </summary>
        public void Close()
        {
            //This member is not implemented in C#
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts an asynchronous operation that creates a SerialDevice object.
        /// </summary>
        /// <param name="deviceId">The device instance path of the device. To obtain that value, get the DeviceInformation.Id property value.</param>
        /// <returns>
        /// IAsyncOperation<SerialDevice> 
        /// Returns an IAsyncOperation(SerialDevice) object that returns the results of the operation.
        /// </returns>
        public static SerialDevice FromId(String deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an Advanced Query Syntax (AQS) string that the app can pass to DeviceInformation.FindAllAsync in order to find all serial devices on the system.
        /// </summary>
        /// <returns>
        /// String formatted as an AQS query.
        /// </returns>
        public static string GetDeviceSelector()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an Advanced Query Syntax (AQS) string that the app can pass to DeviceInformation.FindAllAsync in order to find a serial device by specifying its port name.
        /// </summary>
        /// <param name="portName">The serial port name. For example, "COM1".</param>
        /// <returns>String formatted as an AQS query.</returns>
        public static string GetDeviceSelector(String portName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an Advanced Query Syntax (AQS) string that the app can pass to DeviceInformation.FindAllAsync in order to find a specific Serial-to-USB device by specifying it's VID and PID.
        /// </summary>
        /// <param name="vendorId">Specifies the vendor identifier for the device as assigned by the USB specification committee. Possible values are 0 through 0xffff.</param>
        /// <param name="productId">Specifies the product identifier. This value is assigned by the manufacturer and is device-specific. Possible values are 0 through 0xffff.</param>
        /// <returns>String formatted as an AQS query.</returns>
        public static string GetDeviceSelectorFromUsbVidPid(UInt16 vendorId, UInt16 productId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event handler that is invoked when error occurs on the serial port.
        /// </summary>
        /// <remarks>
        /// This event is used to detect and respond to errors when communicating data through a serial port. When an error condition occurs, the ErrorReceived event handler is invoked and error information is received in an ErrorReceivedEventArgs object. Determine the type of error by retrieving the Error property of the ErrorReceivedEventArgs class. Those property values are defined in the SerialError enumeration.
        /// </remarks>
        public event TypedEventHandler<SerialDevice, ErrorReceivedEventArgs> ErrorReceived;

        /// <summary>
        /// Event handler that is invoked when the state of a signal or line changes on the serial port.
        /// </summary>
        /// <remarks>
        /// This event is used to detect and respond to changes in the signal state of the serial port. When state changes, the PinChanged event handler is invoked and information is received in a PinChangedEventArgs object. Determine the type of signal by retrieving the PinChange property. Those property values are defined in the SerialPinChange enumeration.
        /// </remarks>
        public event TypedEventHandler<SerialDevice, PinChangedEventArgs> PinChanged;
    }
}
