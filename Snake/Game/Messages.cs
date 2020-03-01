using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    static class Messages
    {

        public static ConsoleLines INTRO_MESSAGE = new ConsoleLines()
        {
            {"+==============================================+", ConsoleColor.Green},
            {"| +------+ +--\\   +--+ "  + "  +----+   "  + "+--+  +--+ "  + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| |      | |   \\  |  | "  + " /      \\  " + "|  | /  /  "   + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| |   +--+ |  \\ \\ |  | " + "/        \\ " + "|  |/  /   "   + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| |      | |  |\\ \\|  | " + "|  +--+  | "  + "|     |    "   + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| +--+   | |  | \\    | "  + "|  |  |  | "  + "|  |\\  \\   " + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| |      | |  |  \\   | "  + "|  |  |  | "  + "|  | \\  \\  " + " " + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"| +------+ +--+   +--+ "   + "+--+  +--+ "  + "+--+  +--+ "  + "E" + " |", ConsoleColor.Black, ConsoleColor.Green},
            {"+==============================================+", ConsoleColor.Green}
        };

        public static ConsoleLines COPYRIGHT_INFO = new ConsoleLines()
        {
            { "Licensed under GNU-GPL v3. Hourglass Technologies LLC", ConsoleColor.Blue },
            { "Available free of charge to everyone, forever.", ConsoleColor.Green }
        };

        public static ConsoleLines ABOUT = new ConsoleLines()
        {
            { " Snake - v" + Program.VERSION + " ", ConsoleColor.Black, ConsoleColor.Green },
            "",
            "",
            { "Developed by Chlod Aidan Alejandro", ConsoleColor.Yellow },
            "",
            { "This program is distributed free of charge. The", ConsoleColor.White },
            { "source code for this program is published under", ConsoleColor.White },
            { " the GNU General Public License. You may modify,", ConsoleColor.White },
            { "distribute, and republish the program under the", ConsoleColor.White },
            { " condition of attribution to its original creator.", ConsoleColor.White },
            "",
            { "Protip!", ConsoleColor.Yellow },
            { "S + N + A + K + E + R + U + L + E + S", ConsoleColor.Green },
            "",
            { "[ Press Enter to continue. ]", ConsoleColor.Black, ConsoleColor.Yellow },
            "",
            COPYRIGHT_INFO
        };

    }
}
