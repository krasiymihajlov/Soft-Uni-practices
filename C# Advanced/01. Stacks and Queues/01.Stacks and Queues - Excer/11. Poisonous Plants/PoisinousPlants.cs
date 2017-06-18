namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisinousPlants
    {
        public static void Main()
        {
            var plants = int.Parse(Console.ReadLine());
            var plantsLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var currentPlants = new Queue<int>(plantsLine);
            var dayCounter = 0;
            var min = int.MaxValue;

            while (true)
            {
                var curPlant = currentPlants.ToArray();
                //min = currentPlants.Peek();

                for (int i = 1; i < curPlant.Length; i++)
                {

                    if(i == 1)
                    {

                        var queue = currentPlants.Dequeue();
                        
                        if (min > queue)
                        {
                            min = queue;
                        }

                        currentPlants.Enqueue(queue);
                    }            
                    
                    var currentPlant = curPlant[i];
                    var previousPlant = curPlant[i - 1];

                    if(min >= currentPlant)
                    {
                        min = currentPlant;
                        var queue = currentPlants.Dequeue();
                        currentPlants.Enqueue(queue);
                    }
                    else
                    {
                        currentPlants.Dequeue();
                    }

                    //if (currentPlant > previousPlant)
                    //{
                    //    currentPlants.Dequeue();
                    //}
                    //else
                    //{
                    //    var queue = currentPlants.Dequeue();
                    //    currentPlants.Enqueue(queue);
                    //}
                }

                var prevPlants = currentPlants.Count();

                if (curPlant.Length == prevPlants)
                {
                    Console.WriteLine(dayCounter);
                    break;
                }

                dayCounter++;
            }
        }
    }
}
