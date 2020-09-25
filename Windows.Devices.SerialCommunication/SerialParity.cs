//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Devices.SerialCommunication
{
    /// <summary>
    /// Defines values for the parity bit for the serial data transmission. The values are used by the Parity property on the SerialDevice object.
    /// </summary>
    public enum SerialParity
    {
        /// <summary>
        /// No parity check occurs.
        /// </summary>
        None = 0,
        /// <summary>
        /// Sets the parity bit so that the total count of data bits set is an even number.
        /// </summary>
        Even,
        /// <summary>
        /// Leaves the parity bit set to 1.
        /// </summary>
        Mark,
        /// <summary>
        /// Sets the parity bit so that the total count of data bits set is an odd number.
        /// </summary>
        Odd,
        /// <summary>
        /// Leaves the parity bit set to 0.
        /// </summary>
        Space
    }
}
