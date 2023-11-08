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
            Console.WriteLine("2.Create Company");
            Console.WriteLine("3.Get Company Details by Id");
            Console.WriteLine("4.Get Company Details by Value");
            Console.WriteLine("5.Get Emloyee Details by Id");
            Console.WriteLine("6.Get Emloyee Details by Value");
            Console.WriteLine("7.Black of the employees created in 1 week");
            Console.WriteLine("8.Get All Companys");
            Console.WriteLine("9.Get All Emloyees");
            Console.WriteLine("10.Update Employee Id");
            Console.WriteLine("11.Update Company Id");
            Console.WriteLine("12.Delete Company Details Id");
            Console.WriteLine("13.Delete Emloyee Details Id ");
            Console.WriteLine("14.Exit");
            Console.Write("User Answer : ");
        }

        public static void CreateEmloyee()
        {
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter SurName : ");
            string surName = Console.ReadLine();

            Console.Write("Enter Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Salary : ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            
            Emloyee emloyee = new(name, surName, age, GenderControler(), PositionControler(), salary);
            EmployeeService.AddEmployee(emloyee);
        }

        public static void CreateCompany()
        {
            Console.Write("Enter Company Name : ");
            CompanyService.AddCompany(new(Console.ReadLine()));
        }

        public static Emloyee IdEmployee()
        {
            EmployeeService.GetAll();
            Console.Write("Enter User Id : ");
            return EmployeeService.GetEmployeeById(Convert.ToInt32(Console.ReadLine()));    
        }

        public static Company IdCompany()
        {
            CompanyService.GetAll();
            Console.Write("Enter Company Id : ");
            return CompanyService.GetCompanyeById(Convert.ToInt32(Console.ReadLine()));
        }

        public static void ValueEmployee()
        {
            EmployeeService.GetAll();
            Console.Write("Enter User Name Or SurName : ");
            EmployeeService.GetEmployeesByValuesFragmentation(Console.ReadLine());
        }

        public static void ValueCompany()
        {
            CompanyService.GetAll();
            Console.Write("Enter Company Name : ");
            CompanyService.GetCompanysByValuesFragmentation(Console.ReadLine());
        }

        public static void UpdateEmployeeMenu()
        {
            Console.WriteLine("1.Name Update");
            Console.WriteLine("2.Gender Update");
            Console.WriteLine("3.Salary Update");
            Console.WriteLine("4.Position Update");
            Console.Write("User Answer : ");
        }

        public static void UpdateCompanyMenu()
        {
            Console.WriteLine("1.Name Update");
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
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
            return (Position)position;
        }

        public static Gender GenderControler()
        {
            GenderMenu();
            int gender = Convert.ToInt32(Console.ReadLine());
            if (gender > 2)
                throw new EmployeeNotFound(ExceptionsMessage.EmployeeNotFoundMessage);
            return (Gender)gender;
        }
    }
}
