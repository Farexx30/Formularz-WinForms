using FormularzWinForms.Dtos;
using FormularzWinForms.Models;

namespace FormularzWinForms.Presenters
{
    public interface IEmployeePresenter
    {
        IEmployeeView View { get; }
    }

    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IXmlSaveToFile _xmlSaveToFile;
        private readonly IXmlReadFromFile _xmlReadFromFile;
        private readonly BindingSource _employeeBindingSource = [];
        public IEmployeeView View { get; }

        public EmployeePresenter(IEmployeeView employeeView, IXmlSaveToFile xmlSaveToFileIXml, IXmlReadFromFile xmlReadFromFile)
        {
            View = employeeView;
            View.EmployeeAddedEvent += HandleEmployeeAddedClick;
            View.EmployeeSelectedEvent += HandleEmployeeSelectedClick;
            View.SaveToFileEvent += HandleSaveToFileClickAsync;
            View.ReadFromFileEvent += HandleReadFromFileClickAsync;

            _xmlSaveToFile = xmlSaveToFileIXml;
            _xmlReadFromFile = xmlReadFromFile;

            BindDataWithView();
        }

        //Binding data with view:
        private void BindDataWithView() => View.BindListBoxData(_employeeBindingSource);

        //Employee.ContractId -> EmployeeDto.ContractType method:
        private static int MapFromContractType(ContractType contractType) 
        {
            if (contractType == ContractType.Umowa1) return 1;
            else if (contractType == ContractType.Umowa2) return 2;
            else return 3;
        }

        //Employee.ContractType -> EmployeeDto.ContractId method:
        private static ContractType MapToContractType(int contractId)
        {
            if (contractId == 1) return ContractType.Umowa1;
            else if (contractId == 2) return ContractType.Umowa2;
            else return ContractType.Umowa3;
        }


        //Click Handlers:
        private void HandleEmployeeAddedClick(object? sender, EventArgs e)
        {
            var employeeDto = View.GetDataFromBoxes();
            _employeeBindingSource.Add(employeeDto);
        } 

        private void HandleEmployeeSelectedClick(object? sender, int index)
        {
            View.DisplayData((EmployeeDto)_employeeBindingSource[index]);
        }

        private async Task HandleSaveToFileClickAsync()
        {
            var employeeDtos = (List<EmployeeDto>)_employeeBindingSource.DataSource;

            var employees = employeeDtos
               .Select(e => new Employee()
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   DateOfBirth = e.DateOfBirth,
                   Salary = e.Salary,
                   Position = e.Position,
                   ContractType = MapToContractType(e.ContractId)
               })
               .ToList();

            await _xmlSaveToFile.SerializeEmployees(employees);
        }

        private async Task HandleReadFromFileClickAsync()
        {
            var employees = await _xmlReadFromFile.DeserializeEmployees();

            var employeesDto = employees
               .Select(e => new EmployeeDto()
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   DateOfBirth = e.DateOfBirth,
                   Salary = e.Salary,
                   Position = e.Position,
                   ContractId = MapFromContractType(e.ContractType)
               })
               .ToList();

            _employeeBindingSource.DataSource = employeesDto;
        }
    }
}
