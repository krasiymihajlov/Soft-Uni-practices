namespace _07.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class ValidUsernames
    {
        public static void Main()
        {
            string[] text = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')', '\t', '\n' }
                , StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"\b[A-Za-z]\w{2,24}\b";
            Regex regex = new Regex(pattern);
            List<string> matches = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                Match match = regex.Match(text[i]);
                if (match.Success)
                {
                    matches.Add(match.Groups[0].Value);
                }
            }

            int maxSum = int.MinValue;
            string[] result = new string[2];
            for (int i = 1; i < matches.Count; i++)
            {
                int currentLength = matches[i].Length + matches[i - 1].Length;
                if (currentLength > maxSum)
                {
                    maxSum = currentLength;
                    result[0] = matches[i - 1];
                    result[1] = matches[i];
                }
            }

            Console.WriteLine(string.Join("\r\n", result));
        }
    }
}
