namespace _03.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class RegexExercises
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')', '\t' }
                , StringSplitOptions.RemoveEmptyEntries);

            var regex = new Regex(@"\b[A-Za-z]\w{2,25}\b");
            var maxSum = 0;
            var validUserName = new List<string>();
            var Lengths = new List<string>();      

            foreach (var word in input)
            {                
                if (regex.IsMatch(word))
                {
                    validUserName.Add(word);
                }
            }

            for (int i = 1; i < validUserName.Count; i++)
            {
                var currentLength = validUserName[i].ToString().Length;
                var prevLength = validUserName[i - 1].ToString().Length;

                var sum = currentLength + prevLength;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    Lengths.Clear();
                    Lengths.Add(validUserName[i - 1]);
                    Lengths.Add(validUserName[i]);
                }

            }

            Console.WriteLine(string.Join("\n", Lengths));
        }
    }
}
