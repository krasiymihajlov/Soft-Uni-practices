namespace _05.ConcatenateStrings
{
    using System;
    using System.Text;
    
    public class ConcatenateStrings
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();

                sb.Append(word);
                sb.Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}
