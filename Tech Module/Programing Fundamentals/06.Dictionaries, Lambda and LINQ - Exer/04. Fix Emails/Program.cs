namespace _04.Fix_Emails
{
    using System;
    using System.Collections.Generic;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var fixEmail = new Dictionary<string, string>();

            string name = Console.ReadLine();            

            while (!name.Equals("stop"))
            {
                string email = Console.ReadLine();

                if (!fixEmail.ContainsKey(name))
                {
                    if (CheckChar(email))
                    {
                        fixEmail[name] = email;
                    }
                }              

                name = Console.ReadLine();
            }

            foreach (var names in fixEmail)
            {
                Console.WriteLine($"{names.Key} -> {names.Value}");
            }
        }

        public static bool CheckChar(string text)
        {
            bool domain = true;
            var lastLetter = text[text.Length - 1];
            var beforeLast = text[text.Length - 2];
            if (beforeLast == 'u' && ( lastLetter == 's' || lastLetter == 'k'))
            {
                domain = false;
            }
            return domain;
        }
    }
}
