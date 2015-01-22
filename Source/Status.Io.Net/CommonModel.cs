// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System.Diagnostics;

namespace StatusIo
{
    [DebuggerDisplay("{Message}")]
    public class ResponseStatus
    {
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public abstract class Response
    {
        public ResponseStatus Status { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }

    public enum IncidentStatus
    {
        Operational = 100,
        DegradedPerformance = 300,
        PartialServiceDisruption = 400,
        ServiceDisruption = 500,
        SecurityEvent = 600
    }

    public enum OperationalState
    {
        Investigating = 100,
        Identified = 200,
        Monitoring = 300
    }
}