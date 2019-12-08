using System.Collections.Generic;

namespace AdventOfCode.Day08
{
    public class SpaceImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<SpaceImageLayer> Layers { get; set; } = new List<SpaceImageLayer>();
    }
}
