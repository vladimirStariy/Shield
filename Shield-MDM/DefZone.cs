using System.Collections.Generic;
using System.Drawing;

namespace Shield_MDM
{
    public class DefZone
    {
        public PointF startPoint { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public List<MapGridCell> DefCells { get; set; } 
    }
}
