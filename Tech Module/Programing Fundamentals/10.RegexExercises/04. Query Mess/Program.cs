namespace _04.Query_Mess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class RegexExersices
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"(%20|\+)+");
            var pattern = new Regex(@"([^&=?]*)=([^&=]*)");

            var result = new List<Dictionary<string, List<string>>>();

            while (input != "END")
            {
                var mathes = pattern.Matches(input);
                var dict = new Dictionary<string, List<string>>();

                foreach (Match match in mathes)
                {

                    var pair = match.ToString().Split('=');
                    var field = pair[0];
                    var value = pair[1];

                    if (!regex.IsMatch(match.ToString()))
                    {
                        if (!dict.ContainsKey(field))
                        {
                            dict[field] = new List<string>();
                            dict[field].Add(value);
                        }
                        else
                        {
                            dict[field].Add(value);
                        }

                    }
                    else
                    {
                        var newField = regex.Replace(field, " ").Trim();

                        var newValue = regex.Replace(value, " ").Trim();

                        if (!dict.ContainsKey(newField))
                        {
                            dict[newField] = new List<string>();
                            dict[newField].Add(newValue);
                        }
                        else
                        {
                            dict[newField].Add(newValue);
                        }
                    }
                }

                result.Add(dict);

                input = Console.ReadLine();
            }

            foreach (var dictionary in result)
            {
                var field = dictionary.Select(x => x.Key).ToArray();
                var values = dictionary.Select(x => x.Value);

                foreach (var key in field)
                {
                    Console.Write($"{key}=[{string.Join(", ", dictionary[key])}]");
                }

                Console.WriteLine();
            }
        }
    }
}