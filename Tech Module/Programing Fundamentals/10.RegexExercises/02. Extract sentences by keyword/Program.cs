namespace _02.Extract_sentences_by_keyword
{
    using System;
    using System.Text.RegularExpressions;

    public class RegexExercises
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var input = Console.ReadLine()
                .Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var regex = new Regex("\\b" + word + "\\b");

            foreach (var match in input)
            {
                if (regex.IsMatch(match))
                {                    
                    Console.WriteLine(match.Trim());
                }
            }            
        }
    }
}
