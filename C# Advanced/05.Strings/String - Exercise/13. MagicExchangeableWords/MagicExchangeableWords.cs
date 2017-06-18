namespace _13.MagicExchangeableWords
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MagicExchangeableWords
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x.Length).ToArray();

            Dictionary<char, char> coll = new Dictionary<char, char>();

            string smallerWord = input[0];
            string largerword = input[1];
            bool isExchangeAble = true;

            for (int i = 0; i < smallerWord.Length; i++)
            {
                char first = smallerWord[i];
                char second = largerword[i];

                if (!coll.ContainsKey(first) && !coll.ContainsValue(second))
                {
                    coll[first] = second;
                }
                else
                {
                    if (coll.ContainsKey(first))
                    {
                        if (coll[first] != second)
                        {
                            isExchangeAble = false;
                            break;
                        }
                    }
                    else if (coll.ContainsValue(second))
                    {
                        isExchangeAble = false;
                        break;
                    }
                }
            }

            for (int i = 0; i < largerword.Length; i++)
            {
                char last = largerword[i];

                if (!coll.ContainsKey(last) && !coll.ContainsValue(last))
                {
                    isExchangeAble = false;
                    break;
                }
            }

            if (isExchangeAble)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
