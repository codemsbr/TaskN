using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Model
{
    abstract class Person
    {
        static int id = 1;
        public int Id { get; }

        public Person()
        {
            Id = id++;
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }


        public virtual string FullName()
        {
            return $"{Name} {SurName}";
        }

    }
}
