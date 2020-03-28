using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {

            //DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
            //var files = di.GetFiles();
            var files = GetAllFiles(Environment.CurrentDirectory);

            var filesByExtension = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                var extension = file.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new Dictionary<string, long >());
                }

                filesByExtension[extension].Add(file.Name, file.Length);
            }

            var sortedResult = filesByExtension
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            using (var writer = new StreamWriter("../../../report.txt"))
            {
                foreach (var item in sortedResult)
                {
                    writer.WriteLine(item.Key);

                    var currentFiles = item.Value
                        .OrderBy(f=>f.Value)
                        .ToDictionary(x => x.Key, x => x.Value);
                    
                    foreach (var file in currentFiles)
                    {
                        writer.WriteLine($"--{file.Key} - {(file.Value /1000):F3}kb");
                    }

                }
            }



        }

        private static List<FileInfo> GetAllFiles(string path)
        {
            var di = new DirectoryInfo(path);

            var directories = di.GetDirectories();

            foreach (var directory in directories)
            {
                var subFiles = directory.GetFiles(); 
            }

            var allFiles = di.GetFiles().ToList();

            return allFiles;
        }
    }
}
