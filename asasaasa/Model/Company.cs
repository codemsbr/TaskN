using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asasaasa.Exceptions;
using asasaasa.Enums;

namespace asasaasa.Model
{
    internal class Company
    {
        static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        Company()
        {
            Id = id++;
        }

        public Company(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
