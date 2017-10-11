using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int labs = int.Parse(Console.ReadLine());
        int lengthOfTheTrack = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(labs, lengthOfTheTrack);
        while (isRunning)
        {
            List<string> tokens = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToList();
            GetCommand(tokens);
        }
    }

    private void GetCommand(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);
        switch (command)
        {
            case "RegisterDriver":
                this.raceTower.RegisterDriver(arguments);
                break;
            case "RegisterProvider":
               
                break;
            case "Day":
               // OutputWriter(raceTower.Day());
                break;
            case "Mode":
               // OutputWriter(raceTower.Mode(arguments));
                break;
            case "Check":
              //  OutputWriter(draftManager.Check(arguments));
                break;
            case "Shutdown":
               // OutputWriter(draftManager.ShutDown());
                this.isRunning = false;
                break;
            default:
                break;
        }
    }

    private void OutputWriter(string message)
    {
        Console.WriteLine(message);
    }
}

