Quadratic Equation Solver
This program is a console application that solves quadratic equations of the form:

r
Copy code
ax^2 + bx + c = 0
where a, b, and c are real numbers, and a is not equal to 0. Quadratic equations can have 0 to 2 real roots. The program supports two modes of operation: Interactive mode and File mode.

Interactive Mode
In Interactive mode, the program prompts the user to enter the coefficients a, b, and c one at a time. It then displays the equation and its roots (if any). To run the program in Interactive mode, execute the following command without any arguments:

bash
Copy code
./equation
Example usage in Interactive mode:

makefile
Copy code
$ ./equation
a = 2
b = 1
c = -3
Equation is: (2) x^2 + (1) x + (-3) = 0
There are 2 roots
x1 = -1.5
x2 = 1.0
File Mode
In File mode, the program takes a single argument, which is the path to a file containing the coefficients a, b, and c separated by spaces. The file should have the following format:

css
Copy code
a b c
Example input file:

Copy code
1 0 0
To run the program in File mode, execute the following command with the path to the input file as the argument:

bash
Copy code
./equation input.txt
Example usage in File mode:

shell
Copy code
$ ./equation test_valid.txt
Equation is: (1) x^2 + (0) x + (0) = 0
There are 1 roots x1 = 0
If the input file does not follow the specified format, the program will display an error message and exit with a non-zero exit code.