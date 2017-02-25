namespace _03.Nether_Realms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class NetherRealms
    {
        public static void Main()
        {
            var demonsName = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => d.Trim())
                .ToArray();

            var healthRegex = new Regex(@"[^\d\+\-\*\/\.]");
            var damageRegex = new Regex(@"[-+]((\d+\.\d+)|\d+)|(\d+\.\d+)|\d+");

            var demonDict = new SortedDictionary<string, Demons>();

            
            for (int i = 0; i < demonsName.Length; i++)
            {
                var health = 0;
                var name = demonsName[i];
                if (!demonDict.ContainsKey(name))
                {
                    demonDict[name] = new Demons();
                }                 
                 
                if (healthRegex.IsMatch(name))
                {
                    var matches = healthRegex.Matches(name);
                    foreach (Match match in matches)
                    {
                        foreach (var symbol in match.ToString())
                        {
                            health += (int)symbol;
                        }                        
                    }

                    demonDict[name].health = health;
                }
                else
                {
                    demonDict[name].health = health;
                }

                var damage = 0d;
                if (damageRegex.IsMatch(name))
                {
                    var match = damageRegex.Matches(name);

                    
                    foreach (Match digit in match)
                    {                        
                        damage += double.Parse(digit.Value);                        
                    }

                    demonDict[name].damage = damage;
                }
                else
                {
                    demonDict[name].damage = damage;
                }

                foreach (char symbol in name)
                {
                    if (symbol == '*')
                    {
                        demonDict[name].damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        demonDict[name].damage /= 2;
                    }
                }
            }

            foreach (var demon in demonDict)
            {
                var name = demon.Key;
                var damage = demon.Value.damage;
                var health = demon.Value.health;
                Console.WriteLine($"{name} - {health} health, {damage:F2} damage");                
            }
            
        }
    }

    public class Demons
    {
        public int health { get; set; }
        public double damage { get; set; }
        
    }
}
