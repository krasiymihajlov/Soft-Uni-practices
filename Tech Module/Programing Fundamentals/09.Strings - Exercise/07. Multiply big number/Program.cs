namespace _07.Multiply_big_number
{
    using System;
    using System.Linq;
    using System.Text;

    public class StringExercises
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Trim('0');
            var secondDigit = int.Parse(Console.ReadLine());                    
    
            var result = new StringBuilder();
            var transfer = 0;

            if (secondDigit == 0)
            {
                Console.WriteLine(0);
                return; 
            }

            for (int i = 0; i < firstLine.Length; i++)
            {
                var numerator = int.Parse(firstLine[firstLine.Length - 1 - i]
                    .ToString());

                var total = numerator * secondDigit + transfer;
                transfer = 0;

                if (total >= 10)
                {
                    transfer = total / 10;
                    result.Append(total % 10);
                }
                else
                {
                    result.Append(total);
                }
            }
           
            if (transfer > 0)
            {
                result.Append(transfer);
            }

            var resultToString = result.ToString().Reverse();

            Console.WriteLine(string.Join("", resultToString));

        }
    }
}
