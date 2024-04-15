using FormularzWinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.ListBox;

namespace FormularzWinForms.Presenters
{ 
    public interface IEmployeePresenter
    {
        void HandleSaveToFileAction(ObjectCollection dataListBoxItems);
        List<Employee> HandleReadFromFileAction();
    }

    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployee _employee = null!;
        private readonly IEmployeeView _employeeView = null!;
        private readonly IXmlSaveToFile _xmlSaveToFile;
        private readonly IXmlReadFromFile _xmlReadFromFile;

        public EmployeePresenter(IEmployee employee, IEmployeeView employeeView, IXmlSaveToFile xmlSaveToFileIXml, IXmlReadFromFile xmlReadFromFile)
        {
            _employee = employee;
            _employeeView = employeeView;
            _employeeView.SaveToFileAction += HandleSaveToFileAction;
            _employeeView.ReadFromFileAction += HandleReadFromFileAction;
            _xmlSaveToFile = xmlSaveToFileIXml;
            _xmlReadFromFile = xmlReadFromFile;
        }

        public void HandleSaveToFileAction(ObjectCollection dataListBoxItems)
        {
            var employees = new List<Employee>();
            foreach (var employee in dataListBoxItems)
            {
                string[] employeeData = employee.ToString()!.Split(", ");
                var employeeObject = new Employee()
                {
                    FirstName = employeeData[0],
                    LastName = employeeData[1],
                    DateOfBirth = DateTime.Parse(employeeData[2]),
                    Salary = decimal.Parse(employeeData[3][..^4]),
                    Position = employeeData[4],
                    ContractType = Employee.MapToContractType(employeeData[5])
                };

                employees.Add(employeeObject);
            }

            _xmlSaveToFile.SerializeEmployees(employees);
        }

        public List<Employee> HandleReadFromFileAction()
        {          
            var employees = _xmlReadFromFile.DeserializeEmployees();
            return employees;
        }
    }
}
