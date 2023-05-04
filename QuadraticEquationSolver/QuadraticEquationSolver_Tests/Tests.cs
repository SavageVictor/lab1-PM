using NUnit.Framework;
using System.IO;
using System;

namespace QuadraticEquationSolver.Tests
{
    public class QuadraticEquationTests
    {
        [TestCase("1 0 -1\n", "Equation is: (1) x^2 + (0) x + (-1) = 0\r\nThere are 2 roots\r\nx1 = 1\r\nx2 = -1\r\n")]
        [TestCase("1 0 0\n", "Equation is: (1) x^2 + (0) x + (0) = 0\r\nThere are 1 roots\r\nx1 = 0\r\n")]
        [TestCase("1 -2 1\n", "Equation is: (1) x^2 + (-2) x + (1) = 0\r\nThere are 1 roots\r\nx1 = 1\r\n")]
        [TestCase("1 0 1\n", "Equation is: (1) x^2 + (0) x + (1) = 0\r\nThere are 0 roots\r\n")]
        public void TestFileMode(string input, string expectedOutput)
        {
            string inputFilePath = Path.GetTempFileName();
            File.WriteAllText(inputFilePath, input);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                QuadraticEquationSolver.Program.Main(new string[] { inputFilePath });

                string result = sw.ToString();
                result = result.Replace("-0", "0"); // Handle the negative zero issue
                Assert.AreEqual(expectedOutput, result);
            }

            File.Delete(inputFilePath);
        }

        [TestCase("1\n0\n-1\n", "a = b = c = Equation is: (1) x^2 + (0) x + (-1) = 0\r\nThere are 2 roots\r\nx1 = 1\r\nx2 = -1\r\n")]
        [TestCase("1\n0\n0\n", "a = b = c = Equation is: (1) x^2 + (0) x + (0) = 0\r\nThere are 1 roots\r\nx1 = 0\r\n")]
        [TestCase("1\n-2\n1\n", "a = b = c = Equation is: (1) x^2 + (-2) x + (1) = 0\r\nThere are 1 roots\r\nx1 = 1\r\n")]
        [TestCase("1\n0\n1\n", "a = b = c = Equation is: (1) x^2 + (0) x + (1) = 0\r\nThere are 0 roots\r\n")]
        public void TestInteractiveMode(string userInput, string expectedOutput)
        {
            using (StringReader sr = new StringReader(userInput))
            {
                Console.SetIn(sr);

                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    QuadraticEquationSolver.Program.Main(Array.Empty<string>());

                    string result = sw.ToString();
                    result = result.Replace("-0", "0"); // Handle the negative zero issue
                    Assert.AreEqual(expectedOutput, result);
                }
            }
        }
    }
}