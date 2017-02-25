namespace _10.Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DictLambdaLinqExer
    {
        public static void Main()
        {
            var input = "Lepa Brena @Sunny Beach 25 3500";//Console.ReadLine();

            while (input != "End")
            {
                var separator = new string[] { " @" };       
                var inputSpace = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var name = inputSpace;

                input = Console.ReadLine();
            }
        }
    }
}
