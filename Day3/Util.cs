using System;
using System.Numerics;

namespace ConsoleApp1
{
    public class Util
    {
        public static int manhattan(Vector2 a, Vector2 b)
        {
            return (int) (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y));
        }
    }
}