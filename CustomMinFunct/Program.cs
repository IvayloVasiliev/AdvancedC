using System;
using System.Linq;

namespace CustomMinFunct
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int[], int> minFunc = inputNums =>
            {
                int minValue = int.MaxValue;

                foreach (var currrentNum in inputNums)
                {
                    if (currrentNum < minValue)
                    {
                        minValue = currrentNum;
                    }
                }

                return minValue;
            };


            int[] numbres = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

           int result = minFunc(numbres);

            Console.WriteLine(result    );
        }
    }
}
