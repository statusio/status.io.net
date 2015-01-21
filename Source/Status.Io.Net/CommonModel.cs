// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System.Diagnostics;

namespace StatusIo
{
    [DebuggerDisplay("{Message}")]
    public class Status
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public abstract class Response
    {
        public Status Status { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }
}