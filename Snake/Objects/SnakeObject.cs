using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    class SnakeObject
    {

        public bool InfiniteStretch;
        public int Length { get; private set; } = 4;
        public int Score { get; private set; } = 0;

        // y, x (when displaying, relative to console border)
        Dictionary<int, Position> PreviousBodyPositions;
        public Dictionary<int, Position> BodyPositions { get; private set; }

        Position HeadPosition
        {
            get => BodyPositions[0];
        }

        public Position SnakeFront
        {
            get
            {
                switch (Direction)
                {
                    case SnakeDirection.Up:
                        return new Position(HeadPosition.X, HeadPosition.Y - 1);
                    case SnakeDirection.Down:
                        return new Position(HeadPosition.X, HeadPosition.Y + 1);
                    case SnakeDirection.Left:
                        return new Position(HeadPosition.X - 1, HeadPosition.Y);
                    case SnakeDirection.Right:
                        return new Position(HeadPosition.X + 1, HeadPosition.Y);
                    default:
                        return null;
                }
            }
        }

        private SnakeDirection snakeDirection;

        public SnakeDirection Direction
        {
            get => snakeDirection;
            set
            {
                switch (value)
                {
                    case SnakeDirection.Up:
                        if (snakeDirection == SnakeDirection.Down) return; else break;
                    case SnakeDirection.Down:
                        if (snakeDirection == SnakeDirection.Up) return; else break;
                    case SnakeDirection.Left:
                        if (snakeDirection == SnakeDirection.Right) return; else break;
                    case SnakeDirection.Right:
                        if (snakeDirection == SnakeDirection.Left) return; else break;
                }
                snakeDirection = value;
            }
        }

        public SnakeObject()
        {
            BodyPositions = new Dictionary<int, Position>()
            {
                { 3, new Position(3, 3) },
                { 2, new Position(4, 3) },
                { 1, new Position(5, 3) },
                { 0, new Position(6, 3) },
            };

            Direction = SnakeDirection.Right;
        }

        public bool SnakePartInHeadDirection(SnakeDirection direction)
        {
            switch (direction)
            {
                case SnakeDirection.Up:
                    return SnakeInPosition(new Position(BodyPositions[0].X, BodyPositions[0].Y - 1));
                case SnakeDirection.Down:
                    return SnakeInPosition(new Position(BodyPositions[0].X, BodyPositions[0].Y + 1));
                case SnakeDirection.Left:
                    return SnakeInPosition(new Position(BodyPositions[0].X - 1, BodyPositions[0].Y));
                case SnakeDirection.Right:
                    return SnakeInPosition(new Position(BodyPositions[0].X + 1, BodyPositions[0].Y));
                default:
                    return false;
            }
        }

        public bool SnakeInPosition(Position pos)
        {
            return BodyPositions.ContainsValue(pos);
        }

        public void ComputeNextFrame(ref GameData gameData)
        {
            if (InfiniteStretch)
                Length++;

            // calculate death frames
            if (
                BodyPositions.ContainsValue(SnakeFront)
                || SnakeFront.X == -1
                || SnakeFront.X == Console.BufferWidth - 2
                || SnakeFront.Y == -1
                || SnakeFront.Y == Console.BufferHeight - 3)
                gameData.GameState = GameState.Ended;

            if (gameData.GameState == GameState.Ended)
            {
                Console.SetCursorPosition(15, 5);
                new ConsoleLine("DEAD", ConsoleColor.Red).Write();
                return;
            }

            // calculate food eat

            if (gameData.FoodPosition != null && (SnakeFront.X == gameData.FoodPosition.X && SnakeFront.Y == gameData.FoodPosition.Y))
            {
                Length++;
                Score++;
                gameData.GenerateNewFood(1, 1);
            }

            // calculate new positions

            Dictionary<int, Position> newSnakePosition = new Dictionary<int, Position>();

            newSnakePosition.Add(0, SnakeFront);
            for (int newPositionIndex = 0; newSnakePosition.Count <= Length; newPositionIndex++)
            {
                newSnakePosition.Add(newSnakePosition.Count, BodyPositions[newPositionIndex]);
            }

            // set new variables

            PreviousBodyPositions = BodyPositions;
            BodyPositions = newSnakePosition;
        }

        public void RenderFrames(int offsetX = 1, int offsetY = 1)
        {
            foreach (KeyValuePair<int, Position> bodyPart in PreviousBodyPositions)
            {
                Console.SetCursorPosition(offsetX + bodyPart.Value.X, offsetY + bodyPart.Value.Y);
                new ConsoleLine("?", ConsoleColor.Black, ConsoleColor.Black).Write();
            }

            foreach (KeyValuePair<int, Position> bodyPart in BodyPositions)
            {
                Console.SetCursorPosition(offsetX + bodyPart.Value.X, offsetY + bodyPart.Value.Y);
                if (bodyPart.Key == 0)
                    new ConsoleLine("?", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen).Write();
                else
                    new ConsoleLine("?", ConsoleColor.Green, ConsoleColor.Green).Write();
            }
        }

    }

    enum SnakeDirection
    {
        Up, Down, Left, Right
    }
}
