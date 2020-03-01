using Snake.Objects;
using System;
using System.Threading;

namespace Snake.Screens
{
    internal class Game : Screen
    {
        GameData GameData;
        GameComputer GameComputer;

        Thread GameComputerThread;

        internal Game()
        {
            Initialize();
        }

        char[] Secret = new char[10];
        readonly char[] SecretKeyword = new char[]
        {
            's', 'n', 'a', 'k', 'e', 'r', 'u', 'l', 'e', 's'
        };

        private void Initialize()
        {
            if (GameComputerThread != null && GameComputerThread.IsAlive)
                GameComputerThread.Abort();

            GameData = new GameData();
            GameComputer = new GameComputer(ref GameData);

            GameComputerThread = new Thread(new ThreadStart(GameComputer.Start));

            GameData.GameHeight = Console.BufferHeight;
            GameData.GameWidth = Console.BufferWidth;

            GameComputerThread.Start();
        }

        public void Display()
        {
            Console.Clear();

            bool exiting = false;
            ConsoleKeyInfo lastKey;
            do
            {
                lastKey = Console.ReadKey(true);

                Secret = Utils.AppendOrReplace(Secret, lastKey.KeyChar);
                if (Secret == SecretKeyword)
                    GameData.Snake.InfiniteStretch = true;

                if (lastKey.Key == ConsoleKey.Escape)
                {
                    exiting = true;
                    break;
                }
                else if (GameData.GameState == GameState.Ended && lastKey.Key == ConsoleKey.R)
                {
                    exiting = true;
                    break;
                }
                else if (GameData.GameState != GameState.Running)
                {
                    continue;
                }
                else if (lastKey.Key == ConsoleKey.UpArrow)
                {
                    GameData.Snake.Direction = SnakeDirection.Up;
                }
                else if (lastKey.Key == ConsoleKey.DownArrow)
                {
                    GameData.Snake.Direction = SnakeDirection.Down;
                }
                else if (lastKey.Key == ConsoleKey.LeftArrow)
                {
                    GameData.Snake.Direction = SnakeDirection.Left;
                }
                else if (lastKey.Key == ConsoleKey.RightArrow)
                {
                    GameData.Snake.Direction = SnakeDirection.Right;
                }
            } while (!exiting);

            Secret = "-----------".ToCharArray();

            GameComputerThread.Abort();
        }

        public SnakeObject SpawnSnake() => new SnakeObject();
    }

    internal class GameComputer
    {
        readonly ConsoleLine BORDER_CHARACTER = new ConsoleLine("?", ConsoleColor.White, ConsoleColor.White);
        public static readonly int StartFPS = 50;
        public static int FPS = StartFPS;

        public long lastUpdate;

        GameData GameData;

        public GameComputer(ref GameData data)
        {
            GameData = data;
        }

        public void Start()
        {
            DrawFrame();
            GameData.GameState = GameState.Running;
            GameData.GameTimer.Start();
            GameData.GenerateNewFood(1, 1);

            lastUpdate = 0;

            while (GameData.GameState == GameState.Running || GameData.GameState == GameState.Paused)
            {
                NextFrameIfReady();
            }
        }

        public void NextFrameIfReady()
        {
            FPS = StartFPS + Utils.Clamp(6 + ((int) Math.Floor((GameData.Snake.Length - 4) * 0.8)), 8, 120);
            if (GameData.GameTimer.ElapsedMilliseconds - lastUpdate > 1000.0 / FPS)
            {
                DrawFrame();

                lastUpdate = GameData.GameTimer.ElapsedMilliseconds;
            }
        }

        public void DrawFrame()
        {
            DrawBorders();
            GameData.Snake.ComputeNextFrame(ref GameData);
            GameData.Snake.RenderFrames();
        }

        public void DrawBorders()
        {
            Console.SetCursorPosition(0, 0);
            while (Console.CursorTop == 0)
            {
                if (Console.CursorLeft == 0 || Console.CursorLeft == GameData.GameWidth - 1)
                    BORDER_CHARACTER.Write();
                else
                    BORDER_CHARACTER.Write();
            }
            Console.SetCursorPosition(0, 1);
            while (Console.CursorTop < GameData.GameHeight - 1)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                BORDER_CHARACTER.Write();
                Console.SetCursorPosition(GameData.GameWidth - 1, Console.CursorTop);
                BORDER_CHARACTER.Write();
            }
            int lastLine = Console.CursorTop - 1;
            Console.SetCursorPosition(0, lastLine);
            while (Console.CursorTop == lastLine)
            {
                if (Console.CursorLeft == 0 || Console.CursorLeft == GameData.GameWidth - 1)
                    BORDER_CHARACTER.Write();
                else
                    BORDER_CHARACTER.Write();
            }

            int score = GameData.Snake.Score;
            int sidescroll = (GameData.GameWidth / 2) - ((int)Math.Ceiling(score.ToString().Length / 2.0)) - 2;

            if (sidescroll < 0)
            {
                Console.WriteLine("congrats you broke the game");
                return;
            }

            Console.SetCursorPosition(sidescroll, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(score);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ]");
        }
    }
}
