using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    class GameData
    {
        public SnakeObject Snake;
        public Position FoodPosition;

        public int GameHeight;
        public int GameWidth;

        public GameState GameState;
        public Stopwatch GameTimer;

        public GameData()
        {
            GameState = GameState.Idle;
            GameTimer = new Stopwatch();
            Snake = new SnakeObject();

            GameHeight = Console.BufferHeight;
            GameWidth = Console.BufferWidth - 1;
        }

        public void GenerateNewFood(int offsetX = 1, int offsetY = 1)
        {
            if (FoodPosition != null)
            {
                Console.SetCursorPosition(FoodPosition.X + offsetX, FoodPosition.Y + offsetY);
                new ConsoleLine("?", ConsoleColor.Black).Write();
            }

            Position NewFoodPosition;
            do
            {
                NewFoodPosition = Position.RandomPosition(0, GameWidth - 3, 0, GameHeight - 3);
            } while (Snake.BodyPositions.ContainsValue(NewFoodPosition));

            FoodPosition = NewFoodPosition;

            Console.SetCursorPosition(FoodPosition.X + offsetX, FoodPosition.Y + offsetY);
            new ConsoleLine("?", ConsoleColor.Red, ConsoleColor.Red).Write();
        }
    }

    enum GameState
    {
        Idle,
        Running,
        Paused,
        Ended
    }
}
