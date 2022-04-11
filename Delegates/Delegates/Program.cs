using System;
using MathOperationsLibrary;

namespace Delegates
{
    delegate int MathOp(int x, int y);
    class Program
    {
        /*static int PerformOperation(MathOp op,int x, int y)
        {
            return op(x, y);
        }*/
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Console.Write("Enter input: ");
            string input = Console.ReadLine();
            var func = c1.GetFunction(input);   //func sent as parameter abovee
            Console.WriteLine(func(2, 3));

            //Console.WriteLine(PerformOperation(c1.add,2, 3));
            //Console.WriteLine(PerformOperation(c1.subtract, 2, 3));
        }
    }
}
