using System.Drawing;

namespace AdventOfCode.Day11
{
    public class PanelHistoryEntry
    {
        public Point Position { get; }
        public int Color { get; set; }

        public PanelHistoryEntry(Point position, int color)
        {
            Position = position;
            Color = color;
        }
    }
}
