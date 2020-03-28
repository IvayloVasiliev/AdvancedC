using System;
using System.IO;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var streamReader = new StreamReader(path:@"text.txt");

            using (var streamReader = new StreamReader(path: @"text.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                }
            }

            Console.WriteLine(Environment.CurrentDirectory);

            //File.WriteAllText("output.txt", sb.ToString());
        }
    }
}
