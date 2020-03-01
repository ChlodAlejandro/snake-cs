using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    class ConsoleLine
    {

        public string Content;
        public ConsoleColor ForegroundColor = ConsoleColor.Gray;
        public ConsoleColor BackgroundColor;
        public int Length
        {
            get
            {
                return Content.Length;
            }
        }

        public ConsoleLine(string content, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Content = content;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public ConsoleLine(string content)
        {
            Content = content;
        }

        public ConsoleLine(string content, ConsoleColor foregroundColor)
        {
            Content = content;
            ForegroundColor = foregroundColor;
        }

        public void Write()
        {
            ConsoleColor initFC = Console.ForegroundColor;
            ConsoleColor initBC = Console.BackgroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Write(Content);

            Console.ForegroundColor = initFC;
            Console.BackgroundColor = initBC;
        }

        public void WriteLine()
        {
            ConsoleColor initFC = Console.ForegroundColor;
            ConsoleColor initBC = Console.BackgroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.WriteLine(Content);

            Console.ForegroundColor = initFC;
            Console.BackgroundColor = initBC;
        }

    }
}
