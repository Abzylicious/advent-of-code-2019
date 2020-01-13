using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day12
{
    public class FourMoonMotionSimulator
    {
        private List<Moon> _moons;

        public IEnumerable<List<Moon>> Run(params Moon[] moons)
        {
            _moons = new List<Moon>(moons);
            while (true)
            {
                UpdateGravities();
                UpdatePositions();
                yield return _moons;
            }
        }

        private void UpdateGravities()
        {
            for (int i = 0; i < _moons.Count; i++)
            {
                for (int j = 0; j < _moons.Count; j++)
                {
                    if (i != j)
                    {
                        var appliedGravity = _moons[i].AppliedGravity(_moons[j]);
                        _moons[i].UpdateVelocity(appliedGravity);
                    }
                }
            }
        }

        private void UpdatePositions() => _moons.ForEach(m => m.UpdatePosition());

        public long GetStepsToRepeat(params Moon[] moons)
        {
            var result = new List<long>();
            for (int i = 0; i < 3; i++)
            {
                var states = new HashSet<(float, float, float, float, float, float, float, float)>();
                foreach (var simulatedMoons in Run(moons))
                {
                    var state = i switch
                    {
                        0 => (simulatedMoons[0].Position.X, simulatedMoons[1].Position.X, simulatedMoons[2].Position.X, simulatedMoons[3].Position.X,
                        simulatedMoons[0].Velocity.X, simulatedMoons[1].Velocity.X, simulatedMoons[2].Velocity.X, simulatedMoons[3].Velocity.X),
                        1 => (simulatedMoons[0].Position.Y, simulatedMoons[1].Position.Y, simulatedMoons[2].Position.Y, simulatedMoons[3].Position.Y,
                        simulatedMoons[0].Velocity.Y, simulatedMoons[1].Velocity.Y, simulatedMoons[2].Velocity.Y, simulatedMoons[3].Velocity.Y),
                        2 => (simulatedMoons[0].Position.Z, simulatedMoons[1].Position.Z, simulatedMoons[2].Position.Z, simulatedMoons[3].Position.Z,
                        simulatedMoons[0].Velocity.Z, simulatedMoons[1].Velocity.Z, simulatedMoons[2].Velocity.Z, simulatedMoons[3].Velocity.Z),
                        _ => throw new Exception()
                    };

                    if (states.Contains(state))
                        break;

                    states.Add(state);
                }

                result.Add(states.LongCount());
            }

            return Lcm(Lcm(result[0], result[1]), result[2]);
        }

        private long Lcm(long a, long b) => a * b / Gcd(a, b);
        private long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
    }
}
