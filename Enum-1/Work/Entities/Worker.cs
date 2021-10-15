using Work.Entities.Enums;
using System.Collections.Generic;

namespace Work
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Associação (Composição) com a classe Department
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // Associação(Composição) com a classe HourContract e
                                                                                              // já instanciando para garantir que não fique nula

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            // O Worker vai ganhar o salário base de qualquer forma, ou seja, é fixo, por isso será incluído na variável sum o valor BaseSalary
            double sum = BaseSalary; 

            // Percorrendo a lista de contratos
            foreach (HourContract contract in Contracts)
            {
                // Condição dada para somar os valores da lista de contratos quando os mesmos tiverem o mesmo ano e mesmo mês
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue(); // Operação que retornará o valor total do contrato
                }
            }
            return sum;
        }
    }
}
