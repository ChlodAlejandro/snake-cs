using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Objects
{
    class ConsoleSelect : Dictionary<int, ConsoleSelectLine>
    {

        public void WriteChoicesCenter()
        {
            int cursorRow = Console.CursorTop;
            int windowWidth = Console.BufferWidth;

            foreach (KeyValuePair<int, ConsoleSelectLine> pair in this)
            {
                Console.SetCursorPosition(0, cursorRow);
                Console.Write(Program.ClearLine);
                Console.SetCursorPosition(windowWidth / 2, cursorRow);
                pair.Value.Write();

                cursorRow++;
            }
        }

        public void WriteChoicesCenterOffset(int offset)
        {
            int cursorRow = Console.CursorTop;
            int windowWidth = Console.BufferWidth;

            foreach (KeyValuePair<int, ConsoleSelectLine> pair in this)
            {
                Console.SetCursorPosition(0, cursorRow);
                Console.Write(Program.ClearLine);
                Console.SetCursorPosition((windowWidth / 2) + offset, cursorRow);
                pair.Value.Write();

                cursorRow++;
            }
        }

        public int DisplaySelectionCenter()
        {
            int cursorRow = Console.CursorTop;
            int windowWidth = Console.BufferWidth;
            int offset = -3;

            Dictionary<int, int> indexes = new Dictionary<int, int>(); // index, value
            Dictionary<char, int> hotkeys = new Dictionary<char, int>(); // hotkey, value
            foreach (KeyValuePair<int, ConsoleSelectLine> pair in this)
            {
                indexes.Add(indexes.Count, pair.Key);
                hotkeys.Add(Char.ToLower(pair.Value.Selection[pair.Value.SelectionHighlightIndex]), pair.Key);
            }

            int currentIndex = 0;
            bool hotkey = false;

            WriteChoicesCenterOffset(offset);

            Console.SetCursorPosition(windowWidth / 2 - (2 - offset), cursorRow + currentIndex);
            new ConsoleLine(">", ConsoleColor.White).Write();

            ConsoleKey lastKey;
            char lastKeyChar;
            do {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                lastKey = pressedKey.Key;
                lastKeyChar = pressedKey.KeyChar;

                if (hotkeys.Keys.ToList().Contains(Char.ToLower(lastKeyChar)))
                {
                    hotkey = true;
                    break;
                }

                Console.SetCursorPosition(windowWidth / 2 - (2 - offset), cursorRow + currentIndex);
                Console.Write(' ');

                if (lastKey == ConsoleKey.UpArrow && currentIndex > 0)
                {
                    currentIndex--;
                }
                else if (lastKey == ConsoleKey.DownArrow && currentIndex < indexes.Count - 1)
                {
                    currentIndex++;
                }
                else if (lastKey != ConsoleKey.Enter)
                {
                    Console.Write((char) 7);
                }

                Console.SetCursorPosition(windowWidth / 2 - (2 - offset), cursorRow + currentIndex);
                new ConsoleLine(">", ConsoleColor.White).Write();
            } while (lastKey != ConsoleKey.Enter);

            if (hotkey)
                return hotkeys[lastKeyChar];
            else
                return indexes[currentIndex];
        }

    }
}
