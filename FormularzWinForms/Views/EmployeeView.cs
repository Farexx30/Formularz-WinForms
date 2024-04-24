using FormularzWinForms.Dtos;

namespace FormularzWinForms
{
    public interface IEmployeeView
    {       
        event EventHandler? EmployeeAddedEvent;
        event EventHandler<int>? EmployeeSelectedEvent;
        event Func<Task> ReadFromFileEvent;
        event Func<Task> SaveToFileEvent;
        void BindListBoxData(BindingSource employees);
        EmployeeDto GetDataFromBoxes();
        void DisplayData(EmployeeDto employeeDto);
    }

    public partial class EmployeeView : Form, IEmployeeView
    {
        private int _lastClickedIndex = -2;

        public event EventHandler? EmployeeAddedEvent;
        public event EventHandler<int>? EmployeeSelectedEvent;
        public event Func<Task> ReadFromFileEvent = null!;
        public event Func<Task> SaveToFileEvent = null!;

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
        public EmployeeDto GetDataFromBoxes()
        {
            var employeeData = new EmployeeDto()
            {
                FirstName = ImieTextBox.Text.Trim(),
                LastName = NazwiskoTextBox.Text.Trim(),
                DateOfBirth = DataUrodzeniaDateTimePicker.Value,
                Salary = PensjaNumericUpDown.Value,
                Position = StanowiskoComboBox.Text,
                ContractId = GetCheckedRadioButton()
            };

            return employeeData;
        }

        private int GetCheckedRadioButton()
        {
            if (Umowa1RadioButton.Checked) return 1;
            else if (Umowa2RadioButton.Checked) return 2;
            return 3;
        }


        //Click methods (and connected with it methods):
        private void SelectedEmployeeFromListBoxClick(object sender, EventArgs e)
        {           
            if (DataListBox.SelectedIndex != -1 && _lastClickedIndex != DataListBox.SelectedIndex)
            {
                FormErrorProvider.Clear();

                EmployeeSelectedEvent?.Invoke(this, DataListBox.SelectedIndex);

                _lastClickedIndex = DataListBox.SelectedIndex;
            }
            else if (_lastClickedIndex == DataListBox.SelectedIndex)
            {
                SetDefaultValuesToAllFormBoxes();

                DataListBox.SelectedIndex = -1;
                _lastClickedIndex = -2;
            }            
        }

        //Method displaying employees' data who is clicked:
        public void DisplayData(EmployeeDto employeeDto)
        {
            ImieTextBox.Text = employeeDto.FirstName;
            NazwiskoTextBox.Text = employeeDto.LastName;
            DataUrodzeniaDateTimePicker.Value = employeeDto.DateOfBirth;
            PensjaNumericUpDown.Value = employeeDto.Salary;
            StanowiskoComboBox.Text = employeeDto.Position;
            CheckCorrectRadioButton(employeeDto.ContractId);
        }

        private void CheckCorrectRadioButton(int contractId)
        {
            if (contractId == 1) Umowa1RadioButton.Checked = true;
            else if (contractId == 2) Umowa2RadioButton.Checked = true;
            else Umowa3RadioButton.Checked = true;
        }

        private void AddToListBoxClick(object sender, EventArgs e)
        {
            if (CheckAllPossibleErrors()) //This might be in presenter as well
            {
                EmployeeAddedEvent?.Invoke(this, EventArgs.Empty);
                SetDefaultValuesToAllFormBoxes();
            }
        }

        private async void ReadFromFileClickAsync(object sender, EventArgs e)
        {
            if (DataListBox.SelectedIndex != -1) SetDefaultValuesToAllFormBoxes();

            await ReadFromFileEvent.Invoke();

            DataListBox.SelectedIndex = -1;
            _lastClickedIndex = -2;
        }

        private async void SaveToFileClickAsync(object sender, EventArgs e)
        {
            await SaveToFileEvent.Invoke();
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
