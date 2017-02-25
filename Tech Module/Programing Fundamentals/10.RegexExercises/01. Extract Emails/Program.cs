namespace _01.Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    public class RegexExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine();            

            var regex = new Regex(@"\b(?<!\.|\-|_)([A-Za-z0-9][\w-.]+\@[A-Za-z-]+)(\.[A-Za-z-]+)+");
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var result = match.ToString();
                Console.WriteLine(result);               
            }
        }
    }
}
