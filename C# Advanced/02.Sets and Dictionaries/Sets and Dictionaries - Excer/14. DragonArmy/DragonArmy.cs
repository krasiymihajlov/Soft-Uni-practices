namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var dragons = new Dictionary<string, Dictionary<string, decimal[]>>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var dragonType = input[0];
                var dragonName = input[1];
                var dragonDamage = input[2];
                var dragonHealth = input[3];
                var dragonArmor = input[4];

                if (!dragons.ContainsKey(dragonType))
                {
                    dragons[dragonType] = new Dictionary<string, decimal[]>();
                }

                var type = dragons[dragonType];

                var damage = (dragonDamage != "null") ? decimal.Parse(dragonDamage) : 45;
                var health = (dragonHealth != "null") ? decimal.Parse(dragonHealth) : 250;
                var armor = (dragonArmor != "null") ? decimal.Parse(dragonArmor) : 10;

                if (!type.ContainsKey(dragonName))
                {
                    type[dragonName] = new decimal[] { damage, health, armor };
                }

                type[dragonName] = new decimal[] { damage, health, armor };
            }


            foreach (var kvp in dragons)
            {
                var type = kvp.Key;

                var avrDamage = kvp.Value.Values.Average(x => x[0]);
                var avrHealth = kvp.Value.Values.Average(x => x[1]);
                var avrArmor = kvp.Value.Values.Average(x => x[2]);

                Console.WriteLine($"{type}::({avrDamage:F2}/{avrHealth:F2}/{avrArmor:F2})");

                foreach (var names in kvp.Value.OrderBy(x => x.Key))
                {
                    var name = names.Key;
                    var stats = names.Value;

                    var damage = stats[0];
                    var health = stats[1];
                    var armor = stats[2];

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
