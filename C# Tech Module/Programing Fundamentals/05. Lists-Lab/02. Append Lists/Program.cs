namespace _02.Append_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            List<string> list = Console.ReadLine().Split('|').Reverse().ToList();
           
            var printList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                List<string> newList = list[i].Split(' ').ToList();

                foreach (var num in newList)
                {
                    if (num != string.Empty)
                    {
                        printList.Add(num);
                    }
                }             
            }

            Console.WriteLine(string.Join(" ", printList));           
        }
    }
}
