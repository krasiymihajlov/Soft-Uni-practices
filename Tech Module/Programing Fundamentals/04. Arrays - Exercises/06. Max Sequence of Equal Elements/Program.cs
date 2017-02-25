namespace _06.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class ArrayExercises
    {
        public static void Main()
        {
            var equalElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int previousNumber = equalElements[0];
            int counter = 1;
            int bestCounter = 0;
            int bestNumber = 0;

            for (int index = 1; index < equalElements.Length; index++)
            {                
                int curentNumber = equalElements[index];

                if (curentNumber == previousNumber)
                {
                    counter++;                    
                }
                else
                {
                    previousNumber = curentNumber;
                    counter = 1;
                }

                if (counter > bestCounter)
                {
                    bestCounter = counter;
                    bestNumber = curentNumber;
                }
            }

            for (int i = 0; i < bestCounter; i++)
            {
                Console.Write(bestNumber + " ");
            }
        }
    }
}
