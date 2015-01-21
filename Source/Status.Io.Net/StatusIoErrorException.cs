// Licensed under the Apache 2.0 License. See LICENSE.txt in the project root for more information.

using System;

namespace StatusIo
{
    public class StatusIoErrorException : Exception
    {
        public StatusIoErrorException(string message)
            : base(message)
        {
        }
    }
}