namespace _05.Short_Words_Sorted
{
    using System;    
    using System.Linq;

    public class DictionariesLambdaLinqLab
    {
        public static void Main()
        {
            var colection = Console.ReadLine()
                .ToLower()
                .Split(new char[] { '.', ',', ':', ';', ',', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }
                , StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", colection));
        }
    }
}