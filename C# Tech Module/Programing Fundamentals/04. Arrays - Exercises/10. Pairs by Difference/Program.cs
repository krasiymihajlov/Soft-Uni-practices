namespace _10.Pairs_by_Difference
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int differens = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    if ((numbers[j] - numbers[index]) == differens && numbers[index] != numbers[j])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);        
        }
    }
}
