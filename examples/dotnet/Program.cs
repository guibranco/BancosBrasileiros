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
            Console.ReadKey();
        }
    }
}
