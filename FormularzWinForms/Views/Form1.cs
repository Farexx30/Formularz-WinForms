using FormularzWinForms.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;
using System.Xml.Serialization;


//Zmienic strukture do wzorca MVP, sprobowac zmodyfikowac/uproscic nieco funkcje/metody + przejrzec ogolnie co i jak
namespace FormularzWinForms
{
    public partial class Form1 : Form
    {
        private readonly IXmlSaveToFile _xmlSaveToFile;
        private readonly IXmlReadFromFile _xmlReadFromFile;

        public Form1(IXmlSaveToFile xmlSaveToFileIXml, IXmlReadFromFile xmlReadFromFile)
        {
            InitializeComponent();
            _xmlSaveToFile = xmlSaveToFileIXml;
            _xmlReadFromFile = xmlReadFromFile;
        }

        private bool CheckAllPossibleErrors()
        {
            return !SetErrorIfFullNameEmpty(ImieTextBox)
                & !SetErrorIfFullNameEmpty(NazwiskoTextBox)
                & !SetErrorIfBadDateOfBirth()
                & !SetErrorIfChooseBadPosition();
        }

        private bool SetErrorIfBadDateOfBirth()
        {
            if (DataUrodzeniaDateTimePicker.Value > DateTime.Now)
            {
                FormErrorProvider.SetError(DataUrodzeniaDateTimePicker, "Niepoprawna data urodzenia");
                return true;
            }

            FormErrorProvider.SetError(DataUrodzeniaDateTimePicker, string.Empty);
            return false;
        }

        private bool SetErrorIfFullNameEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                FormErrorProvider.SetError(textBox, "To pole nie mo¿e byæ puste");
                return true;
            }

            FormErrorProvider.SetError(textBox, string.Empty);
            return false;
        }

        private bool SetErrorIfChooseBadPosition()
        {
            if (!StanowiskoComboBox.Items.Contains(StanowiskoComboBox.Text))
            {
                FormErrorProvider.SetError(StanowiskoComboBox, "Niepoprawne stanowisko");
                return true;
            }

            FormErrorProvider.SetError(StanowiskoComboBox, string.Empty);
            return false;
        }

        private ContractType GetCheckedRadioButton()
        {
            if (Umowa1RadioButton.Checked) return ContractType.Umowa1;
            else if (Umowa2RadioButton.Checked) return ContractType.Umowa2;
            return ContractType.Umowa3;
        }

        private Employee GetDataFromBoxes()
        {
            var employee = new Employee()
            {
                FirstName = ImieTextBox.Text,
                LastName = NazwiskoTextBox.Text,
                DateOfBirth = DataUrodzeniaDateTimePicker.Value,
                Salary = PensjaNumericUpDown.Value,
                Position = StanowiskoComboBox.Text,
                ContractType = GetCheckedRadioButton()
            };

            return employee;
        }

        private void DodajButton_Click(object sender, EventArgs e)
        {
            if (CheckAllPossibleErrors())
            {
                var employee = GetDataFromBoxes();

                DataListBox.Items.Add(employee.ToString());
            }
        }   

        private void WczytajButton_Click(object sender, EventArgs e)
        {
            DataListBox.Items.Clear();
            var employees = _xmlReadFromFile.DeserializeEmployees();

            foreach (Employee employee in employees)
            {
                DataListBox.Items.Add(employee.ToString());
            }
        }

        private void ZapiszButton_Click(object sender, EventArgs e)
        {
            //var employees = DataListBox.Items
            //    .Cast<Employee>()
            //    .ToList();

            var employees = new List<Employee>();
            foreach(var employee in DataListBox.Items)
            {
                string[] employeeData = employee.ToString()!.Split(", ");
                var employeeObject = new Employee()
                {
                    FirstName = employeeData[0],
                    LastName = employeeData[1],
                    DateOfBirth = DateTime.Parse(employeeData[2]),
                    Salary = decimal.Parse(employeeData[3][..^4]),
                    Position= employeeData[4],
                    ContractType = Employee.MapToContractType(employeeData[5])
                };
    
                employees.Add(employeeObject);
            }

            _xmlSaveToFile.SerializeEmployees(employees);
        }
    }
}
