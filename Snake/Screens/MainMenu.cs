using Snake.Objects;
using System;

namespace Snake.Screens
{
    internal class MainMenu : Screen
    {

        public void Display()
        {
            bool exiting = false;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(Console.CursorLeft, (Console.BufferHeight / 2) - Messages.INTRO_MESSAGE.Count - 1);
                Messages.INTRO_MESSAGE.WriteAllLinesCentered();

                int choicesRow = Console.CursorTop + 2;

                Console.SetCursorPosition(Console.CursorLeft, (Console.BufferHeight) - Messages.COPYRIGHT_INFO.Count - 1);
                Messages.COPYRIGHT_INFO.WriteAllLinesCentered();

                Console.CursorTop = choicesRow;

                switch (Menus.MAIN_MENU.DisplaySelectionCenter())
                {
                    case 1:
                        {
                            new Game().Display();
                            break;
                        }
                    case 2:
                        {
                            // options
                            break;
                        }
                    case 3:
                        {
                            new AboutScreen().Display();
                            break;
                        }
                    case 0:
                        {
                            exiting = true;
                            break;
                        }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            } while (!exiting);
        }
    }
}
