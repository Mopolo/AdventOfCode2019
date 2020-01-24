using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class MassComputer
    {
        public int ComputeFuel(int moduleMass)
        {
            return (int) (Math.Floor(moduleMass / 3.0) - 2);
        }

        public int ComputeTotalFuel(IEnumerable<int> masses)
        {
            return masses.Sum(ComputeFuel);
        }

        public int ComputeFuelSum(int moduleMass)
        {
            var fuel = ComputeFuel(moduleMass);
            var total = fuel;

            do
            {
                fuel = ComputeFuel(fuel);

                if (fuel > 0)
                {
                    total += fuel;
                }
            } while (fuel > 0);

            return total;
        }

        public int ComputeTotalFuelSum(IEnumerable<int> masses)
        {
            return masses.Sum(ComputeFuelSum);
        }
    }
}