using System;
using System.Collections.Generic;
using EmployeeManagement.DomainModelLayer;
using EmployeeManagement.InfrastructureLayer;
using EmployeeManagement.PresentationServiceLayer;

namespace EmployeeManagement.BusinessLogicLayer
{
    public class Employee
    {
        DataHandler dataHandler = new DataHandler();
        EmployeeValidation employeeValidation = new EmployeeValidation();
        EmployeeModel employeeModel = new EmployeeModel();
        public void AddDetails()
        {
            string employeeId = UserUtility.GetInput("Please Enter Employee Id(TZ0000) : ");
            employeeId = employeeValidation.ValidateEmployeeId(employeeId);
            string firstName = UserUtility.GetInput("Please Enter Employee FirstName : ");
            firstName = employeeValidation.ValidateText(firstName, "First Name");
            string lastName = UserUtility.GetInput("Please Enter Employee LastName : ");
            lastName = employeeValidation.ValidateText(lastName, "Last Name");
            string dateOfBirthString = UserUtility.GetInput("Please Enter Employee DateOfBirth : ");
            DateTime currentDate = DateTime.Now;
            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
            if (!string.IsNullOrEmpty(dateOfBirthString))
            {
                if (!isValidDate || currentDate < dateOfBirth)
                {
                    dateOfBirth = employeeValidation.ValidateDate(isValidDate, dateOfBirth, currentDate);
                }
            }
            string email = UserUtility.GetInput("Please Enter Employee Email : ");
            email = employeeValidation.ValidateEmail(email);
            string phone = UserUtility.GetInput("Please Enter Employee Phone Number : ");
            if (!string.IsNullOrEmpty(phone))
            {
                phone = employeeValidation.ValidateMobileNumber(phone);
            }
            string joinDateString = UserUtility.GetInput("Please Enter Employee Join Date : ");
            DateTime joinDate;
            bool isValidJoinDate = DateTime.TryParse(joinDateString, out joinDate);
            if (!isValidJoinDate || dateOfBirth > joinDate)
            {
                joinDate = employeeValidation.ValidateJoinDate(isValidJoinDate, joinDate, dateOfBirth);
            }
            string location = UserUtility.GetInput("Please Enter Employee Location : ");
            location = employeeValidation.ValidateText(location, "Location");
            string jobTitle = UserUtility.GetInput("Please Enter Employee Job Title : ");
            jobTitle = employeeValidation.ValidateText(jobTitle, "Job Title");
            string department = UserUtility.GetInput("Please Enter Employee Department");
            department = employeeValidation.ValidateText(department, "Department");
            string manager = UserUtility.GetInput("Please Enter Employee Manager");
            if (!string.IsNullOrEmpty(manager))
            {
                manager = employeeValidation.ValidateText(manager, "Manager");
            }
            string project = UserUtility.GetInput("Please Enter Employee Project");
            if (!string.IsNullOrEmpty(project))
            {
                manager = employeeValidation.ValidateText(project, "Project");
            }
            employeeModel = new EmployeeModel { EmployeeId = employeeId, FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth, Email = email, Phone = phone, JoinDate = joinDate, Location = location, JobTitle = jobTitle, Department = department, Manager = manager, Project = project };
            var existingEmployees = dataHandler.RetrieveData<EmployeeModel>();
            existingEmployees.Add(employeeModel);
            dataHandler.SaveData(existingEmployees);
            Console.WriteLine("Successfully Added");
            Console.WriteLine();
        }

