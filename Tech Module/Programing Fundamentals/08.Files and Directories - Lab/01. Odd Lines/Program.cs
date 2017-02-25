namespace _01.Odd_Lines
{
    using System.Collections.Generic;
    using System.IO;

    public class FileAndDirectoriesLab
    {
        public static void Main()
        {
            var file = "text.txt";
            var text = File.ReadAllLines(file);
            var list = new List<string>();

            for (int i = 1; i < text.Length; i += 2)
            {
                list.Add(text[i]);
            }

            File.WriteAllText(file, string.Join("\r\n", list));
        }
    }
}
