namespace _07.Max_Sequence_of_Increasing_Elements
{
    using System;
    using System.Linq;

    public class ArraysExercises
    {
        public static void Main()
        {  
            var equalElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int previousNumber = 0;
            int counter = 1;
            int bestCounter = 0;
            int curentNumber = 0;            

            for (int index = 1; index < equalElements.Length; index++)
            {               
                if (equalElements[index - 1] < equalElements[index])
                {                     
                    counter++;
                }
                else
                {
                    previousNumber = index ;
                    counter = 1;
                }

                if (counter > bestCounter)
                {
                    curentNumber = previousNumber;
                    bestCounter = counter;                    
                }
            }

            int[] bestNumber = new int[bestCounter];

            for (int i = 0; i < bestCounter; i++)
            {
                bestNumber[i] = equalElements[curentNumber + i];
            }

            for (int i = 0; i < bestCounter; i++)
            {
                Console.Write(bestNumber[i] + " ");
            }
        }
    }
}
