namespace _01.OddLines
{
    using System;
    using System.IO;

    public class OddLines
    {
        const string Path = "../../OddLines.txt";

        public static void Main()
        {
            CreateFile(Path);
            InitializeFile(Path);
            ReadFile(Path);
        }

        private static void ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 != 0) // взима само нечетните редове
                    {
                        Console.WriteLine($"In {lineNumber} line we have: {line}");
                    }

                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }

        private static void InitializeFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                for (int i = 0; i < 15; i++)
                {
                    writer.WriteLine($"{i} line!"); // запълваме файла
                }
            }
        }

        private static void CreateFile(string path)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                if (!File.Exists(path)) // ако няма такъв файл го създаваме
                {
                    File.Create(path);
                }
            }
        }
    }
}
