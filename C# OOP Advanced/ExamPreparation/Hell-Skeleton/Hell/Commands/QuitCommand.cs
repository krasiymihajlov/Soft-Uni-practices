using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    protected QuitCommand()
    {

    }
    public QuitCommand(List<string> args, IManager manager)
    {
    }

    public override string Execute()
    {
        return ""; //base.Manager.Quit(this.ArgsList);
    }
}