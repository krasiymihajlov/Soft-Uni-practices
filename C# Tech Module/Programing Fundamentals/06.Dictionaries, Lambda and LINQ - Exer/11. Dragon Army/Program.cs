namespace _11.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, decimal[]>>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine().Split();

                var type = line[0];
                var name = line[1];

                var damageStats = line[2];
                var healthStats = line[3];
                var armorStats = line[4];

                var damage = 0m;
                if (!(damageStats == "null"))
                {
                    damage = decimal.Parse(damageStats);
                }
                else
                {
                    damage = 45;
                }

                var health = 0m;

                if (!(healthStats == "null"))
                {
                    health = decimal.Parse(healthStats);
                }
                else
                {
                    health = 250;
                }

                var armor = 0m;
                if (!(armorStats == "null"))
                {
                    armor = decimal.Parse(armorStats);
                }
                else
                {
                    armor = 10;
                }

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, decimal[]>();
                }

                dragons[type][name] = new decimal[] { damage, health, armor };

            }

            foreach (var dragon in dragons)
            {
                var type = dragon.Key;
                var name = dragon.Value;

                var averageDamage = name.Values.Average(a => a[0]);
                var averageHealth = name.Values.Average(a => a[1]);
                var averageArmor = name.Values.Average(a => a[2]);

                Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var item in name)
                {
                    var dragonName = item.Key;
                    var stats = item.Value;

                    var damage = stats[0];
                    var health = stats[1];
                    var armor = stats[2];

                    Console.WriteLine($"-{dragonName} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
