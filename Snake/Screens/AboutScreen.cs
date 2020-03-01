using Snake.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Screens
{
    internal class AboutScreen : Screen
    {
        public void Display()
        {
            Console.Clear();
            Messages.ABOUT.WriteAllLinesCentered(true);
            ConsoleKey lastKey;
            do
            {
                lastKey = Console.ReadKey().Key;
            } while (lastKey != ConsoleKey.Enter);
        }
    }
}
