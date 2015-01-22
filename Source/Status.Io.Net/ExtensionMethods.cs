// Licensed under the Apache 2.0 License. See LICENSE in the project root for more information.

using System;

namespace StatusIo
{
    internal static class ExtensionMethods
    {
        private const string dateTimeStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss+00:00";

        public static string ToFormatString(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString(dateTimeStringFormat);
        }

        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return (dateTime.Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond;
        }
    }
}