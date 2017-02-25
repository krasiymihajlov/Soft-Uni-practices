namespace _04.Roli_The_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoliTheCoder
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var eventsId = new Dictionary<string, Events>();
            while (input != "Time for Code")
            {
                var format = input
                    .Split(new[] { '#' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.Trim())
                    .ToArray();

                if (format.Length != 2)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var id = format.First();

                var events = format.Skip(1).First()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                var eventName = events.First();

                if (events.Length < 2)
                {
                    if (!eventsId.ContainsKey(id))
                    {
                        eventsId[id] = new Events
                        {
                            EventName = eventName,
                            Participants = new HashSet<string>()
                        };

                        input = Console.ReadLine();
                        continue;
                    }
                }

                if (!eventsId.ContainsKey(id))
                {
                    eventsId[id] = new Events
                    {
                        EventName = eventName,
                        Participants = new HashSet<string>()
                    };

                    AddParticipants(eventsId, id, events);
                }
                else
                {
                    if (!(eventsId[id].EventName == eventName))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        AddParticipants(eventsId, id, events);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var validId in eventsId.Values
                .OrderByDescending(x => x.Participants.Count())
                .ThenBy(y => y.EventName))
            {
                var eventName = validId.EventName;
                var eventCount = validId.Participants.Count();

                Console.WriteLine($"{eventName} - {eventCount}");
                foreach (var participant in validId.Participants.OrderBy(x => x))
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }

        private static void AddParticipants(Dictionary<string, Events> eventsId, string id, string[] events)
        {
            for (int j = 1; j < events.Length; j++)
            {
                eventsId[id].Participants.Add(events[j]);
            }
        }
    }

    public class Events
    {
        public string EventName { get; set; }
        public HashSet<string> Participants { get; set; }
    }
}
