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
                        var newField = regex.Replace(field.Trim(), " ")
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();

                        var newValue = regex.Replace(value.ToString().Trim(), " ");                            ;                             

                        if (!dict.ContainsKey(newField))
                        {
                            dict[newField] = new List<string>();
                            dict[newField].Add(newValue.Trim());
                        }
                        else
                        {
                            dict[newField].Add(newValue.Trim());
                        }
                    }
                }

                result.Add(dict);

                input = Console.ReadLine();
            }

            foreach (var dictionary in result)
            {
                var field = dictionary.Select(x => x.Key).ToArray();
                var values = dictionary.Select(x => x.Value).ToArray();

                foreach (var key in field)
                {
                    Console.Write($"{key}=[");
                    Console.Write(string.Join(", ", dictionary[key]));
                    Console.Write("]");
                }

                Console.WriteLine();
            }
        }
    }
}