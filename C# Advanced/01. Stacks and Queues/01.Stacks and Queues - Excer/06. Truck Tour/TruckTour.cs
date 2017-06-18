namespace _06.Truck_Tour
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TruckTour
    {
        public static void Main()
        {
            var petrolPumps = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var isFinished = false;

            for (int i = 0; i < petrolPumps; i++)
            {
                queue.Enqueue(Console.ReadLine());
            }


            for (int i = 0; i < petrolPumps; i++)
            {
                var fuel = 0;

                foreach (var pump in queue)
                {
                    var currentRow = pump.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();

                    var amount = currentRow[0];
                    var distance = currentRow[1];
                    fuel += amount - distance;

                    if (fuel < 0)
                    {
                        isFinished = false;
                        break;
                    }
                    else
                    {
                        isFinished = true;
                    }
                }

                if (isFinished)
                {
                    Console.WriteLine(i);
                    return;
                }

                var currentQueue = queue.Dequeue();
                queue.Enqueue(currentQueue);
            }
        }
    }
}
