using asasaasa.Exceptions;
using asasaasa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Controllers
{
    static class EmployeeService
    {

        public static void AddEmployee(Emloyee emloyee)
        {
            if (NullController(emloyee))
                CompanyDataBase.emloyees.Add(emloyee);
            else
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
        }

        public static Emloyee GetEmployeeById(int id)
        {
            if (CompanyDataBase.emloyees.Count != 0)
                return CompanyDataBase.emloyees.Find(x => x.Id == id);
            return null;
        }

        public static void GetEmployeesByValuesFragmentation(string value)
        {
            List<Emloyee> emloyees = GetEmployeesByValue(value);
            if (emloyees != null)
                emloyees.ForEach(x =>
                {
                    Console.WriteLine(x);
                });

            throw new InvalidNameOrSurNameException(ExceptionsMessage.InvalidNameOrSurNameException);
        }

        public static void GetLatestEmployeesFragmentation()
        {
            List<Emloyee> emloyeesList = GetLatestEmployees();
            if (emloyeesList.Count == 0)
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);

            emloyeesList.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public static void UpdateEmployee(Emloyee emloyee)
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

            }
            else
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
        }

        public static void RemoveEmployee(Emloyee emloyee)
        {
            if (NullController(emloyee))
                CompanyDataBase.emloyees.Remove(emloyee);
            else
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
        }

        public static void GetAll()
        {
            if (CompanyDataBase.emloyees.Count != 0)
                CompanyDataBase.emloyees.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            else
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
        }

        static bool NullController(Emloyee emloyee)
        {
            return emloyee != null;
        }

        static void UpdateEmployeeName(Emloyee emloyee)
        {
            Console.Write("Enter Name : ");
            emloyee.Name = Console.ReadLine();
        }

        static void UpdateEmployeeGender(Emloyee emloyee)
        {
            emloyee.Gender = Controller.GenderControler();
        }

        static void UpdateEmployeeSalary(Emloyee emloyee)
        {
            Console.Write("Enter Salary : ");
            emloyee.Salary = Convert.ToInt32(Console.ReadLine());
        }

        static void UpdateEmployeePosition(Emloyee emloyee)
        {
            emloyee.Position = Controller.PositionControler();
        }

        static List<Emloyee> GetEmployeesByValue(string value)
        {
            if (CompanyDataBase.emloyees.Count != 0)
                return CompanyDataBase.emloyees.FindAll(x => x.SurName == value || x.Name == value);
            return null;
        }

        static List<Emloyee> GetLatestEmployees()
        {
            if(CompanyDataBase.emloyees.Count !=0)
                return CompanyDataBase.emloyees.Where(x => DateTime.Now.DayOfWeek - x.CreatedAt.DayOfWeek == 1).ToList();
            return null;
        }
    }
}
