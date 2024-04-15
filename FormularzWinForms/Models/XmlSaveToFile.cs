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
        Task SerializeEmployees(List<Employee> employees);
    }

    internal class XmlSaveToFile : IXmlSaveToFile
    {
        public async Task SerializeEmployees(List<Employee> employees)
        {
            string dataDirectory = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName;
            string filePath = $@"{dataDirectory}\Data\Employees.xml";

            XmlSerializer employeeXmlSerializer = new(typeof(List<Employee>));

            await Task.Run(() =>
            {
                using StreamWriter streamWriter = new(filePath);
                employeeXmlSerializer.Serialize(streamWriter, employees);
            });
        }
    }
}
