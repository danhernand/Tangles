using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tangles
{
    class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Point OriginCorner { get; set; }
        public Point Center { get; set; }
        public Point OppositeCorner { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Line> Sides { get; set; }

        public Rectangle()
        {

        }
        public Rectangle(double length, double width, int x, int y)
        {
            this.Length = length;
            this.Width = width;
            X = x;
            Y = y;
            Initialize();
        }
        public void Initialize()
        {
            OriginCorner = new Point(X, Y);
            Center = new Point(X + Length / 2, Y + Width / 2);
            OppositeCorner = new Point(X + Length, Y + Width);
            Sides = new List<Line>{
                new Line(new Point(X, Y), new Point(X, Y + Width))
               ,new Line(new Point(X + Length, Y), new Point(X + Length, Y + Width))
               ,new Line(new Point(X, Y), new Point(X + Length, Y))
               ,new Line(new Point(X, Y + Width), new Point(X + Length, Y + Width))};
        }
        public bool IsAdjacentTo(Rectangle rec)
        {
            bool result = false;
            foreach (Line sideA in this.Sides)
            {
                foreach (Line sideB in rec.Sides)
                {
                    if (sideA.Contains(sideB) || sideB.Contains(sideA))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public bool Intersects(Rectangle rec)
        {
            if (Contains(rec)) { return false; }
            double xDiff = Math.Abs(this.Center.x - rec.Center.x);
            bool xOverlapping = xDiff < (Length / 2 + rec.Length / 2);

            double yDiff = Math.Abs(this.Center.y - rec.Center.y);
            bool yOverlapping = yDiff < (Width / 2 + rec.Width / 2);

            return xOverlapping && yOverlapping;
        }
        public bool Contains(Rectangle rec)
        {
            return ContainsPoint(rec.OriginCorner) && ContainsPoint(rec.OppositeCorner);
        }
        private bool ContainsPoint(Point point)
        {
            bool xIn = (this.OriginCorner.x <= point.x) && (point.x <= this.OppositeCorner.x);
            bool yIn = (this.OriginCorner.y <= point.y) && (point.y <= this.OppositeCorner.y);
            return xIn && yIn;
        }
        public List<Line> IsAdjacentAt(Rectangle rec)
        {
            List<Line> result = new List<Line>();
            foreach (Line sideA in this.Sides)
            {
                foreach (Line sideB in rec.Sides)
                {
                    if (sideA.Contains(sideB))
                    {
                        result.Add(sideB);
                    }
                    else if (sideB.Contains(sideA))
                    {
                        result.Add(sideA);
                    }
                }
            }
            return result;
        }
        public List<Point> IntersectsAt(Rectangle rec)
        {
            List<Point> result = new List<Point>();
            foreach (Line lineA in Sides)
            {
                foreach (Line lineB in rec.Sides)
                {
                    if (lineA.Intersects(lineB))
                    {
                        result.Add(lineA.IntersectionPoint(lineB));
                    }
                }
            }
            return result;
        }
    }
}
