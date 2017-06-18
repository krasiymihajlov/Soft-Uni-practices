using System.Text;

namespace _10.UseYourChainsBuddy
{
    using System;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();

            string pattern = "<p>(.*?)<\\/p>";
            string spacePattern = "\\s+";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                string paragraphText = match.Groups[1].Value;
                for (int i = 0; i < paragraphText.Length; i++)
                {
                    if (char.IsDigit(paragraphText[i]) || char.IsLower(paragraphText[i]))
                    {
                        sb.Append(paragraphText[i]);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                var symbols = Regex.Replace(sb.ToString(), spacePattern, " ");
                sb.Clear();

                for (int i = 0; i < symbols.Length; i++)
                {
                    if (!char.IsDigit(symbols[i]))
                    {
                        if ((int)symbols[i] != 32)
                        {
                            if ((int)symbols[i] - 'a' < 13)
                            {
                                result.Append((char)(symbols[i] + 13));
                            }
                            else
                            {
                                result.Append((char)(symbols[i] - 13));
                            }
                        }
                        else
                        {
                            result.Append(' ');
                        }
                    }
                    else
                    {
                        result.Append(symbols[i]);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
