namespace Snake.Objects
{
    class Menus
    {

        public static readonly ConsoleSelect MAIN_MENU = new ConsoleSelect()
        {
            { 1, new ConsoleSelectLine("Start", 0) },
            { 2, new ConsoleSelectLine("Options", 0) },
            { 3, new ConsoleSelectLine("About", 0) },
            { 0, new ConsoleSelectLine("Exit", 0) }
        };

    }
}
