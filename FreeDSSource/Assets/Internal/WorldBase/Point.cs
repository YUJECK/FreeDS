using System;
using UnityEngine;

namespace Internal.WorldBase
{
    public struct Point
    {
        public int X;
        public int Y;

        public override bool Equals(object obj)
        {
            if (obj is Point point)
            {
                return point == this;
            }

            if (obj is Vector2 vector2)
            {
                return vector2 == this.ToVector2();
            }

            if (obj is Vector2Int vector2int)
            {
                return vector2int == this.ToVector2();
            }
            
            return false;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Y == p2.Y && p1.X == p2.X;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
        
        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }
        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public Vector2 ToVector2()
            => new(X, Y);

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}