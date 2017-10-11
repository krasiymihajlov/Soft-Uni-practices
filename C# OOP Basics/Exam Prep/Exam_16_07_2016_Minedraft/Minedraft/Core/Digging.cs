
using System;
using System.Collections.Generic;
using System.Linq;

public class Digging
{
    private bool isRunning;
    private DraftManager draftManager;

    public Digging()
    {
        this.isRunning = true;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        int labs = int.Parse(Console.ReadLine());
        double lengthOfTheTrack = double.Parse(Console.ReadLine());
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
            case "RegisterHarvester":
                try
                {
                    draftManager.RegisterHarvester(arguments);
                    OutputWriter(draftManager.RegisterHarvester(arguments));
                }
                catch (ArgumentException ae)
                {
                    OutputWriter($"Harvester is not registered, because of it's {ae.Message}");
                }

                break;
            case "RegisterProvider":
                try
                {
                    OutputWriter(draftManager.RegisterProvider(arguments));
                }
                catch (ArgumentException ae)
                {
                    OutputWriter($"Provider is not registered, because of it's {ae.Message}");
                }
                break;
            case "Day":
                OutputWriter(draftManager.Day());
                break;
            case "Mode":
                OutputWriter(draftManager.Mode(arguments));
                break;
            case "Check":
                OutputWriter(draftManager.Check(arguments));
                break;
            case "Shutdown":
                OutputWriter(draftManager.ShutDown());
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

