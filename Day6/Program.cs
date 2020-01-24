using System;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText(@"C:\Users\nboiron\RiderProjects\ConsoleApp1\Day6\input.txt");

            var map = new OrbitMap(input);

            var a = map.Objects["YOU"];
            var b = map.Objects["SAN"];
            
            Console.WriteLine(a.FirstCommonParent(b));
            Console.WriteLine(b.FirstCommonParent(a));

            // Console.WriteLine(map.TotalOrbits());
        }
    }
}