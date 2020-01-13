using System;
using System.Numerics;

namespace AdventOfCode.Day12
{
    public class Moon
    {
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; } = new Vector3(0);

        public Moon(Vector3 position)
        {
            Position = position;
        }

        public void UpdateVelocity(Vector3 gravity) => Velocity = Vector3.Add(Velocity, gravity);
        public void UpdatePosition() => Position = Vector3.Add(Position, Velocity);
        public int PotentialEnergy() => (int)(Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z));
        public int KineticEnergy() => (int)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z));
        public int TotalEnergy() => PotentialEnergy() * KineticEnergy();
    }
}
