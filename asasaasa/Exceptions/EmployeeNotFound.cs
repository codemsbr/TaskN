using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Exceptions
{
    internal class EmployeeNotFound : Exception
    {
        public EmployeeNotFound()
        {

        }

        public EmployeeNotFound(string? message) : base(message)
        {

        }
    }
}
