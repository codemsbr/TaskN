using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Exceptions
{
    internal class InvalidNameOrSurNameException : Exception
    {
        public InvalidNameOrSurNameException()
        {

        }

        public InvalidNameOrSurNameException(string? message) : base(message)
        {

        }
    }
}
