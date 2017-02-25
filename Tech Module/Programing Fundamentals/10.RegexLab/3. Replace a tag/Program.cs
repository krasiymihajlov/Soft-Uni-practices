namespace _7.Replace_a_tag
{
    using System;
    using System.Text.RegularExpressions;

    public class RegexLab
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = string.Empty;

            var regex = new Regex(@"<a.*?href=("")(.*?)\1>(.*?)<\/a>");
            var match = regex.Matches(input);
            result = regex.Replace(input, @"[URL href=""$2""$3[/URL]");
            Console.WriteLine(result);
            input = Console.ReadLine();
        }
    }
}
