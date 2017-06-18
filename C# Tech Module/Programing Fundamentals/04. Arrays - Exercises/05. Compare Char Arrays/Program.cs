namespace _05.Compare_Char_Arrays
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            var firstText = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            var secondText = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            int minLenght = Math.Min(firstText.Length, secondText.Length);            

            for (int i = 0; i < minLenght; i++)
            {
                if (firstText[i] < secondText[i])
                {
                    WriteArray(firstText);
                    WriteArray(secondText);
                    break;
                }
                else if (firstText[i] > secondText[i])
                {
                    WriteArray(secondText);
                    WriteArray(firstText);
                    break;
                } 
                else if (firstText.Length == secondText.Length && firstText[i] == secondText[i])
                {
                    WriteArray(firstText);
                    WriteArray(secondText);
                    break;
                }   
                else if (firstText.Length > secondText.Length && firstText[i] == secondText[i])
                {
                    WriteArray(secondText);
                    WriteArray(firstText);
                    break;
                }
                else if (firstText.Length < secondText.Length && firstText[i] == secondText[i])
                {
                    WriteArray(firstText);
                    WriteArray(secondText);
                    break;
                }
            }
        }

        public static void WriteArray(char[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
            }

            Console.WriteLine();
        }
    }
}
