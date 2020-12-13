using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDETYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        public ExceptionType type;

        public InvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}