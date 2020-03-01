using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    class ConsoleSelectLine
    {

        public string Selection;
        public int SelectionHighlightIndex;
        public ConsoleColor HighlightForegroundColor = ConsoleColor.Yellow;
        public ConsoleColor HighlightBackgroundColor;

        public ConsoleColor ForegroundColor = ConsoleColor.Gray;
        public ConsoleColor BackgroundColor;
        public int Length
        {
            get
            {
                return Selection.Length;
            }
        }

        public ConsoleSelectLine(string selection, int highlightIndex,
            ConsoleColor foregroundColor, ConsoleColor backgroundColor,
            ConsoleColor highlightForegroundColor, ConsoleColor highlightBackgroundColor)
        {
            Selection = selection;
            SelectionHighlightIndex = highlightIndex;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            HighlightForegroundColor = highlightForegroundColor;
            HighlightBackgroundColor = highlightBackgroundColor;
        }

        public ConsoleSelectLine(string selection, int highlightIndex)
        {
            Selection = selection;
            SelectionHighlightIndex = highlightIndex;
        }

        public ConsoleSelectLine(string content, ConsoleColor highlightForegroundColor, ConsoleColor highlightBackgroundColor)
        {
            Selection = content;
            HighlightForegroundColor = highlightForegroundColor;
            HighlightBackgroundColor = highlightBackgroundColor;
        }

        public void Write()
        {
            ConsoleColor initFC = Console.ForegroundColor;
            ConsoleColor initBC = Console.BackgroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            for (int index = 0; index < Selection.Length; index++)
            {
                char c = Selection[index];
                if (index == SelectionHighlightIndex)
                {
                    Console.ForegroundColor = ForegroundColor;
                    Console.BackgroundColor = BackgroundColor;
                    Console.Write("[");
                    Console.ForegroundColor = HighlightForegroundColor;
                    Console.BackgroundColor = HighlightBackgroundColor;
                    Console.Write(c);
                    Console.ForegroundColor = ForegroundColor;
                    Console.BackgroundColor = BackgroundColor;
                    Console.Write("]");
                }
                else
                {
                    Console.Write(c);
                }
            }

            Console.ForegroundColor = initFC;
            Console.BackgroundColor = initBC;
        }

        public void WriteLine()
        {
            ConsoleColor initFC = Console.ForegroundColor;
            ConsoleColor initBC = Console.BackgroundColor;

            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            for (int index = 0; index < Selection.Length; index++)
            {
                char c = Selection[index];
                if (index == SelectionHighlightIndex)
                {
                    Console.ForegroundColor = ForegroundColor;
                    Console.BackgroundColor = BackgroundColor;
                    Console.Write("[");
                    Console.ForegroundColor = HighlightForegroundColor;
                    Console.BackgroundColor = HighlightBackgroundColor;
                    Console.Write(c);
                    Console.ForegroundColor = ForegroundColor;
                    Console.BackgroundColor = BackgroundColor;
                    Console.Write("]");
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.Write("\n");

            Console.ForegroundColor = initFC;
            Console.BackgroundColor = initBC;
        }

    }
}
