namespace _18.Different_Integers_Size
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            string inputNumber = Console.ReadLine();
            string output = "";
            try
            {
                long.Parse(inputNumber);
                output += $"{inputNumber} can fit in:\n";
            }
            catch (Exception)
            {
                output += $"{inputNumber} can't fit in any type";
            }  
                      
             try
             {
                 sbyte.Parse(inputNumber);
                 output += "* sbyte\n";
             }
             catch (Exception)
             {
             }

            try
            {
                byte.Parse(inputNumber);
                output += "* byte\n";
            }
            catch (Exception)
            {            
            }

            try
            {
                short.Parse(inputNumber);
                output += "* short\n";
            }
            catch (Exception)
            {
            }

            try
            {
                ushort.Parse(inputNumber);
                output += "* ushort\n";
            }
            catch (Exception)
            {
            }

            try
            {
                int.Parse(inputNumber);
                output += "* int\n";
            }
            catch (Exception)
            {
            }

            try
            {
                uint.Parse(inputNumber);
                output += "* uint\n";
            }
            catch (Exception)
            {
            }

            try
            {
                long.Parse(inputNumber);
                output += "* long\n";
            }
            catch (Exception)
            {                
            }           

            Console.WriteLine(output);  
        }
    }
}
