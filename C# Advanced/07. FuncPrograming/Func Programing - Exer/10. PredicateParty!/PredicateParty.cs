namespace _10.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string line = Console.ReadLine();
            Func<string, string, bool> isStartsWith = (n1, n2) => n1.StartsWith($"{n2}");
            Func<string, string, bool> isEndsWith = (n1, n2) => n1.EndsWith($"{n2}");
            Func<string, string, bool> isLength = (n1, n2) => n1.Length == int.Parse(n2);

            while (line != "Party!")
            {
                string[] commands = line.Split();
                string change = commands[0];
                string command = commands[1];
                string symbol = commands[2];

                for (int i = 0; i < people.Count; i++)
                {
                    string currentPeople = people[i];

                    switch (command)
                    {
                        case "StartsWith":
                            if (isStartsWith(currentPeople, symbol))
                            {
                                if (change == "Remove")
                                {
                                    people.Remove(currentPeople);
                                    i--;
                                }
                                else if(change == "Double")
                                {
                                    people.Insert(i, people[i]);
                                    i++;
                                }
                            }
                            break;
                        case "Length":
                            if (isLength(currentPeople, symbol))
                            {
                                if (change == "Remove")
                                {
                                    people.Remove(currentPeople);

                                    i--;
                                }
                                else if (change == "Double")
                                {
                                    people.Insert(i, people[i]);
                                    i++;
                                }
                            }
                            break;
                        case "EndsWith":
                            if (isEndsWith(currentPeople, symbol))
                            {
                                if (change == "Remove")
                                {
                                    people.Remove(currentPeople);
                                    i--;
                                }
                                else if (change == "Double")
                                {
                                    people.Insert(i, people[i]);
                                    i++;
                                }
                            }
                            break;
                    }
                }

                line = Console.ReadLine();
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
