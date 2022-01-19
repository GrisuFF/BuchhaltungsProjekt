using System;
using System.Collections.Generic;
using System.Text;

namespace BuchhaltungsProjekt
{
    class NewTransactionMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaktion");
            Console.WriteLine("----------------");

            string newTransactionName = InputTransactionName();
            decimal newTransactionAmount = InputTransactionAmount();
            DateTime newTransactionDate = InputTransactionDate();

            Transaction transaction = new Transaction(newTransactionName, newTransactionAmount, newTransactionDate);

            ProfileManager.CurrentProfile.AddTransaction(transaction);
            Console.WriteLine("Die folgende Transaktion wurde hinzugefügt");

            if (transaction.Amount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(transaction.ToString());
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;

            Menu nextMenu = new MainMenu();
            
        }

        private string InputTransactionName()
        {
            Console.Write("Anwendungszweck: ");
            return Console.ReadLine();
        }

        private decimal InputTransactionAmount()
        {
            decimal input;
            bool correctInput = true;

            Console.Write(" Betrag in CHF eingeben: ");

            while (true)
            {
                if (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiger Betrag!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                {
                    break;
                }
            }

            return input;
            
        }

        private DateTime InputTransactionDate()
        {
            DateTime input;

            while (true)
            {
                Console.Write("Datum (DD.MM.JJJJ): ");
                bool correctInput = true;

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiges Datum!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput)
                {
                    break;
                }
            }

            return input;
        }
    }
}
