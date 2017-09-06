//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace Windows.Storage.Streams
{
    /// <summary>
    /// Specifies the read options for an input stream.
    /// </summary>
    public enum InputStreamOptions
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        None,
        /// <summary>
        /// The asynchronous read operation completes when one or more bytes is available.
        /// </summary>
        Partial,
        /// <summary>
        /// The asynchronous read operation may optionally read ahead and prefetch additional bytes.
        /// </summary>
        ReadAhead
    }
}
