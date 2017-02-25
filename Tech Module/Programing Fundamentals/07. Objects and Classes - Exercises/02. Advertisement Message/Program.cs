namespace _02.Advertisement_Message
{
    using System;

    public class ObjAndClassesExer
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var random = new Random();

            var phrases = GetPhrases();
            var events = GetEvent();
            var author = GetAuthor();
            var city = GetCity();            

            for (int i = 0; i < number; i++)
            {
                var randomPhrase = phrases[random.Next(0, phrases.Length)];
                var randomEvent = events[random.Next(0, events.Length)];
                var randomAuthor = author[random.Next(0, author.Length)];
                var randomCity = city[random.Next(0, city.Length)];

                Console.Write($"{randomPhrase} {randomEvent} {randomAuthor} - {randomCity}");
                Console.WriteLine();
            }

        }

        private static string[] GetCity()
        {
            var city = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            return city;
        }

        private static string[] GetAuthor()
        {
            var author = new string[]
           {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
           };

            return author;
        }

        private static string[] GetEvent()
        {
            var events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            return events;
        }

        private static string[] GetPhrases()
        {
            var phrase = new string[]
            {
                "Excellent product.",
               "Such a great product.",
               "I always use that product.",
               "Best product of its category.",
               "Exceptional product.",
               "I can’t live without this product."
            };

            return phrase;
        }
    }
}
