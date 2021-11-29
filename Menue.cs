using System;


namespace BuchhaltungsProjekt
{
    abstract class Menue
    {
        public Menue()
        {
            Console.Clear();
            DisplayMenue();
        }

        public abstract void DisplayMenue();
    }
}
