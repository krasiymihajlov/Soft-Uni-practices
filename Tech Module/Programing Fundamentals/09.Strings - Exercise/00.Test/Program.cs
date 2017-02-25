namespace _00.Test
{
    using System;

    public class StringsExercises
    {
        public static void Main()
        {
            var input = 'Z';
            var input2 = 'a';

            Console.WriteLine((int)input - 'A' + 1);
            Console.WriteLine((int)input2 - 'a' + 1);
            
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("x4");
        }
    }
}
