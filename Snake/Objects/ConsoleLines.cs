using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    class ConsoleLines : List<ConsoleLine>
    {

        public void Add(string line)
        {
            Add(new ConsoleLine(line));
        }

        public void Add(string line, ConsoleColor foregroundColor)
        {
            Add(new ConsoleLine(line, foregroundColor));
        }
        public void Add(string line, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Add(new ConsoleLine(line, foregroundColor, backgroundColor));
        }

        public void Add(ConsoleLines additionalLines)
        {
            foreach (ConsoleLine c in additionalLines)
            {
                Add(c);
            }
        }

        public void WriteAllLines()
        {
            foreach (ConsoleLine c in this)
            {
                c.WriteLine();
            }
        }

        public void WriteAllLinesCentered(bool verticalCenter = false)
        {
            int cursorRow = Console.CursorTop;
            if (verticalCenter)
                cursorRow = (Console.BufferHeight / 2) - (Count / 2);
            int windowWidth = Console.BufferWidth;

            foreach (ConsoleLine c in this)
            {
                Console.SetCursorPosition(0, cursorRow);
                Console.Write(Program.ClearLine);
                Console.SetCursorPosition((windowWidth / 2) - (c.Length / 2), cursorRow);
                c.Write();
                cursorRow++;
            }
        }

    }
}
