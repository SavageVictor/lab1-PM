using System;
using System.IO;

namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                InteractiveMode();
            }
            else
            {
                FileMode(args[0]);
            }
        }

        static void InteractiveMode()
        {
            double a = ReadValidDouble("a");
            double b = ReadValidDouble("b");
            double c = ReadValidDouble("c");

            Console.WriteLine($"Equation is: ({a}) x^2 + ({b}) x + ({c}) = 0");
            SolveAndPrint(a, b, c);
        }

        static void FileMode(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 3)
            {
                Console.WriteLine("Invalid file format. Expected at least 3 lines.");
                return;
            }

            if (!double.TryParse(lines[0], out double a) || !double.TryParse(lines[1], out double b) || !double.TryParse(lines[2], out double c))
            {
                Console.WriteLine("Invalid file format. Expected valid real numbers.");
                return;
            }

            Console.WriteLine($"Equation is: ({a}) x^2 + ({b}) x + ({c}) = 0");
            SolveAndPrint(a, b, c);
        }

        static double ReadValidDouble(string variableName)
        {
            double value;
            Console.Write($"{variableName} = ");
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine($"Error. Expected a valid real number, got {variableName} instead");
                Console.Write($"{variableName} = ");
            }
            return value;
        }

        static void SolveAndPrint(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("There are 2 roots");
                Console.WriteLine($"x1 = {x1}");
                Console.WriteLine($"x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                double x1 = -b / (2 * a);
                Console.WriteLine("There are 1 roots");
                Console.WriteLine($"x1 = {x1}");
            }
            else
            {
                Console.WriteLine("There are 0 roots");
            }
        }
    }
}