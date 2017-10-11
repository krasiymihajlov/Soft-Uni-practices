using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private readonly MethodInfo[] HeroManagerMethods;

    private IInputReader reader;
    private IOutputWriter writer;
    private HeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, HeroManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;

        this.HeroManagerMethods = this.heroManager.GetType().GetMethods();
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> commandArgs = this.SplitInput(inputLine);
            string command = commandArgs[0];
            commandArgs.RemoveAt(0);

            string[] methodNonParsedParams = null;

            string commandFullName = command + "Command";
            MethodInfo methodToInvoke = this.HeroManagerMethods.FirstOrDefault(m => m.Name.Equals(commandFullName, StringComparison.OrdinalIgnoreCase));

            ParameterInfo[] methodParams = methodToInvoke.GetParameters();

            this.writer.WriteLine(this.processInput(commandArgs));
            isRunning = this.ShouldEnd(inputLine);
        }
    }

    private List<string> SplitInput(string input)
    {
        return input.Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string processInput(List<string> arguments)
    {   
        //string command = arguments[0];
        //arguments.RemoveAt(0);

        //Type commandType = Type.GetType(command + "Command");
        //var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
        //AbstractCommand cmd = (AbstractCommand)constructor.Invoke(new object[] { arguments, this.heroManager });
        //return cmd.Execute();
        return "";
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}