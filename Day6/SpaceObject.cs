using System;
using System.Diagnostics;

namespace Day6
{
    public class SpaceObject
    {
        public string Id { get; }
        public SpaceObject Parent { get; private set; }

        public int DirectOrbits => Parent == null ? 0 : 1;

        public SpaceObject(string id)
        {
            Id = id;
        }

        public void SetParent(SpaceObject parent)
        {
            Parent = parent;
        }

        public int IndirectOrbits()
        {
            if (Parent == null)
            {
                return 0;
            }

            return 1 + Parent.IndirectOrbits();
        }

        public SpaceObject FirstCommonParent(SpaceObject other)
        {
            var parentA = Parent;
            var parentB = other.Parent;
            
            do
            {
                do
                {
                    Console.WriteLine($"A({parentA.Id}) B({parentB?.Id})");
                    if (parentA == parentB)
                    {
                        return parentA;
                    }

                    parentB = parentB?.Parent;
                } while (parentB != null);
                parentA = parentA.Parent;
            } while (parentA != null);
            
            return null;
        }

        public bool HasParent(SpaceObject parent)
        {
            if (Parent == null)
            {
                return false;
            }

            if (Parent == parent)
            {
                return true;
            }

            return Parent.HasParent(parent);
        }
    }
}