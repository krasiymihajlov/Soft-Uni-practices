namespace _05.Use_Your_Chains__Buddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RegexExercises
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"<p>(.*?)<\/p>";
            var regex = new Regex(pattern);

            var result = new StringBuilder();
            var newText = new StringBuilder();

            foreach (Match match in regex.Matches(text))
            {
                var sentence = match.Groups[1].Value;

                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsLower(sentence[i]) || char.IsDigit(sentence[i]))
                    {
                        newText.Append(sentence[i]);
                    }
                    else
                    {
                        newText.Append(' ');
                    }
                }

                var symbols = Regex.Replace(newText.ToString(), @"\s+", " ");
                newText.Clear();

                for (int j = 0; j < symbols.Length; j++)
                {
                    if (!char.IsDigit(symbols[j]))
                    {
                        if ((int)symbols[j] != 32)
                        {
                            if ((int)symbols[j] - 'a' < 13)
                            {
                                result.Append((char)(symbols[j] + 13));
                            }
                            else
                            {
                                result.Append((char)(symbols[j] - 13));
                            }
                        }
                        else
                        {
                            result.Append(' ');

                        }
                    }
                    else
                    {
                        result.Append(symbols[j]);
                    }
                }
            }

            Console.WriteLine($"{result}");
        }
    }
}

