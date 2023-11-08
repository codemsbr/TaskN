using asasaasa.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Model
{
    internal class Emloyee : Person
    {
        public decimal Salary { get; set; }
        public Position Position { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;

        public Emloyee()
        {
            
        }

        public Emloyee(string name, string surName, int age, Gender gender, Position position, decimal salary)
        {
            Name = name;
            SurName = surName;
            Age = age;
            Gender = gender;
            Position = position;
            Salary = salary;
        }


        public override string ToString()
        {
            return $" Id : {Id} Name : {Name} Surname : {SurName} Age : {Age} Gender : {Gender} Position : {Position} Salary : {Salary}";
        }

    }
}
