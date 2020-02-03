using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourcePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\input.txt"));
            var input = File.ReadAllText(sourcePath);

            var map = new OrbitMap(input);

            var a = map.Objects["YOU"];
            var b = map.Objects["SAN"];
            
            Console.WriteLine(map.MinimumOrbitalTransfers("YOU", "SAN"));
        }
    }
}