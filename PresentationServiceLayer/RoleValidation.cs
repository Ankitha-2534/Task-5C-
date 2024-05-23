using System;
using System.Text.RegularExpressions;

namespace EmployeeManagement.PresentationServiceLayer
{
    public class RoleValidation
    {
        public string Validation(string text, string field)
        {
            string pattern = "^[a-zA-Z]+$";
            while (text == "" || !Regex.IsMatch(text, pattern))
            {
                Console.WriteLine($"Please enter correct {field} : ");
                text = Console.ReadLine();
            }
            return text;
        }
    }
}
