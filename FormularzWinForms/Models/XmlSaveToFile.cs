using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FormularzWinForms.Models
{
    public interface IXmlSaveToFile
    {
        void SerializeEmployees(List<Employee> employees);
    }

    internal class XmlSaveToFile : IXmlSaveToFile
    {
        public void SerializeEmployees(List<Employee> employees)
        {
            string filePath = @"C:\Users\Łukasz\source\repos\Formularz-WinForms\FormularzWinForms\Data\Employees.xml";
            XmlSerializer employeeXmlSerializer = new(typeof(List<Employee>));

            using StreamWriter streamWriter = new(filePath);
            employeeXmlSerializer.Serialize(streamWriter, employees);
        }

    }
}
