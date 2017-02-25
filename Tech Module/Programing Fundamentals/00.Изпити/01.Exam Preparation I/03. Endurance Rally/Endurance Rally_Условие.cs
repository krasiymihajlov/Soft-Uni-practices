namespace _03.Endurance_Rally
{
    using System;
    using System.Linq;

    public class EnduranceRally
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var trackLayout = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var checkpoint = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var isReached = true;
            var zone = 0;
            double endFuel = 0;

            foreach (var name in names)
            {
                var startingFuel = (int)name.First();
                endFuel = startingFuel;

                for (int i = 0; i < trackLayout.Length; i++)
                {
                    if (checkpoint.Contains(i))
                    {
                        endFuel += trackLayout[i];
                    }
                    else
                    {
                        endFuel -= trackLayout[i];
                    }

                    if (endFuel <= 0)
                    {
                        zone = i;
                        isReached = false;
                        break;
                    }
                    else
                    {
                        isReached = true;
                    }
                    
                }

                if (!isReached)
                {
                    Console.WriteLine($"{name} - reached {zone}");
                }
                else
                {
                    Console.WriteLine($"{name} - fuel left {endFuel:F2}");
                }
                
                zone = 0;
            }           
        }
    }
}
