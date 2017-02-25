namespace _05.Boolean_Variable
{
    using System;

    public class DateAndTypesExercises
    {
        public static void Main()
        {
            string variable = Console.ReadLine();
            bool boolean = Convert.ToBoolean(variable);
            if (boolean == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
