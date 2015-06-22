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

        /*
         * Checking if either all x or y points are the same. 
         * Then check to make sure that the opposite of what was the same is contained withing the line
         */
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
            return (axisPoints[0] == axisPoints[1] && axisPoints[1] == axisPoints[2] && axisPoints[2] == axisPoints[3]);
        }
        public bool Intersects(Line line){
            bool result = false;
            var horizonalA = startPoint.x == endPoint.x ? startPoint.x : startPoint.y;
            string AxisA = startPoint.x == endPoint.x ? "x" : "y";
            var horizonalB = line.startPoint.x == line.endPoint.x ? line.startPoint.x : line.startPoint.y;
            string AxisB = line.startPoint.x == line.endPoint.x ? "x" : "y";
            if (AxisA != AxisB)
            {
                if (AxisA == "x")
                {
                    if ((line.startPoint.x < this.startPoint.x && line.endPoint.x > this.startPoint.x) &&
                        (startPoint.y < line.startPoint.y && line.startPoint.y < endPoint.y))
                    {
                        result = true; 
                    }
                }
                else
                {
                    if ((line.startPoint.y < this.startPoint.y && line.endPoint.y > this.startPoint.y) &&
                        (startPoint.x < line.startPoint.x && line.startPoint.x < endPoint.x))
                    {
                        result = true;
                    }
                }
            }
            return result; 
            
            
        }
        public override string ToString()
        {
            return string.Format("({0}, {1}) => ({2}, {3})", startPoint.x, startPoint.y, endPoint.x, endPoint.y);
        }

        public Point IntersectionPoint(Line lineB)
        {
            if (this.startPoint.x == this.endPoint.x)
            {
                return new Point(this.startPoint.x, lineB.startPoint.y);
            }
            else
            {
                return new Point(lineB.startPoint.x, this.startPoint.y);
            }
        }
    }
}
