using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string contractString = MapFromContractType(ContractType);
            return $"{FirstName}, {LastName}, {DateOfBirth:dd.MM.yyyy}r., {Salary} PLN, {Position}, {contractString}";
        }


        private static string MapFromContractType(ContractType contractType)
        {
            if (contractType == ContractType.Umowa1) return "Umowa na czas nieokreślony";
            else if (contractType == ContractType.Umowa2) return "Umowa na czas określony";
            return "Umowa zlecenie";
        }

        //private static ContractType MapToContractType(string contractString)
        //{
        //    if (contractString == "Umowa na czas nieokreślony") return ContractType.Umowa1;
        //    else if (contractString == "Umowa na czas określony") return ContractType.Umowa2;
        //    return ContractType.Umowa3;
        //}
    }
}
