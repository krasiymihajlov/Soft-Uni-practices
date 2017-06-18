namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var phoneBook = new Dictionary<string, string>();

            while(text != "stop")
            {
                if (text == "search")
                {
                    text = Console.ReadLine();

                    while (text != "stop")
                    {
                        var searchName = text;
                            
                        if (phoneBook.ContainsKey(searchName))
                        {
                            Console.WriteLine($"{searchName} -> {phoneBook[searchName]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {searchName} does not exist.");
                        }

                        text = Console.ReadLine();
                    }

                    break;
                }

                var arr = text.Split('-');

                var name = arr[0];
                var phoneNumber = arr[1];

                phoneBook[name] = phoneNumber;

                text = Console.ReadLine();
            }
        }
    }
}
