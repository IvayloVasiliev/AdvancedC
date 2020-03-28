using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader(path:@"../../../text.txt"))
            using (var streamWriter = new StreamWriter("write.txt"))
            {
                int lineCounter = 0;
                var symbolToReplace = new[] { "-", ",", ".", "!", "?" };

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (lineCounter % 2 == 0)
                    {
                        var words = line.Split();

                        for (int i = 0; i < words.Length; i++)
                        {
                            var curentWord = words[i];

                            foreach (var symbol in symbolToReplace)
                            {
                                curentWord = curentWord.Replace(symbol, "@");
                            }
                            words[i] = curentWord;
                        }
                         
                        var result = string.Join(" ", words.Reverse());
                        streamWriter.WriteLine(result);
                    }
                    lineCounter++; 
                }
            }
        }
    }
}
