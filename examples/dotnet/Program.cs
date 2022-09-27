namespace ConsoleApp
{
    using BancosBrasileiros;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Hello World!");

            var fileContent = System.IO.File.ReadAllText("banks.json");
            var banks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bank>>(fileContent);

            Console.WriteLine($"Banks: {banks.Count}");
            foreach(var bank in banks)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{bank.Compe}\t[CNPJ: {bank.Document}]\t{bank.LongName}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\tTipo: {bank.Type ?? ""}");
                Console.WriteLine($"\tBoleto: {bank.Charge??false}");
                Console.WriteLine($"\tTED/DOC: {bank.CreditDocument??false}");
                Console.WriteLine($"\tPIX: {bank.PixType??"False"}");
                Console.WriteLine($"\tPortabilidade: {bank.SalaryPortability??"False"}");
                Console.WriteLine($"\tAtualizado em: {bank.DateUpdated}");
            }
            Console.ReadKey();
        }
    }
}
