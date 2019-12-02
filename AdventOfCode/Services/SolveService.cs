using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public class SolveService
    {
        private readonly List<ISolver> _solvers;

        public SolveService()
        {
            _solvers = new List<ISolver>();
            LoadSolutions();
        }

        public void GetSolution(int day)
        {
            var solver = _solvers.Find(s => s.Day == day);
            if (solver == null)
            {
                Console.WriteLine("There's no solution for this day yet.");
                return;
            }

            ExecuteSolver(solver);
        }

        private void ExecuteSolver(ISolver solver)
        {
            Console.WriteLine($"\n{solver.Title}");
            solver.Precondition();
            Console.WriteLine($"Solution for Part One: {solver.GetFirstSolution()}");
            Console.WriteLine($"Solution for Part Two: {solver.GetSecondSolution()}");
        }

        private void LoadSolutions()
        {
            var solverTypes = FetchSolvers();
            foreach (var solver in solverTypes)
            {
                _solvers.Add(Activator.CreateInstance(solver) as ISolver);
            }
        }

        private IEnumerable<Type> FetchSolvers()
        {
            var interfaceType = typeof(ISolver);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface);
        }
    }
}
