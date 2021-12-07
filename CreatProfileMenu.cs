using System;
using System.Collections.Generic;
using System.Text;

namespace BuchhaltungsProjekt
{
    class CreatProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profileStartBalance = InputStartBalance();

            ProfileManager.CreateProfile(profileName, profileStartBalance);

            Console.WriteLine("Profil wurde angelegt.");
        }

        private string InputName()
        {
            while (true)
            {
                string input = " ";

                Console.Write("Profilname: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER! Ungültiger Name");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private bool ValidateName(string name)
        {
            if (ProfileManager.CheckIfProfileExists(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private decimal InputStartBalance()
        {
            while (true)
            {
                Console.Write("Start Kontostand: ");
                string strInput = Console.ReadLine();
                decimal input;

                if (!Decimal.TryParse(strInput,out input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER! Ungültiger Geldbetrag");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return input;
            }
        }
    }
}
