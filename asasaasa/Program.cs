using System.Xml;
using asasaasa.Controllers;
using asasaasa.Exceptions;
using asasaasa.Model;

internal class Program
{
    static void Main(string[] args)
    {
        int userAnswer = 0;
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
                        Console.WriteLine(EmployeeService.GetEmployeeById(Convert.ToInt32(Console.ReadLine())));
                        break;

                    case 3:
                        Console.Write("Enter User Name Or SurName : ");
                        EmployeeService.GetEmployeesByValuesFragmentation(Console.ReadLine());
                        break;

                    case 4:
                        EmployeeService.GetLatestEmployeesFragmentation();
                        break;

                    case 5:
                        EmployeeService.GetAll();
                        break;

                    case 6:
                        EmployeeService.UpdateEmployee(Controller.IdEmployee());
                        break;

                    case 7:
                        EmployeeService.RemoveEmployee(Controller.IdEmployee());
                        break;
                    
                    case 8:                        
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
            catch (InvalidNameOrSurNameException ex)
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