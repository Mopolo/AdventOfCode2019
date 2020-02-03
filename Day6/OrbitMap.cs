using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class OrbitMap
    {
        public SpaceObject Com { get; }
        public Dictionary<string, SpaceObject> Objects;

        public OrbitMap(string input)
        {
            var lines = input.Split("\n");
            Objects = new Dictionary<string, SpaceObject>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                
                var parts = line.Split(")");

                var leftId = parts[0];
                var rightId = parts[1];

                if (!Objects.ContainsKey(leftId))
                {
                    Objects[leftId] = new SpaceObject(leftId);
                }
                
                if (!Objects.ContainsKey(rightId))
                {
                    Objects[rightId] = new SpaceObject(rightId);
                }
                
                var leftObject = Objects[leftId];
                var rightObject = Objects[rightId];
                
                rightObject.SetParent(leftObject);

                if (i == 0)
                {
                    Com = leftObject;
                }
            }
        }

        public int TotalOrbits()
        {
            return Objects.Sum(o => o.Value.IndirectOrbits());
        }

        public int MinimumOrbitalTransfers(string a, String b)
        {
            var transfers = 0;

            var objectA = Objects[a].Parent;
            var objectB = Objects[b].Parent;
            
            var rootLineA = objectA.RootLine();
            var rootLineB = objectB.RootLine();
            
            foreach (var element in rootLineA)
            {
                transfers++;

                if (rootLineB.ContainsKey(element.Key))
                {
                    break;
                }
            }

            foreach (var element in rootLineB)
            {
                transfers++;

                if (rootLineA.ContainsKey(element.Key))
                {
                    break;
                }
            }

            return transfers;
        }
    }
}