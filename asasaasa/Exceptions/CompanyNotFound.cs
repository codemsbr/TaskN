using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Exceptions
{
    internal class CompanyNotFound : Exception
    {
        public CompanyNotFound()
        {
        }

        public CompanyNotFound(string? message) : base(message)
        {
        }
    }
}
