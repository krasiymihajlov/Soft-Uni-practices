using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBulder;
    private ConsoleWrite consoleWriter;
    private CosoleRead consoleReader;

    public Engine()
    {
        this.nationsBulder = new NationsBuilder();
        this.consoleWriter = new ConsoleWrite();
        this.consoleReader = new CosoleRead();
    }
    public void Run()
    {
        string command;
        while ((command = Console.ReadLine()) != "Quit")
        {
            GetCommand(command);
        }

        OutputWriter(nationsBulder.GetWarsRecord());
    }

    private void GetCommand(string input)
    {
        List<string> list = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string command = list[0];

        switch (command)
        {
            case "Bender":
                this.nationsBulder.AssignBender(list);
                break;
            case "Monument":
                this.nationsBulder.AssignMonument(list);
                break;
            case "Status":
                OutputWriter(this.nationsBulder.GetStatus(list[1]));
                break;
            case "War":
                this.nationsBulder.IssueWar(list[1]);
                break;
        }
    }

    private void OutputWriter(string status)
    {
        Console.WriteLine(status);
    }
}

