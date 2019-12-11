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

        public ScanStation(string[] asteroidMapData) : this()
        {
            CreateMap(asteroidMapData);
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

        public (Point position, int detectedAsteroids) GetBestScanStationPosition()
        {
            var result = GetAsteroidDetectedMap().OrderByDescending(x => x.Value).FirstOrDefault();
            return (result.Key, result.Value);
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

        private int GetAsteroidsDetected(Point currentPosition)
        {
            var angles = new List<double>();
            foreach (var position in _asteroidMap)
            {
                if (position.Key != currentPosition && position.Value == '#')
                {
                    angles.Add(CalculateAngle(currentPosition, position.Key));
                }
            }

            return angles.GroupBy(a => a).Count();
        }

        private double CalculateAngle(Point a, Point b)
        {
            var deltaX = b.X - a.X;
            var deltaY = b.Y - a.Y;
            return Math.Atan2(deltaY, deltaX) * 180 / Math.PI;
        }
    }
}
