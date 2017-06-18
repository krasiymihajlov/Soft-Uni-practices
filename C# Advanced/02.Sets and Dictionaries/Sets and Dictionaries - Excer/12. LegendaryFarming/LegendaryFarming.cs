namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            var text = Console.ReadLine().Split();
            var keyMaterials = new Dictionary<string, long>();
            var junk = new Dictionary<string, long>();

            var shadowmourne = false;
            var valanyr = false;
            var dragonwrath = false;

            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            while (true)
            {
                for (int i = 0; i < text.Length; i += 2)
                {
                    var quantity = long.Parse(text[i]);
                    var material = text[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk[material] = quantity;
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }

                    if (material == "shards")
                    {
                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;
                            shadowmourne = true;
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;
                            valanyr = true;
                            break;
                        }
                    }
                    else if (material == "motes")
                    {
                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;
                            dragonwrath = true;
                            break;
                        }
                    }
                }

                if(shadowmourne || valanyr || dragonwrath)
                {
                    break;
                }

                text = Console.ReadLine().Split();
            }
            


            if (shadowmourne)
            {
                Console.WriteLine($"Shadowmourne obtained!");
                foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {

                    Console.WriteLine($"{item.Key}: {item.Value}");

                }

                foreach (var scrap in junk.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{scrap.Key}: {scrap.Value}");
                }
            }
            else if (valanyr)
            {
                Console.WriteLine($"Valanyr obtained!");
                foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                foreach (var scrap in junk.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{scrap.Key}: {scrap.Value}");
                }
            }
            else if (dragonwrath)
            {
                Console.WriteLine($"Dragonwrath obtained!");
                foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                foreach (var scrap in junk.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{scrap.Key}: {scrap.Value}");
                }
            }

        }
    }
}
