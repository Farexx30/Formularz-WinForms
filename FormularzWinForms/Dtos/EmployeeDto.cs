using FormularzWinForms.Models;

namespace FormularzWinForms.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; } = null!;
        public int ContractId { get; set; }

        public override string ToString()
        {
            string contractTypeString = MapFromContractId(ContractId);
            return $"{FirstName}, {LastName}, {DateOfBirth:dd.MM.yyyy}r., {Salary} PLN, {Position}, {contractTypeString}";
        }

        private static string MapFromContractId(int contractId)
        {
            if (contractId == 1) return "Umowa na czas nieokreślony";
            else if (contractId == 2) return "Umowa na czas określony";
            return "Umowa zlecenie";
        }
    }
}
