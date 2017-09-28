//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    internal interface IPinChangedEventArgs
    {
        SerialPinChange PinChange { get; }
    }
}
