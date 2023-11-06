using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asasaasa.Enums;
using asasaasa.Exceptions;
using asasaasa.Model;

namespace asasaasa.Controllers
{
    static class Controller
    {
        public static void Menu()
        {
            Console.WriteLine("1.Create Emloyee");
            Console.WriteLine("2.Get Emloyee Details by Id");
            Console.WriteLine("3.Get All Emloyees");
            Console.WriteLine("4.Update Employee Id");
            Console.WriteLine("5.Delete Emloyee Details Id ");
            Console.WriteLine("6.Exit");            
            Console.Write("User Answer : ");
        }

        public static void CreateEmloyee()
        {
            Company company = new Company();
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter SurName : ");
            string surName = Console.ReadLine();

            Console.Write("Enter Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            
            Emloyee emloyee = new(name, surName, age, GenderControler(), PositionControler(), salary);
            company.AddEmployee(emloyee);
        }

        public static Emloyee IdEmployee()
        {
            Company company = new Company();
            company.GetAll();
            Console.Write("Enter User Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Emloyee emloyee = company.GetEmployeeById(id);
            return emloyee != null ? emloyee : throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
            
        }

        public static void UpdateEmployeeMenu()
        {
            Console.WriteLine("1.Name Update");
            Console.WriteLine("2.Gender Update");
            Console.WriteLine("3.Salary Update");
            Console.WriteLine("4.Position Update");
            Console.Write("User Answer : ");
        }

        public static void GenderMenu()
        {
            Console.WriteLine("0.Male");
            Console.WriteLine("1.Female");
            Console.WriteLine("2.Other");
            Console.Write("Enter Gender : ");
        }

        public static void PositionMenu()
        {
            Console.WriteLine("0.Admin");
            Console.WriteLine("1.Member");
            Console.Write("Enter Position : ");
        }

       public static Position PositionControler()
        {
            PositionMenu();
            int position = Convert.ToInt32(Console.ReadLine());
            if (position > 1)
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
            return (Position)position;
        }

       public static Gender GenderControler()
        {
            GenderMenu();
            int gender = Convert.ToInt32(Console.ReadLine());
            if (gender > 2)
                throw new EmployeeNotFound(ExceptionsMessage.exceptionsMessage);
            return (Gender)gender;
        }
    }
}
