//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.Devices.SerialCommunication
{
    internal interface ISerialDevice
    {
        uint BaudRate { get; set; }
        bool BreakSignalState { get; set; }
        uint BytesReceived { get; }
        bool CarrierDetectState { get; }
        bool ClearToSendState { get; }
        ushort DataBits { get; set; }
        bool DataSetReadyState { get; }
        SerialHandshake Handshake { get; set; }
        IInputStream InputStream { get; }
        bool IsDataTerminalReadyEnabled { get; set; }
        bool IsRequestToSendEnabled { get; set; }
        IOutputStream OutputStream { get; }
        SerialParity Parity { get; set; }
        string PortName { get; }
        TimeSpan ReadTimeout { get; set; }
        SerialStopBitCount StopBits { get; set; }
        ushort UsbProductId { get; }
        ushort UsbVendorId { get; }
        TimeSpan WriteTimeout { get; set; }

        event TypedEventHandler<SerialDevice, ErrorReceivedEventArgs> ErrorReceived;
        event TypedEventHandler<SerialDevice, PinChangedEventArgs> PinChanged;
    }
}
