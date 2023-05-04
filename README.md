# Quadratic Equation Solver

This program is a console application that solves quadratic equations of the form:

```
ax^2 + bx + c = 0
```

where `a`, `b`, and `c` are real numbers, and `a` is not equal to 0. Quadratic equations can have 0 to 2 real roots. The program supports two modes of operation: Interactive mode and File mode.

## Interactive Mode

In Interactive mode, the program prompts the user to enter the coefficients `a`, `b`, and `c` one at a time. It then displays the equation and its roots (if any). To run the program in Interactive mode, execute the following command without any arguments:

```
./equation
```

**Example usage in Interactive mode:**

```plaintext
$ ./equation
a = 2
b = 1
c = -3
Equation is: (2) x^2 + (1) x + (-3) = 0
There are 2 roots
x1 = -1.5
x2 = 1.0
```

## File Mode

In File mode, the program takes a single argument, which is the path to a file containing the coefficients `a`, `b`, and `c` separated by spaces. The file should have the following format:

```
a b c
```

**Example input file:**

```plaintext
1 0 0
```

To run the program in File mode, execute the following command with the path to the input file as the argument:

```
./equation input.txt
```

**Example usage in File mode:**

```plaintext
$ ./equation test_valid.txt
Equation is: (1) x^2 + (0) x + (0) = 0
There are 1 roots x1 = 0
```

If the input file does not follow the specified format, the program will display an error message and exit with a non-zero exit code.

## Building and Running

To build the program, navigate to the project directory and run:

```plaintext
dotnet build
```

To run the program, navigate to the `bin/Debug/net6.0` directory (or `bin/Debug/net7.0`, depending on your .NET version) and execute the `equation` binary as shown in the Interactive and File mode examples above.

## Testing

The program includes a test suite that covers various scenarios for both Interactive and File modes. To run the tests, navigate to the `QuadraticEquationSolver_Tests` directory and execute:

```plaintext
dotnet test
```

This will run all test cases and display the results.

SOMETHING TO REVERT