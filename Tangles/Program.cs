using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangles
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                uint input;
                Console.WriteLine("Welcome to Tangles!  Put in the length, width and the coordinates of the origin-oriented corner for two rectangles and know if they intersect, contain or are adjacent to one another.");
                Console.WriteLine("\nNow Let's build our first rectangle!");
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
                //Rectangle A
                Rectangle a = new Rectangle();
                Console.WriteLine("Enter length for rectangle A:");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter length for rectangle A:");
                }
                a.Length = (double)input;
                Console.WriteLine("Enter width for rectangle A");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter width for rectangle A:");
                }
                a.Width = (double)input;
                Console.WriteLine("Enter x-coordinate for rectangle A");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter x-coordinate for rectangle A:");
                }
                a.X = (int)input;
                Console.WriteLine("Enter y-coordinate for rectangle A");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter y-coordinate for rectangle A:");
                }
                a.Y = (int)input;
                a.Initialize();
                Console.WriteLine("\nRectangle A built!");
                Console.WriteLine("Press any key to continue and build Rectangle B\n");
                Console.ReadKey();

                //Rectangle B
                Rectangle b = new Rectangle();
                Console.WriteLine("Enter length for rectangle B:");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter length for rectangle B:");
                }
                b.Length = (double)input;
                Console.WriteLine("Enter width for rectangle B");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter width for rectangle B:");
                }
                b.Width = (double)input;
                Console.WriteLine("Enter x-coordinate for rectangle B");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter x-coordinate for rectangle B:");
                }
                b.X = (int)input;
                Console.WriteLine("Enter y-coordinate for rectangle B");
                while (!uint.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please Enter a valid positive numerical value!");
                    Console.WriteLine("Please Enter y-coordinate for rectangle B:");
                }
                b.Y = (int)input;
                b.Initialize();
                Console.WriteLine("Rectangle B built!");
                Console.WriteLine("Press any key to get results.\n");
                Console.ReadKey();

                Console.WriteLine("Results:");
                Console.WriteLine("Rectangle A contains Rectangle B: {0}", a.Contains(b));
                Console.WriteLine("Rectangle B contains Rectangle A: {0}", b.Contains(a));
                Console.WriteLine("Rectangles intersect: {0}", a.Intersects(b));
                if (a.Intersects(b))
                {
                    var intersectingPoints = a.IntersectsAt(b);
                    var output = new StringBuilder("Rectangles intersect at: \n");
                    intersectingPoints.ForEach(p => output.Append(p.ToString() + "\n"));
                    Console.WriteLine(output);
                }
                Console.WriteLine("Rectangles are adjacent: {0}", a.IsAdjacentTo(b));
                if (a.IsAdjacentTo(b))
                {
                    var intersectingPoints = a.IsAdjacentAt(b);
                    var output = new StringBuilder("Rectangles are adjacent between: \n");
                    intersectingPoints.ForEach(p => output.Append(p.ToString() + "\n"));
                    Console.WriteLine(output);
                }
                Console.WriteLine("\nPress any key to try again or hit Ctrl + C to quit");
                Console.ReadKey();
            }
            
        }
    }
}
