using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day06
{
    public class OrbitMap
    {
        private readonly IDictionary<string, Orbit> _orbitMap;

        public OrbitMap()
        {
            _orbitMap = new Dictionary<string, Orbit>();
        }

        public OrbitMap(IEnumerable<string> orbitRelationships)
        {
            _orbitMap = new Dictionary<string, Orbit>();
            CreateMap(orbitRelationships);
        }

        public void CreateMap(IEnumerable<string> orbitRelationships)
        {
            foreach (var orbitRelationship in orbitRelationships)
            {
                var orbitRelation = orbitRelationship.Split(')');
                var parent = AddOrbit(orbitRelation[0]);
                var child = AddOrbit(orbitRelation[1]);
                AddChildToParent(parent, child);
                AddParentToChild(child, parent);
            }
        }

        private Orbit GetOrbit(string orbitName) => _orbitMap
            .FirstOrDefault(o => o.Key.Equals(orbitName, StringComparison.OrdinalIgnoreCase)).Value;

        public int OrbitCount() => OrbitCount(GetOrbit("com"), 0);

        private int OrbitCount(Orbit startOrbit, int pathCount)
        {
            var orbitCount = 0;
            if (startOrbit == null)
            {
                return orbitCount;
            }

            foreach (var child in startOrbit.ChildOrbits)
            {
                orbitCount += OrbitCount(child, pathCount + 1);
            }

            return orbitCount + pathCount;
        }

        public int GetOrbitalTransfers(string startOrbitName, string destinationOrbitName) =>
            GetOrbitalTransfers(GetOrbit(startOrbitName), GetOrbit(destinationOrbitName));

        private int GetOrbitalTransfers(Orbit startOrbit, Orbit destinationOrbit)
        {
            var parentsStartOrbit = GetAllParents(startOrbit);
            var parentsDestinationOrbit = GetAllParents(destinationOrbit);
            var commonParent = parentsStartOrbit.FirstOrDefault(o => parentsDestinationOrbit.Contains(o));
            return CountTransferstoParent(commonParent, startOrbit) + CountTransferstoParent(commonParent, destinationOrbit);
        }

        private int CountTransferstoParent(Orbit parent, Orbit child)
        {
            var transferCount = 0;
            var currentParent = child.ParentOrbit;

            while (currentParent != null && currentParent.Name != parent.Name)
            {
                transferCount++;
                currentParent = currentParent.ParentOrbit;
            }

            return transferCount;
        }

        private IEnumerable<Orbit> GetAllParents(Orbit orbit)
        {
            var parents = new List<Orbit>();
            var currentParent = orbit;

            while (currentParent.ParentOrbit != null)
            {
                parents.Add(currentParent.ParentOrbit);
                currentParent = currentParent.ParentOrbit;
            }

            return parents;
        }

        private Orbit AddOrbit(string orbitName)
        {
            if (!_orbitMap.TryGetValue(orbitName, out var orbit))
            {
                orbit = new Orbit() { Name = orbitName };
                _orbitMap.Add(orbit.Name, orbit);
            }
            return orbit;
        }

        private void AddChildToParent(Orbit parent, Orbit potentialChild)
        {
            if (parent.ChildOrbits.All(co => co.Name != potentialChild.Name))
            {
                parent.ChildOrbits.Add(potentialChild);
            }
        }

        private void AddParentToChild(Orbit child, Orbit potentialParent)
        {
            if (child.ParentOrbit == null)
            {
                child.ParentOrbit = potentialParent;
            }
        }
    }
}
