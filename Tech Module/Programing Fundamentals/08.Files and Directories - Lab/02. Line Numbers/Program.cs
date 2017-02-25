namespace _02.Line_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileAndDirectoriesLab
    {
        public static void Main()
        {
            var file = "Text.txt";
            var allFile = File.ReadAllLines(file);
            var list = new List<string>();

            for (int i = 0; i < allFile.Length; i++)
            {
                list.Add($"{i + 1}. {allFile[i]}");
            }

            File.WriteAllText(file, string.Join("\r\n", list));
        }
    }
}
