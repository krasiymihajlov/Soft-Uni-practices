namespace _3.Exact_Sum_of_Real_Numbers
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());                
                sum += number;           
            }
            Console.WriteLine("{0}", sum);
        }
    }
}
