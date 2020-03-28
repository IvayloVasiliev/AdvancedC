using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenNum = num => num % 2 == 0;
             
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            int[] input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            List<int> numbers = new List<int>();

            int startNum = input[0];
            int endNum = input[1];

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            string numType = Console.ReadLine();

            if (numType == "even")
            {
                numbers.RemoveAll(x => !isEvenNum(x));
            }
            else
            {
                numbers.RemoveAll(x => isEvenNum(x));
            }

            print(numbers);
        }
    }
}
