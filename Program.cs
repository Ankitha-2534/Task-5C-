using System;
using EmployeeManagement.BusinessLogicLayer;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(@"1.Employee Management
2.Role Management
3.Exit");
            int userChoice = int.Parse(Console.ReadLine());
            int option;
            while (true)
            {
                if (userChoice == 1)
                {
                    Console.WriteLine("You have been redirected to Employee Management");
                    Console.WriteLine("Please choose an option from given below by entering value");
                    Console.WriteLine(@"1.Add Employee
2.Display all
3.Display one
4.Edit employee
5.Delete employee
6.Go Back");
                    option = int.Parse(Console.ReadLine());
                    Employee employee = new Employee();
                    if (option == 1)
                    {
                        employee.AddDetails();
                    }
                    else if (option == 2)
                    {
                        employee.DisplayAllEmp();
                    }
                    else if (option == 3)
                    {
                        employee.DisplaySearch();
                    }
                    else if (option == 4)
                    {
                        employee.editEmployee();
                    }
                    else if (option == 5)
                    {
                        employee.removeEmployee();
                    }
                    else if (option == 6)
                    {
                        Main(args);
                    }
                    else
                    {
                        Console.WriteLine("Please choose right option");
                    }
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine(@"You have been redirected to Role Management
Please choose an option from given below by entering value");
                    Console.WriteLine(@"1.Add Role
2.Display all
3.Go Back");
                    option = int.Parse(Console.ReadLine());
                    Role role = new Role();
                    if (option == 1)
                    {
                        role.addRole();
                    }
                    else if (option == 2)
                    {
                        role.displayRoleData();
                    }
                    else if (option == 3)
                    {
                        Main(args);
                    }
                }
                else
                {
                    Console.WriteLine("You are exited");
                    break;
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
