namespace _08.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var files = GetFilesFromDirectory();
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveReport(files, desktopPath);
            OutputMasage("Report file is Ready!");
        }

        private static void SaveReport(Dictionary<string, Dictionary<string, long>> files, string dir)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "report.txt";

            IsFileExist(fileName);

            var report = Path.Combine(path, fileName);

            using (var writer = new StreamWriter(report))
            {
                foreach (var group in files
                    .OrderByDescending(g => g.Value.Count).ThenBy(g => g.Key))
                {
                    var filesInGroup = string.Join(Environment.NewLine, group.Value
                        .OrderByDescending(f => f.Value)
                        .Select(kvp => $"--{kvp.Key} - {kvp.Value}kb"));

                    writer.Write($"{group.Key}{Environment.NewLine}{filesInGroup}{Environment.NewLine}");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, long>> GetFilesFromDirectory()
        {
            var path = "../../";
            var dir = Path.GetDirectoryName(path);

            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            var result = new Dictionary<string, Dictionary<string, long>>();

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file);
                var fileSize = new FileInfo(file).Length;

                if (!result.ContainsKey(extension))
                {
                    result[extension] = new Dictionary<string, long>();
                }

                result[extension][file] = fileSize;
            }

            return result;
        }

        private static void IsFileExist(string path)
        {
            if (!File.Exists(path))
            {
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var stream = File.Create(dirPath + path);
                stream.Close();
            }
        }

        private static void OutputMasage(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = currentColor;
        }
    }
}
