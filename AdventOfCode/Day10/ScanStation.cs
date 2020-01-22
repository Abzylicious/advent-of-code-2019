using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class ScanStation
    {
        private readonly IDictionary<Point, char> _asteroidMap;

        public ScanStation()
        {
            _asteroidMap = new Dictionary<Point, char>();
        }

        public void CreateMap(string[] asteroidMapData)
        {
            _asteroidMap.Clear();
            var xAxisLength = asteroidMapData[0].Length;
            var yAxisLength = asteroidMapData.Length;

            for (int y = 0; y < yAxisLength; y++)
            {
                for (int x = 0; x < xAxisLength; x++)
                {
                    var nextPoint = new Point(x, y);
                    var value = Convert.ToChar(asteroidMapData[y].Substring(x, 1));
                    _asteroidMap.Add(nextPoint, value);
                }
            }
        }

        public IEnumerable<Point> GetAsteroidDestructionOrder(Point currentPosition)
        {
            var result = new List<Point>();
            var asteroidData = GetAllDetectedAsteroidAnglesWithDistance(currentPosition).ToList();
            while (asteroidData.Count != 0)
            {
                var destroyedAsteroidsPerRotation = asteroidData
                    .OrderBy(x => (x.angle, x.distance))
                    .GroupBy(x => x.angle)
                    .Select(x => x.First());

                result.AddRange(destroyedAsteroidsPerRotation.Select(x => x.position));
                asteroidData.RemoveAll(x => result.Contains(x.position));
            }

            return result;
        }

        public (Point position, int detectedAsteroids) GetBestScanStationPosition()
        {
            var (position, asteroids) = GetAsteroidDetectedMap().OrderByDescending(x => x.Value).FirstOrDefault();
            return (position, asteroids);
        }

        private IDictionary<Point, int> GetAsteroidDetectedMap()
        {
            var result = new Dictionary<Point, int>();
            foreach (var position in _asteroidMap.Where(x => x.Value == '#'))
            {
                result.Add(position.Key, GetAsteroidsDetected(position.Key));
            }

            return result;
        }

        private int GetAsteroidsDetected(Point currentPosition) => GetAllAsteroidAngles(currentPosition).GroupBy(a => a).Count();

        private IEnumerable<double> GetAllAsteroidAngles(Point currentPosition)
        {
            var angles = new List<double>();
            foreach (var position in _asteroidMap)
            {
                if (position.Key != currentPosition && position.Value == '#')
                {
                    angles.Add(CalculateAngle(currentPosition, position.Key));
                }
            }

            return angles;
        }

        private IEnumerable<(Point position, double angle, double distance)> GetAllDetectedAsteroidAnglesWithDistance(Point currentPosition)
        {
            var result = new List<(Point position, double angle, double distance)>();
            foreach (var position in _asteroidMap)
            {
                if (position.Key != currentPosition && position.Value == '#')
                {
                    result.Add((position.Key, CalculateOrientatedAngle(currentPosition, position.Key), CalculateDistance(currentPosition, position.Key)));
                }
            }

            return result;
        }

        private double CalculateAngle(Point a, Point b)
        {
            var deltaX = b.X - a.X;
            var deltaY = b.Y - a.Y;
            return Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
        }

        private double CalculateOrientatedAngle(Point a, Point b)
        {
            var orientatedAngle = CalculateAngle(a, b) + 90;
            return orientatedAngle < 0 ? orientatedAngle + 360 : orientatedAngle;
        }

        private double CalculateDistance(Point a, Point b) => Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
    }
}
