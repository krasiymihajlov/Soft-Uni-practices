namespace _04.ReplaceATag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceATag
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"(<a)\shref=('|"").+\2(>).+(<\/a>)";

            Regex regex = new Regex(pattern);

            while (text != "end")
            {
                MatchCollection matches = regex.Matches(text);

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        var reminder = match.ToString();
                        reminder = reminder.Replace(match.Groups[1].Value, "[URL");
                        reminder = reminder.Replace(match.Groups[4].Value, "[/URL]");
                        reminder = reminder.Replace(match.Groups[3].Value, "]");
                        text = text.Replace(match.ToString(), reminder);
                    }
                }

                Console.WriteLine(text);
                
                text = Console.ReadLine();
            }
        }
    }
}
