namespace _07.Sum_Arrays
{
    using System;
    using System.Linq;

    public class Arrays
    {
        public static void Main()
        {
            int[] firstArrays = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArrays = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sum = new int[Math.Max(firstArrays.Length, secondArrays.Length)];           

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = firstArrays[i % firstArrays.Length] + secondArrays[i % secondArrays.Length];
                Console.Write($"{sum[i]} ");
            }
        }
    }
}
