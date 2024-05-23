using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using EmployeeManagement.DomainModelLayer;

namespace EmployeeManagement.BusinessLogicLayer
{
    public class DataHandler
    {
        public void SaveData<T>(List<T> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            string filePath = typeof(T) == typeof(EmployeeModel) ? "Employee.json" : "Role.json";
            File.WriteAllText(filePath, jsonData);
        }

        public List<T> RetrieveData<T>()
        {
            string filePath = typeof(T) == typeof(EmployeeModel) ? "Employee.json" : "Role.json";
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            else
            {
                return new List<T>();
            }
        }
    }
}
