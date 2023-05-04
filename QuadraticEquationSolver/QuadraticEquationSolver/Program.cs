using System;
using System.IO;

namespace QuadraticEquationSolver
{
    public class Program
    {
        public static void Main(string[] args)
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
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"file {filePath} does not exist");
                Environment.Exit(1);
            }

            string content = File.ReadAllText(filePath).Trim();
            string[] coefficients = content.Split(' ');

            double a = 0, b = 0, c = 0; // Initialize to default values

            if (coefficients.Length != 3)
            {
                Console.WriteLine("invalid file format");
                Environment.Exit(1);
            }

            if (!double.TryParse(coefficients[0], out a) || !double.TryParse(coefficients[1], out b) || !double.TryParse(coefficients[2], out c))
            {
                Console.WriteLine("invalid file format");
                Environment.Exit(1);
            }

            if (a == 0)
            {
                Console.WriteLine("Error. a cannot be 0");
                Environment.Exit(1);
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