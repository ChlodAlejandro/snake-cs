using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Objects
{
    
    class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position RandomPosition(int minX, int maxX, int minY, int maxY)
        {
            Random randomizer = new Random();

            int randX = randomizer.Next(minX, maxX);
            int randY = randomizer.Next(minY, maxY);

            return new Position(randX, randY);
        }
    }
}
