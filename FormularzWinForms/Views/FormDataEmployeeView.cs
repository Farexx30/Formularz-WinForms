namespace FormularzWinForms.Views
{
    public class FormDataEmployeeView
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; } = null!;
        public int ContractId { get; set; }
    }
}
