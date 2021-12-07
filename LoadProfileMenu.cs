using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BuchhaltungsProjekt
{
    class LoadProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Wähle ein Profil aus:");
            Console.WriteLine("---------------------");
            ShowProfiles();
            Console.WriteLine();
            string profilePath = InputProfileName();

            if (profilePath != "cancel")
            {
                ProfileManager.LoadProfile(profilePath);
                Menu nextMenu = new MainMenu();
            }
            else
            {
                Menu nextMenu = new StartMenu();
            }

        }

        private void ShowProfiles()
        {
            string[] profilFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");

            foreach (string file in profilFiles)
            {
                Console.WriteLine("- " + Path.GetFileName(file));
            }
        }

        private string InputProfileName()
        {
            string input = "";

            while (true)
            {
                Console.WriteLine("Zu ladendes Profil angeben [cancel zum abbrechen]");
                input = Console.ReadLine();
                string[] profilFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
                bool correctInput = false;

                if (input == "cancel")
                {
                    correctInput = true;
                }
                else
                {
                    for (int i = 0; i < profilFiles.Length; i++)
                    {
                        profilFiles[i] = Path.GetFileName(profilFiles[i]);

                        if (input == profilFiles[i])
                        {
                            correctInput = true;
                            input = AppContext.BaseDirectory + input;
                            break;
                        }
                    }
                }

                if (correctInput)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiges Profil!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

            return input;
        }
    }
}
