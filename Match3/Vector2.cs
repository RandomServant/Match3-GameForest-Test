using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    internal struct Vector2
    {
        public int X { get; }
        public int Y { get; }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsNearby(Vector2 other)
        {
            return (other.X == X && Math.Abs(other.Y - Y) == 1)
                    || (other.Y == Y && Math.Abs(other.X - X) == 1);
        }

        public override string ToString()
        {
            return $"[{X}; {Y}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2 vector)
            {
                return (vector.X == X && vector.Y == Y);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return X + Y;
        }
    }
}
