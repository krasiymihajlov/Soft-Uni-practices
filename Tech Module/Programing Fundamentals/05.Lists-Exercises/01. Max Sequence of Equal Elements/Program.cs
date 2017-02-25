namespace _01.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListsExercises
    {
        public static void Main()
        {
            var equalElements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int counter = 1;
            int maxCounter = 0;
            int value = 0;

            for (int i = 1; i < equalElements.Count; i++)
            {
                if (equalElements[i - 1] == equalElements[i])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    value = equalElements[i - 1];
                }
            }

            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write(value + " ");
            }
        }
    }
}
