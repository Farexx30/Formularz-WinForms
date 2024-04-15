using FormularzWinForms.Models;
using FormularzWinForms.Presenters;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using static System.Windows.Forms.ListBox;


//Zmienic strukture do wzorca MVP!!!, sprobowac zmodyfikowac/uproscic nieco funkcje/metody + przejrzec ogolnie co i jak
namespace FormularzWinForms
{
    public interface IEmployeeView
    {
        event Func<List<Employee>>? ReadFromFileAction;
        event Action<ObjectCollection>? SaveToFileAction;
    }

    public partial class EmployeeView : Form, IEmployeeView
    {
        public event Func<List<Employee>>? ReadFromFileAction;
        public event Action<ObjectCollection>? SaveToFileAction;

        public EmployeeView()
        {
            InitializeComponent();
        }

        public void AddToListBoxClicked(object sender, EventArgs e)
        {
            if (CheckAllPossibleErrors())
            {
                var employee = GetDataFromBoxes();

                DataListBox.Items.Add(employee.ToString());
            }
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

        private void ReadFromFileClick(object sender, EventArgs e)
        {
            DataListBox.Items.Clear();
            var employees = ReadFromFileAction?.Invoke();
            foreach (Employee employee in employees!)
            {
                DataListBox.Items.Add(employee.ToString());
            }
        }

        private void SaveToFileClick(object sender, EventArgs e)
        {
            //var employees = DataListBox.Items
            //    .Cast<Employee>()
            //    .ToList();

            SaveToFileAction?.Invoke(DataListBox.Items);
        }

        private void DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataListBox.SelectedIndex != -1)
            {
                string[] selectedEmployeeData = DataListBox.SelectedItem!.ToString()!.Split(", ");

                ImieTextBox.Text = selectedEmployeeData[0];
                NazwiskoTextBox.Text = selectedEmployeeData[1];
                DataUrodzeniaDateTimePicker.Value = DateTime.Parse(selectedEmployeeData[2]);
                PensjaNumericUpDown.Value = decimal.Parse(selectedEmployeeData[3][..^4]);
                StanowiskoComboBox.Text = selectedEmployeeData[4];
                if (selectedEmployeeData[5] == "Umowa na czas nieokreœlony")
                    Umowa1RadioButton.Checked = true;
                else if (selectedEmployeeData[5] == "Umowa na czas okreœlony")
                    Umowa2RadioButton.Checked = true;
                else
                    Umowa3RadioButton.Checked = true;
            }
        }
    }
}
