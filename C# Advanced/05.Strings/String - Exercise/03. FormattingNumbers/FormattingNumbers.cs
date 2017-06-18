namespace _03.FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(input[0]);    
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            string hexDecimal = a.ToString("X");  //string.Format("{0:X}", a);
            string binary = Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10); 

            Console.WriteLine("|{0, -10}|{1, 10}|{2, 10:F2}|{3, -10:F3}|", hexDecimal, binary, b, c );
        }
    }
}
