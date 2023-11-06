using System.Xml;
using asasaasa.Controllers;
using asasaasa.Exceptions;
using asasaasa.Model;

internal class Program
{
    static void Main(string[] args)
    {
        int userAnswer = 0;
        Company company = new Company();
        for (; userAnswer != 6;)
        {
            try
            {
                Controller.Menu();
                userAnswer = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (userAnswer)
                {
                    case 1:
                        Controller.CreateEmloyee();
                        break;

                    case 2:
                        Console.Write("Enter User Id : ");
                        Console.WriteLine(company.GetEmployeeById(Convert.ToInt32(Console.ReadLine())));
                        break;

                    case 3:
                        company.GetAll();
                        break;

                    case 4:
                        company.UpdateEmployee(Controller.IdEmployee());
                        break;
                    case 5:
                        company.RemoveEmployee(Controller.IdEmployee());
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
            catch (EmployeeNotFound ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException fx)
            {
                Console.WriteLine(fx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}