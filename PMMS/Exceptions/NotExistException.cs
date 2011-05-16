using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Exceptions
{
    public class NotExistException : Exception
    {
        public NotExistException()
        {
        }

        public NotExistException(string message) : base(message)
        {
        }
    }
}