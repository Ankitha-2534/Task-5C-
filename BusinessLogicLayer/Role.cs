using System;
using EmployeeManagement.DomainModelLayer;
using EmployeeManagement.InfrastructureLayer;
using EmployeeManagement.PresentationServiceLayer;

namespace EmployeeManagement.BusinessLogicLayer
{
    public class Role
    {
        DataHandler dataHandler = new DataHandler();
        RoleValidation roleValidation = new RoleValidation();
        public void addRole()
        {

            string roleName = UserUtility.GetInput("Role Name");
            roleName = roleValidation.Validation(roleName, "Role Name");
            string department = UserUtility.GetInput("Department");
            department = roleValidation.Validation(department, "Department");
            string description = UserUtility.GetInput("Role Description");
            string location = UserUtility.GetInput("Location");
            location = roleValidation.Validation(location, "Location");
            RoleModel roleModel = new RoleModel
            { RoleName = roleName, RoleDepartment = department, RoleDescription = description, RoleLocation = location };
            var existingRoles = dataHandler.RetrieveData<RoleModel>();
            existingRoles.Add(roleModel);
            dataHandler.SaveData(existingRoles);
            Console.WriteLine("Successfully Added");
        }

        public void displayRoleData()
        {
            var displayAllRole = dataHandler.RetrieveData<RoleModel>();
            for (int i = 0; i < displayAllRole.Count; i++)
            {
                Console.WriteLine("Role Name : " + displayAllRole[i].RoleName);
                Console.WriteLine("Department : " + displayAllRole[i].RoleDepartment);
                Console.WriteLine("Description : " + displayAllRole[i].RoleDescription);
                Console.WriteLine("Location : " + displayAllRole[i].RoleLocation);
                Console.WriteLine();
            }
        }
    }
}
