namespace _03.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListExrcises
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            var options = Console.ReadLine();

            while (!(options == "print"))
            {
                var newList = new List<int>();
                var newOptions = options.Split();
                var firstComand = newOptions[0];

                if (firstComand == "add")
                {
                    var index = int.Parse(newOptions[1]);
                    var add = int.Parse(newOptions[2]);
                    elements.Insert(index, add);
                }
                else if (firstComand == "addMany")
                {
                    var index = int.Parse(newOptions[1]);
                    for (int i = 0; i < newOptions.Length - 2; i++)
                    {
                        var add = int.Parse(newOptions[i + 2]);
                        elements.Insert(index + i, add);
                    }
                }
                else if (firstComand == "contains")
                {
                    var containElement = int.Parse(newOptions[1]);
                    if (elements.Contains(containElement))
                    {
                        int myIndex = elements.FindIndex(p => p == containElement);
                        Console.WriteLine(myIndex);
                    }
                    else
                    {
                        Console.WriteLine(-1);
                    }
                }
                else if (firstComand == "remove")
                {
                    var index = int.Parse(newOptions[1]);
                    elements.RemoveAt(index);
                }
                else if (firstComand == "shift")
                {
                    var index = int.Parse(newOptions[1]);

                     ShiftLeft(elements, index);
                }
                else if (firstComand == "sumPairs")
                {
                    if (elements.Count % 2 == 0)
                    {
                        for (int i = 0; i < elements.Count; i++)
                        {
                            var sum = elements[i] + elements[i + 1];
                            elements[i] = sum;
                            elements.RemoveAt(i + 1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < elements.Count - 1; i++)
                        {
                            var sum = elements[i] + elements[i + 1];
                            elements[i] = sum;
                            elements.RemoveAt(i + 1);
                        }
                    }
                }


                options = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", elements)}]");
        }

        public static void ShiftLeft(List<int> list, int shifts)
        {
            var newList = new List<int>(list.Count);

            for (int i = 0; i < shifts; i++)
            {
                var temp = list[0];
                for (int j = 1; j < list.Count; j++)
                {
                    list[j - 1] = list[j];
                }
                list[list.Count - 1] = temp;
            }           
        }
    }
}
