namespace _08.CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            CustomList<string> list = new CustomList<string>();
            string readCommand;
            while ((readCommand = Console.ReadLine()) != "END")
            {
                string[] tokens = readCommand.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case"Add":
                        list.Add(tokens[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(tokens[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(tokens[1]));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        Console.WriteLine(list.Print());
                        break;
                    case"Sort":
                        list = Sorter.Sort(list);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
