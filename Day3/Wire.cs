using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    public class Wire
    {
        private List<Vector2> _points;
        private Dictionary<Vector2, int> _steps;

        public Wire(List<Vector2> points, Dictionary<Vector2, int> steps)
        {
            _points = points;
            _steps = steps;

            // Console.WriteLine("Total(" + _points.Count() + ")");
        }

        public IEnumerable<Vector2> FindCrossings(Wire other)
        {
            return _points.Intersect(other._points);
        }

        public int DistanceWithClosestCrossing(Wire other)
        {
            var distance = int.MaxValue;

            foreach (var crossing in FindCrossings(other))
            {
                var dist = Util.manhattan(Vector2.Zero, crossing);

                if (dist < distance)
                {
                    distance = dist;
                }
            }

            return distance;
        }

        public int LowestSteps(Wire other)
        {
            var steps = int.MaxValue;

            foreach (var crossing in FindCrossings(other))
            {
                var stepA = _steps[crossing];
                var stepB = other._steps[crossing];
                var sum = stepA + stepB;

                if (sum < steps)
                {
                    steps = sum;
                }
            }

            return steps;
        }

        public static Wire Parse(string input)
        {
            var moves = input.Split(',');
            var currentPosition = Vector2.Zero;
            var points = new List<Vector2>();
            var steps = new Dictionary<Vector2, int>();

            var step = 0;
            foreach (var move in moves)
            {
                var direction = move.Substring(0, 1);
                var quantity = int.Parse(move.Substring(1));

                for (int i = 0; i < quantity; i++)
                {
                    switch (direction)
                    {
                        case "R":
                            currentPosition.X++;
                            break;
                        case "L":
                            currentPosition.X--;
                            break;
                        case "U":
                            currentPosition.Y++;
                            break;
                        case "D":
                            currentPosition.Y--;
                            break;
                    }

                    step++;

                    if (!points.Contains(currentPosition))
                    {
                        points.Add(new Vector2(currentPosition.X, currentPosition.Y));
                    }

                    if (!steps.ContainsKey(currentPosition))
                    {
                        steps.Add(currentPosition, step);
                    }
                }
            }

            return new Wire(points, steps);
        }
    }
}