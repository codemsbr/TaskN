using asasaasa.Exceptions;
using asasaasa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asasaasa.Controllers
{
    static class CompanyService
    {
        public static void AddCompany(Company company)
        {
            if (NullController(company))
                CompanyDataBase.companies.Add(company);
            else
                throw new CompanyNotFound(ExceptionsMessage.CompanyNotFoundMessage);
        }

        public static Company GetCompanyeById(int id)
        {
            if (CompanyDataBase.companies.Count != 0 && CompanyDataBase.emloyees.Any(x => x.Id == id))
                return CompanyDataBase.companies.Find(x => x.Id == id);
            throw new CompanyNotFound(ExceptionsMessage.CompanyNotFoundMessage);
        }

        public static void GetCompanysByValuesFragmentation(string value)
        {
            List<Company> companys = GetCompanysByValue(value);
            if (companys != null)
                companys.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            throw new InvalidNameException(ExceptionsMessage.InvalidNameException);
        }

        public static void UpdateCompany(Company company)
        {
            Company controllerCompany = GetCompanyeById(company.Id);
            if (NullController(controllerCompany))
            {
                Controller.UpdateEmployeeMenu();
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        UpdateCompanyName(company);
                        break;

                    default:

                        break;
                }
            }
            else
                throw new CompanyNotFound(ExceptionsMessage.CompanyNotFoundMessage);
        }

        public static void RemoveCompany(Company company)
        {
            if (NullController(company))
                CompanyDataBase.companies.Remove(company);
            else
                throw new CompanyNotFound(ExceptionsMessage.CompanyNotFoundMessage);
        }

        public static void GetAll()
        {
            if (CompanyDataBase.companies.Count != 0)
                CompanyDataBase.companies.ForEach(x =>
                {
                    Console.WriteLine(x);
                });
            else
                throw new CompanyNotFound(ExceptionsMessage.CompanyNotFoundMessage);
        }

        static bool NullController(Company company)
        {
            return company != null;
        }

        static void UpdateCompanyName(Company company)
        {
            Console.Write("Enter Name : ");
            company.Name = Console.ReadLine();
        }

        static List<Company> GetCompanysByValue(string value)
        {
            if (CompanyDataBase.companies.Count != 0)
                return CompanyDataBase.companies.FindAll(x => x.Name == value);
            return null;
        }
    }
}
