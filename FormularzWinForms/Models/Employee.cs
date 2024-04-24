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
        ContractType MapToContractType(int contractId);
    }

    public class Employee : IEmployeeModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; } = null!;
        public ContractType ContractType { get; set; }


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

        public ContractType MapToContractType(int contractId)
        {
            if (contractId == 1) return ContractType.Umowa1;
            else if (contractId == 2) return ContractType.Umowa2;
            else return ContractType.Umowa3;
        }
    }
}
