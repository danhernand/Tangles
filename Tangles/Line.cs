using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangles
{
    public class Line
    {
        public Point startPoint;
        public Point endPoint;

        public Line(Point sP, Point eP)
        {
            startPoint = sP;
            endPoint = eP;
        }
        public bool Contains(Line side)
        {
            bool result = false;
            if (AllEqual(startPoint.x, endPoint.x, side.startPoint.x, side.endPoint.x))
            {
                if ((startPoint.y <= side.startPoint.y && side.startPoint.y <= endPoint.y)
                    && startPoint.y <= side.endPoint.y && side.endPoint.y <= endPoint.y)
                {
                    result = true;
                }
            }
            else if (AllEqual(startPoint.y, endPoint.y, side.startPoint.y, side.endPoint.y))
            {
                if ((startPoint.x <= side.startPoint.x && side.startPoint.x <= endPoint.x)
                    && startPoint.x <= side.endPoint.x && side.endPoint.x <= endPoint.x)
                {
                    result = true;
                }
            }
            return result;
        }
        private bool AllEqual(params double[] axisPoints)
        {
           return (axisPoints.Sum() / axisPoints.Length == axisPoints[0]) ? true : false;
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}) => ({2}, {3})", startPoint.x, startPoint.y, endPoint.x, endPoint.y);
        }
    }
}
