namespace _03.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileAndDirectoriesLab
    {
        public static void Main()
        {
            var wordsFile = File.ReadAllText("words.txt").Split();
            var inputFile = File.ReadAllText("Input.txt").ToLower().Split(
                new[] { ' ', '.', '-', ',', '?', '!','\r'}, StringSplitOptions.RemoveEmptyEntries);

            var list = new List<string>();
            
            for (int i = 0; i < wordsFile.Length; i++)
            {
                var count = 0;
                for (int j = 0; j < inputFile.Length; j++)
                {
                    if (wordsFile[i] == inputFile[j])
                    {
                        count++;
                    }
                }

                list.Add($"{wordsFile[i]} - {count}");
            }

            var output = "output.txt";
            if (!File.Exists(output))
            {
                File.Create(output);
            }
            list.OrderByDescending(x => x);
            File.WriteAllText(output, string.Join("\r\n", list));
            

        }
    }
}
