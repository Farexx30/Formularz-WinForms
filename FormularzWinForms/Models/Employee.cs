namespace FormularzWinForms.Models
{
    public enum ContractType
    {
        Umowa1,
        Umowa2,
        Umowa3
    }

    public class Employee
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; } = null!;
        public ContractType ContractType { get; set; }
    }
}
