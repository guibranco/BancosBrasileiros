
namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BancosBrasileiros;

    class Program
    {
        private static string fileContent = System.IO.File.ReadAllText("../../data/bancos.json");
        private static List<Bank> banks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bank>>(fileContent);

        /// <summary>
        /// The entry point of the application that initializes the program execution.
        /// </summary>
        /// <remarks>
        /// This method serves as the main entry point for the application. It first calls the
        /// <see cref="ShowBanks"/> method to display a list of available banks to the user.
        /// After that, it prompts the user to input their preferred bank comparison criteria
        /// by calling the <see cref="GetCompeFromUser"/> method. Finally, it filters the list
        /// of banks based on the user's input by invoking the <see cref="FilterBanks"/> method.
        /// This method orchestrates the flow of the application and ensures that the user
        /// can interact with the bank data effectively.
        /// </remarks>
        static void Main()
        {
            ShowBanks();
            var compe = GetCompeFromUser();
            FilterBanks(compe);
        }

        /// <summary>
        /// Prompts the user to input a 3-digit COMPE code and returns the entered value.
        /// </summary>
        /// <returns>A string representing the COMPE code entered by the user.</returns>
        /// <remarks>
        /// This method displays a message asking the user to enter a 3-digit COMPE code.
        /// It reads the input from the console and returns it as a string.
        /// The method does not perform any validation on the input, so it is the caller's responsibility
        /// to ensure that the input meets the expected format of a 3-digit code.
        /// </remarks>
        private static string GetCompeFromUser()
        {
            string compe;
            do
            {
                Console.Write("Buscar COMPE (3 dígitos): ");
                compe = Console.ReadLine();
            } while (!IsValidCompe(compe));

            return compe;
        }

        /// <summary>
        /// Validates if the given <paramref name="compe"/> is a valid COMPE code.
        /// </summary>
        /// <param name="compe">A string representing the COMPE code to validate.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="compe"/> is exactly 3 characters long
        /// and consists only of numeric digits; otherwise, <see langword="false"/>.
        /// </returns>
        private static bool IsValidCompe(string compe)
        {
            return compe.Length == 3 && compe.All(char.IsDigit);
        }

        /// <summary>
        /// Displays information about the banks in the collection.
        /// </summary>
        /// <remarks>
        /// This method iterates through a collection of bank objects and prints their details to the console.
        /// For each bank, it displays the bank's name, CNPJ (a unique identifier for Brazilian companies),
        /// and additional attributes such as type, charge options, credit document availability,
        /// PIX type, salary portability, and the last updated date.
        /// The output is formatted with color coding for better visibility, using magenta for bank names
        /// and white for other details. This method does not return any value and is intended for
        /// console output only.
        /// </remarks>
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

        /// <summary>
        /// Filters and displays banks based on the provided COMPE code.
        /// </summary>
        /// <param name="compe">The COMPE code used to filter the banks.</param>
        /// <remarks>
        /// This method clears the console and retrieves a list of banks that match the specified COMPE code.
        /// If matching banks are found, it displays their details including CNPJ, long name, type, charge options,
        /// credit document options, PIX type, salary portability status, and the last updated date.
        /// If no banks are found, it prompts the user with options to either list all banks or search for another COMPE code.
        /// The user can input their choice, and the method will either call the main listing function or recursively call itself
        /// to filter banks again based on a new COMPE code input by the user.
        /// </remarks>
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
