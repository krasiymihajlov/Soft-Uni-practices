namespace _05.Magic_exchangeable_words
{
    using System;
    using System.Collections.Generic;

    public class StringExer
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var result = GetExchangeable(input);
            Console.WriteLine(result.ToString().ToLower());
        }

        public static bool GetExchangeable(string[] input)
        {
            var firstWord = input[0];
            var secondWord = input[1];
            var exchangeable = true;

            var minLenth = Math.Min(firstWord.Length, secondWord.Length);
            var maxLenth = Math.Max(firstWord.Length, secondWord.Length);
            var shorter = string.Empty;
            var longer = string.Empty;

            if (firstWord.Length >= secondWord.Length)
            {
                shorter = secondWord;
                longer = firstWord;
            }
            else
            {
                shorter = firstWord;
                longer = secondWord;
            }

            var exchangeWord = new Dictionary<char, char>();

            for (int i = 0; i < minLenth; i++)
            {
                if (!exchangeWord.ContainsKey(firstWord[i]) && !exchangeWord.ContainsValue(secondWord[i]))
                {
                    exchangeWord[firstWord[i]] = secondWord[i];
                }
                else
                {
                    if (exchangeWord.ContainsKey(firstWord[i]))
                    {
                        if (exchangeWord[firstWord[i]] != secondWord[i])
                        {
                            return false;
                        }
                    }
                    else if (exchangeWord.ContainsValue(secondWord[i]))
                    {
                        return false;
                    }
                }
            }

            foreach (var symbol in longer)
            {
                if (!exchangeWord.ContainsKey(symbol) && !exchangeWord.ContainsValue(symbol))
                {
                    return false;
                }
            }

            return exchangeable;
        }
    }
}
