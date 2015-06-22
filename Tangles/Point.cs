using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tangles
{
    public struct Point
    {
        public double x, y;

        public Point(double p1, double p2)
        {
            x = p1;
            y = p2;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", (int)x, (int)y);
        }
    }
}
