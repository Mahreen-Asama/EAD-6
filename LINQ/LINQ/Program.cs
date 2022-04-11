using System;
using System.Linq;

namespace LINQ
{
    class Student
    {
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public int Marks { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //'method syntax' to make LINQ query---------------

            //1-define data source
            string[] cities = new string[] { "Lahore", "Karachi", "abad", "Islam" };

            //2-define query
            var query = cities.Where(NameLongerThanFour);
            var query2 = cities.Where(NameLongerThanFour).ToList(); //query+execution

            //----using lambda experssion
            var q = cities.Where(name => name.Length > 4).Select(x => x).OrderBy(x => x);
            var qu = cities.OrderBy(name => name);

            //----using lambda statement
            var q2 = cities.Where(name =>
            {
                int p = 0;
                if (name.Length > 4)
                    p++;
                if (p > 10) return true;
                else return false;
            });
            //----using anonymous method
            var q3 = cities.Where(delegate (string n) { return n.Length > 4; });

            //3- execute query
            foreach (var v in query)
                Console.WriteLine(v);
            foreach (var v in query2)
                Console.WriteLine(v);
            foreach (var v in qu)
                Console.WriteLine(v);


            //'query syntax' to make LINQ query-------------------------

            var qq = (from n in cities
                     where n.Length > 4
                     orderby n descending
                     select n).ToList();
            Console.WriteLine("\nquery syntax----");
            foreach (var v in qq)
                Console.WriteLine(v);


            //----------------------------student class------------
            Student[] sarry = new Student[]
            {
                new Student{Name="ali",RollNumber="12",Marks=20,Age=12 },
                new Student{Name="saad",RollNumber="11",Marks=50,Age=18 },
                new Student{Name="arham",RollNumber="19",Marks=30,Age=17 },
            };
            var queryy = sarry.Where(st => st.Age >= 15)
                .OrderBy(stu => stu.Age)
                .Select(s => new { s.Name, s.RollNumber });
            var queryyy = from s in sarry
                          where s.Age >= 15
                          orderby s.Age descending
                          select new { s.Name, s.RollNumber ,s.Age};
            Console.WriteLine("\nmethod----");
            foreach (var v in queryy)
                Console.WriteLine(v);
            Console.WriteLine("\nquery----");
            foreach (var v in queryyy)
                Console.WriteLine(v);
        }
        static bool NameLongerThanFour(string cityName)
        {
            return cityName.Length > 4;
        }

        Func<string, bool> f1 = delegate (string name)
        {
            return name.Length > 4;
        };

       
        
    }
}
