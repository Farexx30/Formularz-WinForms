using FormularzWinForms.Models;

namespace FormularzWinForms
{
    public interface IEmployeeView
    {       
        event Action? EmployeeAddedAction;
        event Func<Task> ReadFromFileAction;
        event Func<Task> SaveToFileAction;
        void BindListBoxData(BindingSource employees);
        Employee GetDataFromBoxes();
    }

    public partial class EmployeeView : Form, IEmployeeView
    {
        private int _lastClickedIndex = -2;

        public event Action? EmployeeAddedAction;
        public event Func<Task> ReadFromFileAction = default!;
        public event Func<Task> SaveToFileAction = default!;

        public EmployeeView()
        {
            InitializeComponent();
        }


        //Bind data with presenter:
        public void BindListBoxData(BindingSource employees) => DataListBox.DataSource = employees;


        //Error methods:
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
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
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


        //Getting from Form methods:
        public Employee GetDataFromBoxes()
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

        private ContractType GetCheckedRadioButton()
        {
            if (Umowa1RadioButton.Checked) return ContractType.Umowa1;
            else if (Umowa2RadioButton.Checked) return ContractType.Umowa2;
            return ContractType.Umowa3;
        }


        //Getting from ListBox methods:
        private void SelectedEmployeeFromListBoxClick(object sender, EventArgs e)
        {           
            if (DataListBox.SelectedIndex != -1 && _lastClickedIndex != DataListBox.SelectedIndex)
            {
                FormErrorProvider.Clear();

                string[] selectedEmployeeData = DataListBox.SelectedItem!.ToString()!.Split(", ");

                ImieTextBox.Text = selectedEmployeeData[0];
                NazwiskoTextBox.Text = selectedEmployeeData[1];
                DataUrodzeniaDateTimePicker.Value = DateTime.Parse(selectedEmployeeData[2][..^2]);
                PensjaNumericUpDown.Value = decimal.Parse(selectedEmployeeData[3][..^4]);
                StanowiskoComboBox.Text = selectedEmployeeData[4];
                CheckCorrectRadioButton(selectedEmployeeData[5]);

                _lastClickedIndex = DataListBox.SelectedIndex;
            }
            else if (_lastClickedIndex == DataListBox.SelectedIndex)
            {
                SetDefaultValuesToAllFormBoxes();

                DataListBox.SelectedIndex = -1;
                _lastClickedIndex = -2;
            }            
        }

        private void CheckCorrectRadioButton(string contractTypeString)
        {
            if (contractTypeString == "Umowa na czas nieokreœlony") Umowa1RadioButton.Checked = true;
            else if (contractTypeString == "Umowa na czas okreœlony") Umowa2RadioButton.Checked = true;
            else Umowa3RadioButton.Checked = true;
        }


        //Click methods:
        private void AddToListBoxClicked(object sender, EventArgs e)
        {
            if (CheckAllPossibleErrors())
            {
                EmployeeAddedAction?.Invoke();
                SetDefaultValuesToAllFormBoxes();
            }
        }

        private async void ReadFromFileClickAsync(object sender, EventArgs e)
        {
            if (DataListBox.SelectedIndex != -1) SetDefaultValuesToAllFormBoxes();

            await ReadFromFileAction.Invoke();

            DataListBox.SelectedIndex = -1;
            _lastClickedIndex = -2;
        }

        private async void SaveToFileClickAsync(object sender, EventArgs e)
        {
            await SaveToFileAction.Invoke();
        }


        //Additional methods:
        private void SetDefaultValuesToAllFormBoxes()
        {
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            DataUrodzeniaDateTimePicker.Value = DateTime.Now;
            PensjaNumericUpDown.Value = 4000;
            StanowiskoComboBox.SelectedIndex = 0;
            Umowa1RadioButton.Checked = true;
            DataListBox.SelectedIndex = -1;
        }
    }
}
