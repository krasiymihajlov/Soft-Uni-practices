namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Files
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var files = new Dictionary<string, List<File>>();

            for (int i = 0; i < n; i++)
            {
                var folder = Console.ReadLine().Split('\\');

                var root = folder.First();
                var fullFiles = folder.Last().Split(';');

                var fileName = fullFiles.First();
                var size = long.Parse(fullFiles.Last());

                var file = new File
                {
                    FileName = fileName,
                    Size = size
                };

                if (!files.ContainsKey(root))
                {
                    files[root] = new List<File>();
                    files[root].Add(file);
                }
                else
                {
                    if (files[root].Any(x => x.FileName == fileName))
                    {                        
                        foreach (var item in files[root])
                        {
                            if (item.FileName == fileName)
                            {
                                item.Size = size;
                            }
                        }
                    }
                    else
                    {
                        files[root].Add(file);
                    }
                }
            }

            var output = Console.ReadLine().Split();
            var extension = output.First();
            var rootOut = output.Last();


            if (files.ContainsKey(rootOut))
            {
                foreach (var item in files[rootOut].OrderByDescending(x => x.Size).ThenBy(x => x.FileName))
                {
                    if (item.FileName.EndsWith(extension))
                    {
                        Console.WriteLine($"{item.FileName} - {item.Size} KB");
                    }                    
                }
            }
            else
            {
                Console.WriteLine("No");
            }


        }
    }

    public class File
    {
        public string FileName { get; set; }
        public long Size { get; set; }
    }
}
