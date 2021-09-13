using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public class AccountingSystemException : Exception
    {
        public AccountingSystemException()
        {
        }

        public AccountingSystemException(string message) : base(message)
        {
        }

        public AccountingSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
