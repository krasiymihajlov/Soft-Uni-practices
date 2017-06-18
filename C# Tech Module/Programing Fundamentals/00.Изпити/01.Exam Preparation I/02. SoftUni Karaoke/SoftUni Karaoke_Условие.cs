namespace _02.SoftUni_Karaoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var availableSongs = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var performances = Console.ReadLine();

            var dict = new Dictionary<string, HashSet<string>>();
            var noAwards = false;

            while (performances != "dawn")
            {
                var performance = performances
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var participant = performance.First();
                var song = performance.Skip(1).First();
                var award = performance.Last();

                if (participants.Contains(participant) && availableSongs.Contains(song))
                {
                    if (!dict.ContainsKey(participant))
                    {
                        dict[participant] = new HashSet<string>();
                    }

                    dict[participant].Add(award);
                    noAwards = true;
                }

                performances = Console.ReadLine();
            }
            if (!noAwards)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var item in dict.OrderByDescending(p => p.Value.Count).ThenBy(p => p.Key))
                {
                    var participant = item.Key;
                    var awards = item.Value;
                    Console.WriteLine($"{participant}: {awards.Count} awards");

                    foreach (var award in awards.OrderBy(a => a))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }

        }
    }
}
