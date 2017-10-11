using System;

public class StartUp
{
    public static void Main()
    {
        Scale<string> stringScale = new Scale<string>("a", "c");
        Console.WriteLine(stringScale.GetHavier());

        Scale<int> integerScale = new Scale<int>(1, 2);
        Console.WriteLine(integerScale.GetHavier());
    }
}

