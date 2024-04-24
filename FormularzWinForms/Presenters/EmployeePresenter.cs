using FormularzWinForms.Models;

namespace FormularzWinForms.Presenters
{
    public interface IEmployeePresenter
    {
        IEmployeeView View { get; }
    }

    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployeeModel _employeeModel;
        private readonly IXmlSaveToFile _xmlSaveToFile;
        private readonly IXmlReadFromFile _xmlReadFromFile;
        private readonly BindingSource _employeeBindingSource = [];
        public IEmployeeView View { get; }

        public EmployeePresenter(IEmployeeModel employeeModel, IEmployeeView employeeView, IXmlSaveToFile xmlSaveToFileIXml, IXmlReadFromFile xmlReadFromFile)
        {
            _employeeModel = employeeModel;

            View = employeeView;
            View.EmployeeAddedEvent += HandleEmployeeAddedClick;
            View.SaveToFileEvent += HandleSaveToFileClickAsync;
            View.ReadFromFileEvent += HandleReadFromFileClickAsync;

            _xmlSaveToFile = xmlSaveToFileIXml;
            _xmlReadFromFile = xmlReadFromFile;

            BindDataWithView();
        }

        //Binding data with view:
        private void BindDataWithView() => View.BindListBoxData(_employeeBindingSource);


        //Click Handlers:
        private void HandleEmployeeAddedClick()
        {
            var employeeData = View.GetDataFromBoxes();

            var employee = new Employee()
            {
                FirstName = employeeData.FirstName,
                LastName = employeeData.LastName,
                DateOfBirth = employeeData.DateOfBirth,
                Salary = employeeData.Salary,
                Position = employeeData.Position,
                ContractType = _employeeModel.MapToContractType(employeeData.ContractId)
            };

            _employeeBindingSource.Add(employee);
        }

        private async Task HandleSaveToFileClickAsync()
        {
            await _xmlSaveToFile.SerializeEmployees((List<Employee>)_employeeBindingSource.DataSource);
        }

        private async Task HandleReadFromFileClickAsync()
        {
             _employeeBindingSource.DataSource = await _xmlReadFromFile.DeserializeEmployees();
        }
    }
}
