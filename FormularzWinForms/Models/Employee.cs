namespace FormularzWinForms.Models
{
    public enum ContractType
    {
        Umowa1,
        Umowa2,
        Umowa3
    }

    public interface IEmployeeModel
    {
        
    }

    public class Employee : IEmployeeModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; } = null!;
        public ContractType ContractType { get; set; } = ContractType.Umowa1;


        public override string ToString()
        {
            string contractTypeString = MapFromContractType(ContractType);
            return $"{FirstName}, {LastName}, {DateOfBirth:dd.MM.yyyy}r., {Salary} PLN, {Position}, {contractTypeString}";
        }


        private static string MapFromContractType(ContractType contractType)
        {
            if (contractType == ContractType.Umowa1) return "Umowa na czas nieokreślony";
            else if (contractType == ContractType.Umowa2) return "Umowa na czas określony";
            return "Umowa zlecenie";
        }
    }
}
