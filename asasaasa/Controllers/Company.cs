
using asasaasa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asasaasa.Controllers;
using asasaasa.Exceptions;
using asasaasa.Enums;

namespace asasaasa.Controllers
{
    internal class Company
    {
        public string Name { get; set; }
        static List<Emloyee> emloyees = new List<Emloyee>();

        public void AddEmployee(Emloyee emloyee)
        {
            if (NullController(emloyee))
                emloyees.Add(emloyee);
            else
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
        }

        public Emloyee GetEmployeeById(int id)
        {
            if (emloyees.Count != 0)                
               return emloyees.Find(x => x.Id == id);
            return null;
        }

        public void UpdateEmployee(Emloyee emloyee)
        {
            Emloyee controllerEmloyee = GetEmployeeById(emloyee.Id);
            if (NullController(controllerEmloyee))
            {
                Controller.UpdateEmployeeMenu();
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        UpdateEmployeeName(emloyee);
                        break;

                    case 2:
                        UpdateEmployeeGender(emloyee);
                        break;
                    case 3:
                        UpdateEmployeeSalary(emloyee);
                        break;

                    case 4:
                        UpdateEmployeePosition(emloyee);
                        break;
                    default:

                        break;
                }

            }else 
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
        }

        public void RemoveEmployee(Emloyee emloyee)
        {
            if (NullController(emloyee))
                emloyees.Remove(emloyee);
            else 
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
        }

        public void GetAll()
        {
            if (emloyees.Count != 0)                
                emloyees.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            else
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
        }

        bool NullController(Emloyee emloyee)
        {
            return emloyee != null;
        }

        void UpdateEmployeeName(Emloyee emloyee)
        {
            Console.Write("Enter Name : ");
            emloyee.Name = Console.ReadLine();
        }

        void UpdateEmployeeGender(Emloyee emloyee)
        {
            emloyee.Gender = Controller.GenderControler();
        }

        void UpdateEmployeeSalary(Emloyee emloyee)
        {
            Console.Write("Enter Salary : ");
            emloyee.Salary = Convert.ToInt32(Console.ReadLine());
        }

        void UpdateEmployeePosition(Emloyee emloyee)
        {
            emloyee.Position = Controller.PositionControler();
        }
    }
}
