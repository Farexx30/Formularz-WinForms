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
        List<Employee> DeserializeEmployees();
    }

    internal class XmlReadFromFile : IXmlReadFromFile
    {
        public List<Employee> DeserializeEmployees()
        {
            string filePath = @"C:\Users\Łukasz\source\repos\Formularz-WinForms\FormularzWinForms\Data\Employees.xml";

            var employees = new List<Employee>();
            XmlSerializer employeeXmlDeserializer = new(typeof(List<Employee>));

            using StreamReader streamReader = new(filePath);
            employees.AddRange((List<Employee>)employeeXmlDeserializer.Deserialize(streamReader)!);

            return employees;
        }
    }
}
