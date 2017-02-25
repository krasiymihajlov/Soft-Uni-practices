namespace _00.Test
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var input2 = int.Parse(Console.ReadLine());

            var numberOfSteps = input % 86400;
            var timeInSeconds = input2 % 86400;

        }
    }
}
