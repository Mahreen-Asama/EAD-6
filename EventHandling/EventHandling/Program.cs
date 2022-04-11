using System;

namespace EventHandling
{
    delegate void MyEventHandler();     //delegates used to handle events

    //publisher class
    class Button
    {
        public event MyEventHandler click;      //event defined

        public void OnClick()
        {
            if (click != null)
            {
                click();                //event fired
            }
        }
    }

    //separate handler class
    class MyHandlerClass
    {
        public void HandlerFunction()
        {
            Console.WriteLine("Handler function");
        }
    }

    //listener/subscriber class
    class Program
    {
        static void Main(string[] args)
        {
            Button b1 = new Button();
            b1.click += delegate ()             //event registered
            {
                Console.WriteLine("Hello");     //event handled
            };

            MyHandlerClass c1 = new MyHandlerClass();
            b1.click += c1.HandlerFunction;     //another handler added

            b1.click += () => Console.WriteLine("3rd handler"); //3rd handler added

            b1.OnClick();                       //clicked button
        }
    }
}
