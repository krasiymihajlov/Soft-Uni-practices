namespace _03.Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lists
    {
        public static void Main()
        {
            var equalNumber = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            
            Console.WriteLine(string.Join(" ", GetListFromSums(equalNumber)));
        }

        public static List<double> GetListFromSums(List<double> previousList)
        {            
            int index = 0;

            while (index < previousList.Count - 1)
            {
                if (previousList[index] == previousList[index + 1])
                {
                    previousList[index] = previousList[index] + previousList[index + 1];
                    previousList.RemoveAt(index + 1);
                    if (index > 0)
                    {
                        index--;
                    }
                }
                else
                {
                    index++;
                }
            }

            return previousList;
        }
    }
}