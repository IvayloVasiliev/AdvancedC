using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action<string> print = Console.WriteLine;

            Action<string> print = item => Console.WriteLine(item);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);

            //Action<string[]> print = items => Console.WriteLine(string.Join(Environment.NewLine, items));

            //string[] names = Console.ReadLine().Split().ToArray();

            //print(names);
                       
        }
    }
}
