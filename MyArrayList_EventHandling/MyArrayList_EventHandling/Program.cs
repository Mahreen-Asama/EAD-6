using System;
using System.Collections;

namespace MyArrayList_EventHandling
{
    delegate void AddEventHandler();     //delegates used to handle events
    delegate void AddEventHandler2(object sender, EventArgs e);
    delegate void AddEventHandler3(object sender, MyArgs e);

    //arguments child class
    class MyArgs : EventArgs
    {
        public int Count { get; set; }      //to maintain count of list items
        public object Value { get; set; }   //current value added to list
    }

    //pubisher class
    class MyArrayList : ArrayList
    {
        public event AddEventHandler Added;     //event defined
        public event AddEventHandler2 Added2;     //event defined
        public event AddEventHandler3 Added3;     //event defined
        int c = 0;      //local count of list

        public void OnAdded()
        {
            if (Added != null)
            {
                Added();            //event fired
            }
        }
        public void OnAdded2()
        {
            Added2(this, new EventArgs());  //event fired
        }
        public void OnAdded3(object val)
        {
            MyArgs arg = new MyArgs();
            arg.Count = c++;
            arg.Value = val;

            Added3(this, arg);     //event fired
        }
        public override int Add(object value)
        {
            OnAdded3(value);
            OnAdded2();
            OnAdded();
            return base.Add(value);
        }

    }

    //listener/subscriber class
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayList list = new MyArrayList();

            list.Added += () => Console.WriteLine("hello"); //events registered + handled
            list.Added2 += (sender, e) => Console.WriteLine(sender);
            list.Added3 += (sender, e) => Console.WriteLine(e.Count+" "+e.Value);

            list.Add(12);
            list.Add("str");        //events raised
            list.Add(34);
        }
    }
}
