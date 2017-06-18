namespace _02.LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        const string FirstPath = "../../FirstFile.txt";
        const string SecondPath = "../../SecondFile.txt";

        public static void Main()
        {
            CreateFile(FirstPath);
            InitializeFirstFile(FirstPath);
            ReadFirstFileAndWriteSecondFile(FirstPath, SecondPath);
        }
        
        private static void CreateFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
        }

        private static void InitializeFirstFile(string path)
        {
            using (var writer = new StreamWriter(path))
            {
               writer.WriteLine("Some cool text");
               writer.WriteLine("Just Text");
               writer.WriteLine("Another cool text");
               writer.WriteLine("And again");
               writer.WriteLine("Finish!");
            }
        }

        private static void ReadFirstFileAndWriteSecondFile(string path, string newPath)
        {
            CreateFile(newPath);  // проверяваме съществува ли вторият файл

            using (var writer = new StreamWriter(newPath))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    int line = 1;
                    string readLine = reader.ReadLine();
                    while (readLine != null)
                    {
                        writer.WriteLine($"{line}. {readLine}");

                        line++;
                        readLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
