namespace _04.Split_by_Word_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new char[] { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();
            bool charIsUpper = true;
            bool charIsLower = true;

            for (int index = 0; index < text.Count; index++)
            {
                for (int symbol = 0; symbol < text[index].Length; symbol++)
                {
                    string word = text[index];
                    char symb = word[symbol];

                    if (char.IsLower(symb))
                    {
                        charIsUpper = false;
                    }
                    else if (char.IsUpper(symb))
                    {
                        charIsLower = false;
                    }
                    else
                    {
                        charIsUpper = false;
                        charIsLower = false;
                    }
                }

                if (charIsUpper)
                {
                    upperCase.Add(text[index]);
                }
                else if (charIsLower)
                {
                    lowerCase.Add(text[index]);
                }
                else
                {
                    mixedCase.Add(text[index]);
                }

                charIsUpper = true;
                charIsLower = true;
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
        }
    }
}
