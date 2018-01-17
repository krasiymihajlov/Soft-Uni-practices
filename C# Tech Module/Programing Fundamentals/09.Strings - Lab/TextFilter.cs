namespace _03.Text_Filter
{
    using System;

    public class TextFilter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();           
            foreach (var banWord in bannedWords)
            {
                text = text.Replace(banWord, new string('*', banWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}
