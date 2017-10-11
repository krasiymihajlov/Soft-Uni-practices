namespace _10.Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] secondLine = Console.ReadLine().Split();
            string[] thirdLine = Console.ReadLine().Split();
            
            Tuple<string, string> tuple1 = new Tuple<string, string>(firstLine[0] + " " + firstLine[1], firstLine[2]);
            Console.WriteLine(tuple1);

            Tuple<string, int> tuple2 = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));
            Console.WriteLine(tuple2);

            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));
            Console.WriteLine(tuple3);
        }
    }
}
