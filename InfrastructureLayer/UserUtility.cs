using System;

namespace EmployeeManagement.InfrastructureLayer
{
    public class UserUtility
    {
        public static string GetInput(string userInputMessage)
        {
            Console.WriteLine(userInputMessage);
            return Console.ReadLine();
        }
    }
}
