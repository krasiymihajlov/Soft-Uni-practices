namespace _4.Elevator
{
    using System;

    public class DateAndTypesLab
    {
        public static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacityOfPerson = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)numberOfPeople / capacityOfPerson);
            Console.WriteLine(courses);

        }
    }
}
