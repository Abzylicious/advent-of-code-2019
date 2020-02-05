using System.Drawing;

namespace AdventOfCode.Day13
{
    public class Tile
    {
        public TileType TileType { get; set; }
        public Point Position { get; }

        public Tile(TileType tileType, Point position)
        {
            TileType = tileType;
            Position = position;
        }
    }
}
