//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using nanoFramework.Runtime.Events;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    // This should be a TypedEventHandler "EventHandler<SerialDataReceivedEventHandler>"
    #pragma warning disable 1591
    public delegate void SerialDataReceivedEventHandler(
            Object sender,
            SerialDataReceivedEventArgs e);

    #pragma warning restore 1591

    /// <summary>
    /// Represents a serial port. The object provides methods and properties that an app can use to find the port (in the system).
    /// </summary>
    public sealed class SerialDevice : IDisposable
    {
        private static SerialDeviceEventListener s_eventListener = new SerialDeviceEventListener();

        private bool _disposed;

        // this is used as the lock object 
        // a lock is required because multiple threads can access the SerialDevice
        private object _syncLock = new object();
        
        // flag to signal an open serial port
        private bool _opened;

        private readonly string _deviceId;
        internal readonly int _portIndex;
        private readonly IOutputStream _outputStream;
        private readonly IInputStream _inputStream;

        private TimeSpan _readTimeout = Timeout.InfiniteTimeSpan;
        private TimeSpan _writeTimeout = Timeout.InfiniteTimeSpan;
        private uint _baudRate = 9600;
        private ushort _dataBits = 8;
        private SerialHandshake _handshake = SerialHandshake.None;
        private SerialParity _parity = SerialParity.None;
        private SerialStopBitCount _stopBits = SerialStopBitCount.One;
        internal uint _bytesReceived;
        private char _watchChar;

        private SerialDataReceivedEventHandler _callbacksDataReceivedEvent = null;

        internal SerialDevice(string deviceId)
        {
            // check if this device is already opened
            if (!SerialDeviceController.DeviceCollection.Contains(deviceId))
            {
                _deviceId = deviceId;

                // the UART name is an ASCII string with the COM port name in format 'COMn'
                // need to grab 'n' from the string and convert that to the integer value from the ASCII code (do this by subtracting 48 from the char value)
                _portIndex = (deviceId[3] - 48);

                NativeInit();

                // add the serial device to the event listener in order to receive the callbacks from the native interrupts
                s_eventListener.AddSerialDevice(this);

                _outputStream = new SerialDeviceOutputStream(this);
                _inputStream = new SerialDeviceInputStream(this);

                // add serial device to collection
                SerialDeviceController.DeviceCollection.Add(deviceId, this);
            }
            else
            {
                // this device already exists throw an exception
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Sets a character to watch for in the incoming data stream.
        /// </summary>
        /// <remarks>
        /// This property is specific to nanoFramework. There is no equivalent in the UWP API.
        /// 
        /// When calling <see cref="DataReader.Load(uint)"/> in the <see cref="InputStream"/> the operation will return immediately if this character is received in the incoming data stream. No matter if the requested quantity of bytes hasn't been read.
        /// Also if this character is received in the incoming data stream, the <see cref="DataReceived"/> event is fired with it's <see cref="SerialData"/> parameter set to <see cref="SerialData.WatchChar"/>.
        /// </remarks>
        public char WatchChar
        {
            set
            {
                _watchChar = value;
                NativeSetWatchChar();
            }
        }

        /// <summary>
        /// Gets or sets the baud rate.
        /// </summary>
        /// <value>
        /// The baud rate of the serial port.
        /// </value>
        /// <remarks>
        /// The property is set on the <see cref="SerialDevice"/> object that represents the serial port. The baud rate must be supported by the serial port.
        /// </remarks>
        public uint BaudRate
        {
            get
            {
                return _baudRate;
            }

            set
            {
                _baudRate = value;

                // need to reconfigure device
                NativeConfig();
            }
        }

        /// <summary>
        /// Represents the number of bytes received by the last read operation of the input stream.
        /// </summary>
        /// <value>
        /// The number of bytes received by the last read operation of the input stream.
        /// </value>
        public uint BytesReceived { get { return _bytesReceived; } }


        /// <summary>
        /// Gets the number of bytes of data available in the input stream.
        /// </summary>
        /// <value>
        /// The number of bytes of data in the input stream.
        /// </value>
        /// <remarks>
        /// This property is specific to nanoFramework. There is no equivalent one in the UWP API.
        /// </remarks>
        public extern uint BytesToRead
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// The number of data bits in each character value that is transmitted or received, and does not include parity bits or stop bits.
        /// </summary>
        /// <value>
        /// The number of data bits in each character value that is transmitted or received.
        /// </value>
        /// <remarks>
        /// DataBits corresponds to the WordLength member of the SERIAL_LINE_CONTROL structure.
        /// </remarks>
        public ushort DataBits
        {
            get
            {
                return _dataBits;
            }

            set
            {
                _dataBits = value;

                // need to reconfigure device
                NativeConfig();
            }
        }

        /// <summary>
        /// Gets or sets the handshaking protocol for flow control.
        /// </summary>
        /// <value>
        /// One of the values defined in SerialHandshake enumeration.
        /// </value>
        public SerialHandshake Handshake
        {
            get
            {
                return _handshake;
            }

            set
            {
                _handshake = value;

                // need to reconfigure device
                NativeConfig();
            }
        }

        /// <summary>
        /// Input stream that contains the data received on the serial port.
        /// </summary>
        /// <value>
        /// Input stream that contains the data received.
        /// </value>
        /// <remarks>
        /// To access data received on the port, get the input stream from <see cref="SerialDevice"/> object, and then use the DataReader to read data.
        /// </remarks>
        public IInputStream InputStream { get { return _inputStream; } }

        /// <summary>
        /// Gets an output stream to which the app can write data to transmit through the serial port.
        /// </summary>
        /// <remarks>
        /// To write data, first get the output stream from the <see cref="SerialDevice"/> object by using <see cref="OutputStream"/> property and then use the DataWriter object to write the actual buffer.
        /// </remarks>
        public IOutputStream OutputStream { get { return _outputStream; } }

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
        public SerialParity Parity
        {
            get
            {
                return _parity;
            }

            set
            {
                _parity = value;

                // need to reconfigure device
                NativeConfig();
            }
        }

        /// <summary>
        /// Gets the port name for serial communications.
        /// </summary>
        /// <value>
        /// The communication port name. For example "COM1".
        /// </value>
        public string PortName
        {
            get
            {
                lock (_syncLock)
                {
                    // check if device has been disposed
                    if (!_disposed) { return _deviceId; }

                    throw new ObjectDisposedException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the time-out value for a read operation.
        /// </summary>
        /// <value>
        /// The span of time before a time-out occurs when a read operation does not finish.
        /// </value>
        public TimeSpan ReadTimeout
        {
            get
            {
                return _readTimeout;
            }

            set
            {
                _readTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the standard number of stop bits per byte.
        /// </summary>
        /// <value>
        /// One of the values defined in the SerialStopBitCount enumeration.
        /// </value>
        /// <remarks>
        /// In serial communication, a transmission begins with a start bit, followed by 8 bits of data, and ends with a stop bit. The purpose of the stop bit is to separate each unit of data or to indicate that no data is available for transmission.
        /// </remarks>
        public SerialStopBitCount StopBits
        {
            get
            {
                return _stopBits;
            }

            set
            {
                _stopBits = value;

                // need to reconfigure device
                NativeConfig();
            }
        }

        /// <summary>
        /// Gets or sets the time-out value for a write operation.
        /// </summary>
        /// <value>
        /// The span of time before a time-out occurs when a write operation does not finish.
        /// </value>
        public TimeSpan WriteTimeout
        {
            get
            {
                return _writeTimeout;
            }

            set
            {
                _writeTimeout = value;
            }
        }

        /// <summary>
        /// Creates a <see cref="SerialDevice"/> object.
        /// </summary>
        /// <param name="deviceId">The device instance path of the device. To obtain that value, get the DeviceInformation.Id property value.</param>
        /// <returns>
        /// Returns an <see cref="SerialDevice"/> object.
        /// </returns>
        /// <remarks>This method is specific to nanoFramework. The equivalent method in the UWP API is: FromIdAsync.</remarks>
        public static SerialDevice FromId(String deviceId)
        {
            return new SerialDevice(deviceId);
        }

        /// <summary>
        /// Gets all the available Serial devices available on the system.
        /// </summary>
        /// <returns>
        /// String containing all the serial devices available in the system.
        /// </returns>
        /// /// <remarks>This method is specific to nanoFramework. The equivalent method in the UWP API returns an Advanced Query Syntax (AQS) string.</remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetDeviceSelector();


        #region IDisposable Support

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //if (_callbacksErrorEvent != null)
                    //{
                    //    _evtErrorEvent.OnInterrupt -= new NativeEventHandler(ErrorEventHandler);
                    //    _callbacksErrorEvent = null;
                    //    _evtErrorEvent.Dispose();
                    //}

                    // remove the pin from the event listener
                    s_eventListener.RemoveSerialDevice(_portIndex);

                    // remove device from collection
                    SerialDeviceController.DeviceCollection.Remove(_deviceId);
                }

                NativeDispose();

                _disposed = true;
            }
        }

        #pragma warning disable 1591
        ~SerialDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            lock (_syncLock)
            {
                if (!_disposed)
                {
                    Dispose(true);

                    GC.SuppressFinalize(this);
                }
            }
        }

        #endregion


        #region Events

        //// This should be a TypedEventHandler "TypedEventHandler<SerialDevice, ErrorReceivedEventArgs>"
        //#pragma warning disable 1591
        //public delegate void ErrorReceivedEventHandler(
        //    Object sender,
        //    ErrorReceivedEventArgs e);


        ///// <summary>
        ///// Event handler that is invoked when error occurs on the serial port.
        ///// </summary>
        ///// <remarks>
        ///// This event is used to detect and respond to errors when communicating data through a serial port. When an error condition occurs, the ErrorReceived event handler is invoked and error information is received in an ErrorReceivedEventArgs object. Determine the type of error by retrieving the Error property of the ErrorReceivedEventArgs class. Those property values are defined in the SerialError enumeration.
        ///// </remarks>
        //public event ErrorReceivedEventHandler ErrorReceived
        //{
        //    add
        //    {
        //        lock (_syncLock)
        //        {
        //            if (_disposedValue)
        //            {
        //                throw new ObjectDisposedException();
        //            }

        //            var callbacksOld = _callbacksErrorEvent;
        //            var callbacksNew = (ErrorReceivedEventHandler)Delegate.Combine(callbacksOld, value);

        //            try
        //            {
        //                _callbacksErrorEvent = callbacksNew;

        //                if (callbacksOld == null && _callbacksErrorEvent != null)
        //                {
        //                    _evtErrorEvent.OnInterrupt += new NativeEventHandler(ErrorEventHandler);
        //                }
        //            }
        //            catch
        //            {
        //                _callbacksErrorEvent = callbacksOld;
        //                throw;
        //            }
        //        }
        //    }

        //    remove
        //    {
        //        lock (_syncLock)
        //        {
        //            if (_disposedValue)
        //            {
        //                throw new ObjectDisposedException();
        //            }

        //            var callbacksOld = _callbacksErrorEvent;
        //            var callbacksNew = (ErrorReceivedEventHandler)Delegate.Remove(callbacksOld, value);

        //            try
        //            {
        //                _callbacksErrorEvent = callbacksNew;

        //                if (_callbacksErrorEvent == null)
        //                {
        //                    _evtErrorEvent.OnInterrupt -= new NativeEventHandler(ErrorEventHandler);
        //                }
        //            }
        //            catch
        //            {
        //                _callbacksErrorEvent = callbacksOld;

        //                throw;
        //            }
        //        }
        //    }
        //}

        //private void ErrorEventHandler(uint evt, uint data2, DateTime timestamp)
        //{
        //    _callbacksErrorEvent?.Invoke(this, new ErrorReceivedEventArgs((SerialError)evt));
        //}

        /// <summary>
        /// Indicates that data has been received through a <see cref="SerialDevice"/> object.
        /// </summary>
        /// <remarks>
        /// This event is specific to nanoFramework. There is no equivalent method in the UWP API.
        /// 
        /// Data events can be caused by any of the items in the <see cref="SerialData"/> enumeration. Because the operating system determines whether to raise this event or not, not all parity errors may be reported.
        /// The <see cref="DataReceived"/> event is also raised if the <see cref="WatchChar"/> character is received, regardless of the number of bytes available in the <see cref="InputStream"/>.
        /// The <see cref="DataReceived"/> event is not guaranteed to be raised for every byte received. Use the <see cref="BytesReceived"/> property or the available bytes property of the <see cref="InputStream"/> to determine how much data is available to be read from the <see cref="InputStream"/>.
        /// </remarks>
        public event SerialDataReceivedEventHandler DataReceived
        {
            add
            {
                lock (_syncLock)
                {
                    if (_disposed)
                    {
                        throw new ObjectDisposedException();
                    }

                    SerialDataReceivedEventHandler callbacksOld = _callbacksDataReceivedEvent;
                    SerialDataReceivedEventHandler callbacksNew = (SerialDataReceivedEventHandler)Delegate.Combine(callbacksOld, value);

                    try
                    {
                        _callbacksDataReceivedEvent = callbacksNew;
                    }
                    catch
                    {
                        _callbacksDataReceivedEvent = callbacksOld;

                        throw;
                    }
                }
            }

            remove
            {
                lock (_syncLock)
                {
                    if (_disposed)
                    {
                        throw new ObjectDisposedException();
                    }

                    SerialDataReceivedEventHandler callbacksOld = _callbacksDataReceivedEvent;
                    SerialDataReceivedEventHandler callbacksNew = (SerialDataReceivedEventHandler)Delegate.Remove(callbacksOld, value);

                    try
                    {
                        _callbacksDataReceivedEvent = callbacksNew;
                    }
                    catch
                    {
                        _callbacksDataReceivedEvent = callbacksOld;

                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// Handles internal events and re-dispatches them to the publicly subscribed delegates.
        /// </summary>
        /// <param name="eventType">The <see cref="SerialData"/> event type.</param>

        internal void OnSerialDataReceivedInternal(SerialData eventType)
        {
            SerialDataReceivedEventHandler callbacks = null;

            lock (_syncLock)
            {
                if (!_disposed)
                {
                    callbacks = _callbacksDataReceivedEvent;
                }
            }

            callbacks?.Invoke(this, new SerialDataReceivedEventArgs(eventType));
        }

        #endregion


        #region Native methods

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeDispose();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeConfig();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void NativeWrite(byte[] buffer);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern uint NativeStore();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern uint NativeRead(byte[] buffer, int count, int options);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void NativeSetWatchChar();
        #endregion
    }
}
