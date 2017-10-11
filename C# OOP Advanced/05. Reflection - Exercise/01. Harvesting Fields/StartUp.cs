namespace _01HarestingFields
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            RichSoilLand rich = new RichSoilLand();
            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        Console.WriteLine(rich.GetPrivateMethods());
                        break;
                    case "protected":
                        Console.WriteLine(rich.GetProtectedMethods());
                        break;
                    case "public":
                        Console.WriteLine(rich.GetPublicMethods());
                        break;
                    case "all":
                        Console.WriteLine(rich.GetAllMethods());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
