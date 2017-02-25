namespace _09.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var farming = new Dictionary<string, int>();
            var junks = new SortedDictionary<string, int>();

            var Shadowmourne = 0;
            var Valanyr = 0;
            var Dragonwrath = 0;

            farming["shards"] = 0;
            farming["fragments"] = 0;
            farming["motes"] = 0;

            var quantity = 0;
            var material = string.Empty;

            while (true)
            {
                var line = Console.ReadLine().ToLower().Split().ToArray();
                
                for (int i = 0; i < line.Length; i++)
                {

                    if (i % 2 == 0)
                    {
                        quantity = int.Parse(line[i]);
                        continue;
                    }
                    else
                    {
                        material = line[i];
                    }

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        farming[material] += quantity;

                        if (farming[material] >= 250)
                        {
                            if (material == "shards")
                            {
                                Shadowmourne = 250;
                                farming[material] = farming[material] - Shadowmourne;
                                break;
                            }
                            else if (material == "fragments")
                            {
                                Valanyr = 250;
                                farming[material] = farming[material] - Valanyr;
                                break;
                            }
                            else if (material == "motes")
                            {
                                Dragonwrath = 250;
                                farming[material] = farming[material] - Dragonwrath;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(material))
                        {
                            junks[material] = quantity;
                        }
                        else
                        {
                            junks[material] += quantity;
                        }
                    }

                }

                if (Shadowmourne == 250 || Valanyr == 250 || Dragonwrath == 250)
                {
                    break;
                }
            }

                if (Shadowmourne == 250)
                {
                    Console.WriteLine("Shadowmourne obtained!");
                }
                else if (Valanyr == 250)
                {
                    Console.WriteLine("Valanyr obtained!");
                }
                else if (Dragonwrath == 250)
                {
                    Console.WriteLine("Dragonwrath obtained!");
                }

                foreach (var item in farming.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                foreach (var junk in junks)
                {
                    Console.WriteLine($"{junk.Key}: {junk.Value}");
                }

            
        }
    }
}
