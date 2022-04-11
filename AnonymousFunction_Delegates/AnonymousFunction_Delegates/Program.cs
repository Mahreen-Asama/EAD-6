using System;

namespace AnonymousFunctions_Delegates
{
    delegate void MyDel();
    delegate void MyDel2(int a);
    delegate int MyDel3(int a);
    class Program
    {
        static void Main(string[] args)
        {
            //----------anonymous functions--------------
            Console.WriteLine("Hello World!");
            MyDel d1 = delegate ()
            {
                Console.WriteLine("d1");
            };
            MyDel2 d2 = delegate (int a)
            {
                Console.WriteLine("first ime " + a);
            };
            d2 += delegate (int aa)  //refer to new one
            {
                Console.WriteLine("end timw " + aa);
            };
            MyDel3 d3 = delegate (int a)
            {
                return a;
            };
            d3 += delegate (int w)
            {
                return 100;       //pointed to new one
            };
            d1();
            d2(55);
            Console.WriteLine(d3(5));

            //----------lambda statements-------------
            Console.WriteLine("\nHello world!");
            d1 += () =>
            {
                Console.WriteLine("ls d1");
            };
            d2 = (a) => //lambda statement can be written without parameters 'datatype'
            {
                Console.WriteLine("first ime " + a);
            };
            d3 = (int a) =>
            {
                return a;
            };
            d1();
            d2(55);
            Console.WriteLine(d3(5));

            //----------lambda expressions-------------
            Console.WriteLine("\nHello world!");
            d1 += () => Console.WriteLine("le d1");

            d2 = (int a) => Console.WriteLine(a);

            d3 = (a) => a;  //lambda expression can also be written without parameters 'datatype'

            d1();
            d2(555);
            Console.WriteLine(d3(50));

            //----------Action,Func Built-in delegates-------------
            Console.WriteLine("\nHello world!");
            Action a1;
            a1 = () => Console.WriteLine("a1");
            a1 += () => Console.WriteLine("a1 a1");
            Action<int> a2 = (int a) => Console.WriteLine(a);
            Action<int, string> a22 = (int a, string s) => Console.WriteLine(a + s);
            Func<int> f1 = () => 67;
            Func<string, int, string> f2 = (string s, int a) => a + s;
            Func<string, int, string> f3 = (string s, int a) => a + s;
            a1();
            a2(34);
            a22(70, "helo");
            Console.WriteLine(f1());
            Console.WriteLine(f2("f2", 66));

            //---------function-within-function-----------
            MyDel3 d33 = delegate (int a)
            {
                MyDel3 d4 = delegate (int j)
                {
                    return a + j;
                };
                return d4(55);
            };
            Console.WriteLine(d33(5));

        }
    }
}
