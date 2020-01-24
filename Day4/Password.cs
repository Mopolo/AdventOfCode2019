using System;
using System.Linq;

namespace Day4
{
    public class Password
    {
        const int MAX_NUMBER = 999999;

        private int _min;
        private int _max;

        public Password(int min, int max)
        {
            _min = min;
            _max = Math.Min(max, MAX_NUMBER);
        }

        public int CountMatches()
        {
            var count = 0;
            
            for (int i = _min; i < _max; i++)
            {
                if (Matches(i))
                {
                    count++;
                }
            }

            return count;
        }

        public bool Matches(int input)
        {
            Console.Write("\r" + input);
            
            // if (input < _min || input > _max)
            // {
            //     return false;
            // }
            
            var digits = input.ToString().Select(x => int.Parse(x.ToString()));
            var previous = -1;
            var adjacents = 0;
            var hasTwoAdjacents = false;
            
            // Console.WriteLine();
            foreach (var digit in digits)
            {
                // Console.Write(digit + ",");
                if (digit < previous)
                {
                    return false;
                }

                if (digit == previous)
                {
                    adjacents++;
                }
                else
                {
                    if (adjacents == 1)
                    {
                        hasTwoAdjacents = true;
                    }

                    adjacents = 0;
                }

                previous = digit;
            }

            return hasTwoAdjacents || adjacents == 1;
        }
    }
}