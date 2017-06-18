namespace _05.Bomb_Numbers
{
    using System;
    using System.Linq;

    public class ListsExrcises
    {
        public static void Main()
        {
            var numbersOfList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var SpecialNumber = Console.ReadLine().Split().Select(int.Parse).ToList();

            var bombNumber = SpecialNumber[0];
            var bombPower = SpecialNumber[1];

            for (int i = 0; i < numbersOfList.Count; i++)
            {
                if (numbersOfList[i] == bombNumber)
                {
                    for (int right = 0; right < bombPower ; right++)
                    {
                        if ((i == numbersOfList.Count))
                        {
                            numbersOfList.RemoveAt(i - 1);
                            break;
                        }
                        else
                        {
                            numbersOfList.RemoveAt(i + 1);
                        }
                    }

                    for (int left = 0; left < bombPower; left++)
                    {
                        if (i - 1 == 0)
                        {     
                            numbersOfList.RemoveAt(0);
                            break;
                        }
                        else if (i == 0)
                        {
                            break;
                        }
                        else
                        {
                            numbersOfList.RemoveAt(i - 1 - left);
                        }
                    }

                    numbersOfList.Remove(bombNumber);

                    i = 0;
                }                
            }
            
            var sum = numbersOfList.ToList().Sum();

            Console.WriteLine(sum);        
        }
    }
}
