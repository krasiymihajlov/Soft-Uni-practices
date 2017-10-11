namespace _03.Mankind
{
    using System;

    public class Program
    {
        public static void Main()
        {
            try
            {
                string[] inputStudent = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(inputStudent[0], inputStudent[1], inputStudent[2]);

                string[] inputWorker = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(inputWorker[0], inputWorker[1], decimal.Parse(inputWorker[2]), decimal.Parse(inputWorker[3]));

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
