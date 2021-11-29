using System;
using System.Collections.Generic;
using System.Text;

namespace BuchhaltungsProjekt
{
    class StartMenu : Menue
    {
        public override void DisplayMenue()
        {
            Console.WriteLine("Willkommen zur Buchhaltungssoftware!");
            Console.WriteLine();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1] Neues Profil erstellen");
            Console.WriteLine("[2] Profil laden");
            Console.WriteLine();

            InputOption();
        }

        private void InputOption()
        {
            string input;
            Menue nextMenu;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine();

                bool correctInput = true;

                switch (input)
                {
                    case "1":
                        nextMenu = new CreatProfileMenue();
                        break;

                    case "2":
                        nextMenu = new LoadProfileMenue();
                        break;

                    default:
                        correctInput = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Eingabe!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                if (correctInput)
                    break;
                {

                }
            }
        }
    }
}
