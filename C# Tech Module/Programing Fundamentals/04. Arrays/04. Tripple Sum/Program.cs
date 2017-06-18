namespace _04.Tripple_Sum
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int[] numbers = text.Split(' ').Select(int.Parse).ToArray();
            bool notFound = true;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    int sum = numbers[a] + numbers[b];
                    if (numbers.Contains(sum))
                    {
                        Console.WriteLine(string.Join(" ", $"{numbers[a]} + {numbers[b]} == {sum}"));
                        notFound = false;
                    }
                }
            }

            if(!notFound)
            {
                Console.WriteLine("No");
            }                       
        }
    }
}
