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
        public IEmployeeView EmployeeView { get; }
    }

    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployee _employee = null!;
        private readonly IXmlSaveToFile _xmlSaveToFile;
        private readonly IXmlReadFromFile _xmlReadFromFile;
        private readonly BindingSource _employeeBindingSource = [];
        public IEmployeeView EmployeeView { get; }

        public EmployeePresenter(IEmployee employee, IEmployeeView employeeView, IXmlSaveToFile xmlSaveToFileIXml, IXmlReadFromFile xmlReadFromFile)
        {
            _employee = employee;

            EmployeeView = employeeView;
            EmployeeView.BindListBoxData(_employeeBindingSource);
            EmployeeView.EmployeeAddedAction += HandleEmployeeAddedAction;
            EmployeeView.SaveToFileAction += HandleSaveToFileAction;
            EmployeeView.ReadFromFileAction += HandleReadFromFileAction;

            _xmlSaveToFile = xmlSaveToFileIXml;
            _xmlReadFromFile = xmlReadFromFile;
        }

        private void HandleEmployeeAddedAction()
        {
            _employeeBindingSource.Add(EmployeeView.GetDataFromBoxes());
        }

        private void HandleSaveToFileAction()
        {
            var employees = new List<Employee>();
            foreach (var employee in _employeeBindingSource)
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

        private void HandleReadFromFileAction()
        {
            _employeeBindingSource.DataSource = _xmlReadFromFile.DeserializeEmployees();
        }
    }
}
