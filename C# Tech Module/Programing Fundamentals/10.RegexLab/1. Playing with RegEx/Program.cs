namespace _1.Playing_with_RegEx
{
    using System;
    using System.Text.RegularExpressions;

    public class RegexLab
    {
        public static void Main()
        {
            var input = "Ivan Ivanov"; //Console.ReadLine();

            var text = new Regex(@"([A-Z][a-z]+)\s+\1");
            var match = text.Match(input);
            var result = match.;

            Console.WriteLine(result);           

           

        }
    }
}
