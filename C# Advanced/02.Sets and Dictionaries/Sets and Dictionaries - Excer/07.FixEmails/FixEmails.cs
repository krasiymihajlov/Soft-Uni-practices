namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var collect = new Dictionary<string, string>();

            while (name != "stop")
            {
                var email = Console.ReadLine();

                if (email.EndsWith("us") || email.EndsWith("uk"))
                {
                    name = Console.ReadLine();
                    continue;
                }

                collect[name] = email;

                name = Console.ReadLine();
            }

            foreach (var kvp in collect)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
