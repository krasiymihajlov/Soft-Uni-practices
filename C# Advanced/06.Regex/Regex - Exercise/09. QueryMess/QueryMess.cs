namespace _09.QueryMess
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class QueryMess
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string pattern = "(%20|\\+)+";
            Regex regex = new Regex(pattern);
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while (line != "END")
            {
                if (line.IndexOf("?") != -1)
                {
                    line = line.Substring(line.LastIndexOf("?") + 1);
                }

                string[] firstSplit = line.Split('&');

                for (int i = 0; i < firstSplit.Length; i++)
                {
                    string[] secondSplit = firstSplit[i].Split('=');
                    string key = secondSplit[0].Trim();
                    string value = secondSplit[1].Trim();

                    Match matchKey = regex.Match(key);
                    if (matchKey.Success)
                    {
                        key = key.Replace(matchKey.Groups[0].Value, " ").Trim();
                    }

                    Match matchValue = regex.Match(value);
                    if (matchValue.Success)
                    {
                        value = value.Replace(matchValue.Groups[0].Value, " ").Trim();
                    }

                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new List<string>();
                    }

                    dict[key].Add(value);
                }

                foreach (var kvp in dict)
                {
                    Console.Write($"{kvp.Key}=[");
                    Console.Write(string.Join(", ", kvp.Value));
                    Console.Write("]");
                }

                Console.WriteLine();
                dict.Clear();
                line = Console.ReadLine();
            }
        }
    }
}
