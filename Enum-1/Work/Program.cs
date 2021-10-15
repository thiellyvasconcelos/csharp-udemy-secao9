using System;
using System.Collections.Generic;
using System.Globalization;
using Work.Entities;
using Work.Entities.Enums;

namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level: (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instanciando os objetos e incluindo valores aos construtores
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());

                // Instanciando o objeto contract e adicionando os valores aos construtores da classe HourContract
                HourContract contract = new HourContract(date, valuePerHour, hours);

                // Incluindo no objeto criado anteriormente (worker) os contratos informados na iteração
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            // Recortando o mês do ano, guardando o mês na variável month (iniciando na posição 0 e indo até a posição 2)
            int month = int.Parse(monthAndYear.Substring(0, 2));

            // Recortando o ano do mês, guardando o ano na variável year (iniciando na posição 3 até o final)
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture)} ");

        }
    }
}