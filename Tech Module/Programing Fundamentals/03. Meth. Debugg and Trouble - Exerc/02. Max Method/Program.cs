namespace _02.Max_Method
{
    using System;

    public class MaxMethod
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int maxNumber = GetMax(a, b, c);
            Console.WriteLine(maxNumber);
        }

        public static int GetMax(int a, int b, int c)
        {
            if (a <= b)
            {
                if (b <= c)
                {
                    return c;
                }
                else
                {
                    return b;
                }
            }
            else
            {
                if (a >= c)
                {
                    return a;
                }
                else
                {
                    return c;
                }
            }
        }
    }
}
