using System;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var computer = new MassComputer();

            var input = System.IO.File.ReadAllText(@"C:\Users\nboiron\RiderProjects\Day3\Day1\input.txt");

            var modulesMasses = input.Split("\n").Select(int.Parse);

            var total = computer.ComputeTotalFuel(modulesMasses);
            var totalFuel = computer.ComputeTotalFuelSum(modulesMasses);

            Console.WriteLine("Total : {0}", total);
            Console.WriteLine("Total Fuel : {0}", totalFuel);
        }
    }
}