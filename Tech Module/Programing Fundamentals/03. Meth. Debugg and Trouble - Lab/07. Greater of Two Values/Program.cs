namespace _07.Greater_of_Two_Values
{
    using System;

    public class GreaterValues
    {
        public static void Main(string[] args)
        {
            string inputValues = Console.ReadLine();
            if (inputValues == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());
                int maxNumber = GetMax(firstNumber, secondNumber);
                Console.WriteLine(maxNumber);
            }
            else if (inputValues == "char")
            {
                char firstLetter = char.Parse(Console.ReadLine());
                char secondLetter = char.Parse(Console.ReadLine());
                char maxLetter = GetMax(firstLetter, secondLetter);
                Console.WriteLine(maxLetter);
            }
            else if (inputValues == "string")
            {
                string firstText = Console.ReadLine();
                string secondText = Console.ReadLine();
                string maxText = GetMax(firstText, secondText);
                Console.WriteLine(maxText);
            }
        }

        public static int GetMax(int firstnumber, int secondNumber)
        {
            if (firstnumber <= secondNumber)
            {
                return secondNumber;
            }
            else
            {
                return firstnumber;
            }
        }

        public static char GetMax(char firstLetter, char secondLetter)
        {
            if (firstLetter <= secondLetter)
            {
                return secondLetter;
            }
            else
            {
                return firstLetter;
            }
        }

        public static string GetMax(string firstText, string secondText)
        {
            if (firstText.CompareTo(secondText) >= 0)
            {
                return firstText;
            }
            else
            {
                return secondText;
            }
        }
    }
}