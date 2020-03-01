using Snake.Screens;
using System;

namespace Snake
{
    static class Program
    {
        public static int GameState = 0;

        public const string VERSION = "0.1.0";
        public const int WINDOW_WIDTH = 55;
        public const int WINDOW_HEIGHT = 26;

        private static int ConsoleBottom
        {
            get
            {
                return Console.BufferHeight - 2;
            }
        }
        private static int ConsoleEnd
        {
            get
            {
                return Console.BufferWidth - 1;
            }
        }
        public static string ClearLine
        {
            get
            {
                string z = "";
                for (int x = 0; x < (Console.WindowWidth - 1) - Console.CursorLeft; x++)
                {
                    z += " ";
                }
                return z;
            }
        }

        static void Main(string[] args)
        {
            // Set Console size
            Console.SetWindowSize(Utils.Clamp(WINDOW_WIDTH, 1, Console.LargestWindowWidth), Utils.Clamp(WINDOW_HEIGHT, 1, Console.WindowHeight));

            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Console.BufferWidth, Console.BufferHeight);

            Console.Clear();

            // disable cursor mark
            Console.CursorVisible = false;

            new MainMenu().Display();
        }
    }
}
