namespace _04.Cubic_Messages
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Text;

    public class CubicMassages
    {
        public static void Main()
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Over!")
                {
                    break;
                }

                var number = int.Parse(Console.ReadLine());

                var pattern = $@"(^\d+)([A-Za-z]{{{number}}})([^A-Za-z]*$)";

                var regex = new Regex(pattern);

                if (!regex.IsMatch(line))
                {
                    continue;
                }

                var match = regex.Match(line);

                var left = match.Groups[1].Value;
                var text = match.Groups[2].Value;
                var right = match.Groups[3].Value;

                var digits = string.Concat(left, right)
                    .Where(char.IsDigit)
                    .Select(x => x - '0');

                var result = new StringBuilder();

                foreach (var index in digits)
                {
                    if (index < 0 || index >= text.Length)
                    {
                        result.Append(' ');
                    }
                    else
                    {
                        result.Append(text[index]);
                    }

                }

                Console.WriteLine($"{text} == {result}");
                    
            }
        }
    }
}
