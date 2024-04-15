using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FormularzWinForms.Models
{
    public interface IXmlReadFromFile
    {
        Task<List<Employee>> DeserializeEmployees();
    }

    internal class XmlReadFromFile : IXmlReadFromFile
    {
        public async Task<List<Employee>> DeserializeEmployees()
        {
            string dataDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
            string filePath = $@"{dataDirectory}\Data\Employees.xml";
            var employees = new List<Employee>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Nie odnaleziono pliku \"{filePath}\"");
            }
            else
            {                
                XmlSerializer employeeXmlDeserializer = new(typeof(List<Employee>));

                await Task.Run(() =>
                {
                    using StreamReader streamReader = new(filePath);
                    employees.AddRange((List<Employee>)employeeXmlDeserializer.Deserialize(streamReader)!);
                });
            }

            return employees;
        }
    }
}
