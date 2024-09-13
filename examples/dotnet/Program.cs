namespace ConsoleApp
{
    using BancosBrasileiros;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string fileContent = System.IO.File.ReadAllText("../../data/bancos.json");
        private static List<Bank> banks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bank>>(
            fileContent
        );

        static void Main()
        {
            ShowBanks();
            var compe = GetCompeFromUser();
            FilterBanks(compe);
        }
        private static string GetCompeFromUser()
        {
            Console.Write("Buscar COMPE (3 dígitos): ");
            return Console.ReadLine();
        }
        private static void ShowBanks()
        {
            Console.WriteLine($"Banks: {banks.Count}");
            foreach (var bank in banks)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{bank.Compe}\t[CNPJ: {bank.Document}]\t{bank.LongName}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\tTipo: {bank.Type ?? ""}");
                Console.WriteLine($"\tBoleto: {bank.Charge ?? false}");
                Console.WriteLine($"\tTED/DOC: {bank.CreditDocument ?? false}");
                Console.WriteLine($"\tPIX: {bank.PixType ?? "False"}");
                Console.WriteLine($"\tPortabilidade: {bank.SalaryPortability ?? "False"}");
                Console.WriteLine($"\tAtualizado em: {bank.DateUpdated}\n");
            }
        }
        private static void FilterBanks(string compe)
        {
            Console.Clear();

            var sortedBanks = banks.Where(b => b.Compe == compe);

            if (sortedBanks.Any())
            {
                foreach (var bank in sortedBanks)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{bank.Compe}\t[CNPJ: {bank.Document}]\t{bank.LongName}");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"\tTipo: {bank.Type ?? ""}");
                    Console.WriteLine($"\tBoleto: {bank.Charge ?? false}");
                    Console.WriteLine($"\tTED/DOC: {bank.CreditDocument ?? false}");
                    Console.WriteLine($"\tPIX: {bank.PixType ?? "False"}");
                    Console.WriteLine($"\tPortabilidade: {bank.SalaryPortability ?? "False"}");
                    Console.WriteLine($"\tAtualizado em: {bank.DateUpdated} \n");
                }
                return;
            }


            Console.WriteLine("Nenhum Resultado Encontrado.");
            Console.Write("1.Listar Todos \t 2.Buscar COMPE: ");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                Console.Clear();
                Main();
            }
            if (option == 2)
            {
                Console.Clear();
                Console.Write("Buscar COMPE (3 dígitos): ");
                compe = Console.ReadLine();
                FilterBanks(compe);
            }
        }
    }
}
