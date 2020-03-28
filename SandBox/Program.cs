using System;
using System.IO;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var streamReader = new StreamReader(path:@"text.txt");

            //using (var streamReader = new StreamReader(path: @"text.txt"))
            //{
            //    while (!streamReader.EndOfStream)
            //    {
            //        string line = streamReader.ReadLine();
            //    }
            //}

            // Console.WriteLine(Environment.CurrentDirectory);

            //File.WriteAllText("output.txt", sb.ToString());

            //slice file into 4 pieces
            var fileLenght = new FileInfo("text.txt").Length;
            var partSize = fileLenght / 4;
            int parts = 4;
            int fileNum = 1;

            using (var streamRaeder = new StreamReader("text.txt"))
            {
                while (!streamRaeder.EndOfStream)
                {
                    var bufferSize = partSize;

                    if (fileNum == parts)
                    {
                        bufferSize = fileLenght - (parts - 1) * partSize;
                    }

                    var buffer = new char[bufferSize];
                    streamRaeder.Read(buffer, 0, buffer.Length);

                    using (var writer = new StreamWriter($"result{fileNum}.txt"))
                    {
                        writer.Write(buffer);
                    }
                    fileNum++;
                }
            }


            
        }
    }
}
