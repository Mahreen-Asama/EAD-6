using System;

namespace MathOperationsLibrary
{
    public delegate int MathOp(int a, int b);
    public class Class1
    {
        public int add(int x, int y)
        {
            return x + y;
        }
        public int subtract(int x, int y)
        {
            return x - y;
        }
        int multiply(int x, int y)
        {
            return x * y;
        }
        int divide(int x, int y)
        {
            return x / y;
        }
        public MathOp GetFunction(string input)
        {
            MathOp op = null;
            if (input == "1")
            {
                op = this.add;
            }
            else if (input == "2")
            {
                op = this.subtract;
            }
            else if (input == "3")
            {
                op = this.multiply;
            }
            else if (input == "4")
            {
                op = this.divide;
            }
            else
            {
            }
            return op;
        }
    }
}