        public void DisplayAllEmp()
        {
            var displayAllData = dataHandler.RetrieveData<EmployeeModel>();
            for (int i = 0; i < displayAllData.Count; i++)
            {
                Console.WriteLine("EmpNo : " + displayAllData[i].EmployeeId);
                Console.WriteLine("FullName : " + displayAllData[i].FirstName + " " + displayAllData[i].LastName);
                Console.WriteLine("JobTitle : " + displayAllData[i].JobTitle);
                Console.WriteLine("Department : " + displayAllData[i].Department);
                Console.WriteLine("Location : " + displayAllData[i].Location);
                Console.WriteLine("JoinDate : " + displayAllData[i].JoinDate);
                Console.WriteLine("Manager : " + displayAllData[i].Manager);
                Console.WriteLine("Project : " + displayAllData[i].Project);
                Console.WriteLine();
            }
        }
        public void DisplaySearch()
        {
            var displayAllData = dataHandler.RetrieveData<EmployeeModel>();
            Console.WriteLine("Enter Employee Number : ");
            string empNoSearch = Console.ReadLine();
            for (int i = 0; i < displayAllData.Count; i++)
            {
                if (empNoSearch == displayAllData[i].EmployeeId)
                {
                    Console.WriteLine("EmpNo : " + displayAllData[i].EmployeeId);
                    Console.WriteLine("FullName : " + displayAllData[i].FirstName + " " + displayAllData[i].LastName);
                    Console.WriteLine("JobTitle : " + displayAllData[i].JobTitle);
                    Console.WriteLine("Department : " + displayAllData[i].Department);
                    Console.WriteLine("Location : " + displayAllData[i].Location);
                    Console.WriteLine("JoinDate : " + displayAllData[i].JoinDate);
                    Console.WriteLine("Manager : " + displayAllData[i].Manager);
                    Console.WriteLine("Project : " + displayAllData[i].Project);
                    Console.WriteLine();
                }
            }
        }
        public void editEmployee()
        {
            Console.WriteLine("Enter Employee Number: ");
            string empId = Console.ReadLine();
            int chooseField;
            List<DomainModelLayer.EmployeeModel> employees = dataHandler.RetrieveData<EmployeeModel>();
            foreach (var employee in employees)
            {
                if (empId == employee.EmployeeId)
                {
                    Console.WriteLine("Which of the following field you want to edit : ");
                    Console.WriteLine(@"1.First Name
2.Last Name
3.Date Of Birth
4.Email
5.Phone Number
6.Joining Date
7.Location
8.Job Title
9.Department
10.Manager
11.Project");
                    chooseField = int.Parse(Console.ReadLine());
                    if (chooseField == 1)
                    {
                        Console.WriteLine("Enter First Name : ");
                        employee.FirstName = Console.ReadLine();
                    }
                    else if (chooseField == 2)
                    {
                        Console.WriteLine("Enter Last Name : ");
                        employee.LastName = Console.ReadLine();
                    }
                    else if (chooseField == 3)
                    {
                        Console.WriteLine("Enter Date Of Birth : ");
                        employee.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    }
                    else if (chooseField == 4)
                    {
                        Console.WriteLine("Enter Email : ");
                        employee.Email = Console.ReadLine();
                    }
                    else if (chooseField == 5)
                    {
                        Console.WriteLine("Enter Phone Number : ");
                        employee.Phone = Console.ReadLine();
                    }
                    else if (chooseField == 6)
                    {
                        Console.WriteLine("Enter Joining Date : ");
                        employee.JoinDate = DateTime.Parse(Console.ReadLine());
                    }
                    else if (chooseField == 7)
                    {
                        Console.WriteLine("Enter Location : ");
                        employee.Location = Console.ReadLine();
                    }
                    else if (chooseField == 8)
                    {
                        Console.WriteLine("Enter Job Title : ");
                        employee.JobTitle = Console.ReadLine();
                    }
                    else if (chooseField == 9)
                    {
                        Console.WriteLine("Enter Department : ");
                        employee.Department = Console.ReadLine();
                    }
                    else if (chooseField == 10)
                    {
                        Console.WriteLine("Enter Manager : ");
                        employee.Manager = Console.ReadLine();
                    }
                    else if (chooseField == 11)
                    {
                        Console.WriteLine("Enter Project : ");
                        employee.Project = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Please choose right option");
                    }
                    dataHandler.SaveData(employees);
                }
            }
        }
        public void removeEmployee()
        {
            List<DomainModelLayer.EmployeeModel> employees = dataHandler.RetrieveData<EmployeeModel>();
            Console.WriteLine("Enter Employee Id:");
            string empId = Console.ReadLine();
            var employeeRow = employees.Find(emp => emp.EmployeeId == empId);
            employees.Remove(employeeRow);
            dataHandler.SaveData(employees);
        }
    }
}
