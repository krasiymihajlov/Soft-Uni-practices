namespace _02.StringLength
{
    using System;

    public class StringLength
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string newText = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (i < 20)
                {
                    newText += input[i];
                }
            }

            string padRigth = newText.PadRight(20, '*');
            Console.WriteLine(padRigth);
        }
    }
}
