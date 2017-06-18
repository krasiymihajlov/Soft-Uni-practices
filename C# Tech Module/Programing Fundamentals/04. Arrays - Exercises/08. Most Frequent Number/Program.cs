namespace _08.Most_Frequent_Number
{
    using System;
    using System.Linq;

    public class ArrayExercises
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int previousNumber = elements[0];
            int counter = 0;
            int bestCounter = 0;
            int bestValue = 0;
            int value = 0;

            for (int index = 0; index < elements.Length; index++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (elements[index] == elements[j])
                    {
                        counter++;
                        value = elements[j];
                    }                    
                }

                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    bestValue = value;
                }

                counter = 0;

            }

            Console.WriteLine(bestValue);
        }
    }
}
