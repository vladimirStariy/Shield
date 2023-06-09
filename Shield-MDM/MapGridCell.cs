using System.Drawing;

namespace Shield_MDM
{
    public class MapGridCell
    {
        public MapGridCell(int X, int Y)
        {
            Coordinates.X = X;
            Coordinates.Y = Y;
        }
        public PointF Coordinates;
        public bool isEmpty;
        public bool isBs;
        public bool isGs;
        public DefZone defZone;
    }
}
